using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GettyWAPI.Controllers.api
{
    public class CustomersController : ApiController
    {
        private NorthwindEntities _context; //= new NorthwindEntities();

        public CustomersController(NorthwindEntities context)
        {
            _context = context;
        }

        //GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCustomer(string id)
        {
            var model = await _context.Customers.SingleAsync(c => c.CustomerID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(string id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CustomerExists(customer.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(string id)
        {
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(c => c.CustomerID == id);
        }
    }
}