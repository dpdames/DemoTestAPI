using DemoTestAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace DemoTestAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Courier> Couriers { get; set; }
    }
}
