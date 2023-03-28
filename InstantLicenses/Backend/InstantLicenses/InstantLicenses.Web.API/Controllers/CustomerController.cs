using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.DTOs;
using InstantLicenses.Web.API.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantLicenses.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet("{client}")]
        public async Task<IActionResult> Get(string client)
        {
            var result = await this.customerService.RentLicenseAsync(client);
            if(result.Status == Core.Models.EntityStatus.LicenseRented)
            {
                return new OkObjectResult($"You got license {result.Name}.");
            }
            else if(result.Status == Core.Models.EntityStatus.CustomerAlreadyRenting)
            {
                return new OkObjectResult($"You are already renting {result.Name}");
            }
            return BadRequest();
        }
    }
}
