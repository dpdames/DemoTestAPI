namespace DemoTestAPI.Entities
{
    public class Customer
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public string Phone {  get; set; } = string.Empty;  
        public string Address { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;   
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public List<Courier> Couriers { get; set; }
    }
}
