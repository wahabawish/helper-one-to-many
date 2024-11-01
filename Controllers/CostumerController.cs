using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealIndianGuyOneToMany.Dtos;
using RealIndianGuyOneToMany.Models;

namespace RealIndianGuyOneToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ProjDBContext _Projcontext;

        public CostumerController(ProjDBContext context)
        {
            _Projcontext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _Projcontext.Customers.Include(x => x.customerAddresses).ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customers = await _Projcontext.Customers
                .Include(_ => _.customerAddresses)
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();

            return Ok(customers);
        }
        private Customer MapCustomerObject(CustomerDtos payload)
        {
            var result = new Customer();
            result.FirstName = payload.FirstName;
            result.LastName = payload.LastName;
            result.Phone = payload.Phone;

            result.customerAddresses = new List<CustomerAddresses>();
            payload.customerAddresses.ForEach(_ => {
                var newAddress = new CustomerAddresses();
                newAddress.City = _.City;
                newAddress.Country = _.Country;
                result.customerAddresses.Add(newAddress);
            });

            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerDtos payloadCustomer)
        {
            var customerObj = MapCustomerObject(payloadCustomer);
            _Projcontext.Customers.Add(customerObj);
            await _Projcontext.SaveChangesAsync();
            return Created("", customerObj);
        }
    }
}
