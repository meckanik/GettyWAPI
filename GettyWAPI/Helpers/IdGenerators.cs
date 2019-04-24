using GettyWAPI.Models;

namespace GettyWAPI.Helpers
{
    public class IdGenerators
    {
        public static string GenerateCustomerId(CustomerModel customer)
        {
            var id = string.Empty;
            var parts = customer.ContactName.Split(' ');

            id = parts[0].Substring(0, 3);
            id += parts[1].Substring(0, 2);

            return id.ToUpper();
        }
    }
}