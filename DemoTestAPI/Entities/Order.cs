using System.Text.Json.Serialization;

namespace DemoTestAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
