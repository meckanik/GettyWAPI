using System.Threading.Tasks;
using System.Web.Http;
using GettyWAPI.Models;
using GettyWAPI.Repository;
using Newtonsoft.Json;

namespace GettyWAPI.Controllers.api
{
    public class CustomerJsonController : ApiController
    {
        private CustomerRepository _repository; // = new CustomerRepository();

        public CustomerJsonController(CustomerRepository repository)
        {
            _repository = repository;
        }

        //GET: api/Customers
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var customers = await _repository.GetCustomersAsync();
            return Json(JsonConvert.SerializeObject(customers));
        }

        // GET: api/Customers/5
        public async Task<IHttpActionResult> GetCustomer(string id)
        {
            var model = await _repository.GetCustomerAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            var result = Json(JsonConvert.SerializeObject(model));

            return result;
        }

        // PUT: api/Customers/5
        public IHttpActionResult PutCustomer(string id, Customer customer)
        {
            return NotFound();
        }

        // POST: api/Customers
        public async Task<IHttpActionResult> PostCustomer()
        {
            //var cust = await _repository.GetCustomerAsync("ANATR");
            //var origjson = JsonConvert.SerializeObject(cust);
            //var newmodel = JsonConvert.DeserializeObject<CustomerModel>(origjson);


            var customer = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CustomerModel>(customer);

            _repository.PutCustomer(model);
            return Ok();
        }

        // DELETE: api/Customers/5
        public IHttpActionResult DeleteCustomer(string id)
        {
            _repository.DeleteCustomer(id);

            return Ok();
        }
    }
}