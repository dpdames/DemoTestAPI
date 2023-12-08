using DemoTestAPI.Data;
using DemoTestAPI.DTOs;
using DemoTestAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CreateController(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerId(int id) 
        { 
            var customer = await _dataContext.Customers
                .Include(c => c.Order)
                .Include(c => c.Products)
                .Include(c => c.Couriers)
                .FirstOrDefaultAsync(c => c.Id == id);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(CustomerCreateDto request)
        {
            var newCustomer = new Customer
            {
                Name = request.Name,
            };
            
            var order = new Order { Description = request.Order.Description, Customer = newCustomer};
            var products = request.Products.Select(p => new Product { Description = p.Description, Quantity = p.Quantity, Customer = newCustomer }).ToList();
            var couriers = request.Couriers.Select(r => new Courier { Name = r.Name, Customers = new List<Customer> { newCustomer } }).ToList();

            newCustomer.Order = order;
            newCustomer.Products = products;
            newCustomer.Couriers = couriers;

            _dataContext.Customers.Add(newCustomer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Customers.Include(c => c.Order).Include(c => c.Products).ToListAsync());
        }
    }
}
