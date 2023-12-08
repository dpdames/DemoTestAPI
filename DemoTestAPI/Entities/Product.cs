using System.Text.Json.Serialization;

namespace DemoTestAPI.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public string Quantity { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
