using InstantLicenses.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
