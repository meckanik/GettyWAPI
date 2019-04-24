using System.Threading.Tasks;
using System.Web.Http;
using GettyWAPI.Models;
using GettyWAPI.Repositories;
using Newtonsoft.Json;

namespace GettyWAPI.Controllers.api
{
    public class CustomerJsonController : ApiController
    {
        private CustomerRepository _repository;

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
        [HttpGet]
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
        [HttpPut]
        public async Task<IHttpActionResult> PutCustomer()
        {
            var customer = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CustomerModel>(customer);

            await _repository.InsertCustomerAsync(model);

            return Ok();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IHttpActionResult> PostCustomer()
        {
            var customer = await Request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CustomerModel>(customer);

            _repository.UpdateCustomer(model);
            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(string id)
        {
            _repository.DeleteCustomer(id);

            return Ok();
        }
    }
}