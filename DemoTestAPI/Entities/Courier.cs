using System.Text.Json.Serialization;

namespace DemoTestAPI.Entities
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Customer> Customers { get; set; }
    }
}
