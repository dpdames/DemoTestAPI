using DemoTestAPI.Data;
using DemoTestAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext) 
        { 
            _dataContext = dataContext; 
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            var customer = await _dataContext.Customers.ToListAsync();
          
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _dataContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound("Customer Not Found");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer([FromBody]Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync(); 
            
            return Ok(await _dataContext.Customers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer updateCustomer)
        {
            var dbDemo = await _dataContext.Customers.FindAsync(updateCustomer.Id);
            if (dbDemo == null)
            {
                return NotFound("Customer Not Found");
            }

            dbDemo.Name = updateCustomer.Name;
            dbDemo.Phone = updateCustomer.Phone;
            dbDemo.Address = updateCustomer.Address;
            dbDemo.Email = updateCustomer.Email;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Customers.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbDemo = await _dataContext.Customers.FindAsync(id);
            if (dbDemo == null)
            {
                return NotFound("Customer Not Found");
            }

            _dataContext.Customers.Remove(dbDemo);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Customers.ToListAsync());
        }
    }
}
