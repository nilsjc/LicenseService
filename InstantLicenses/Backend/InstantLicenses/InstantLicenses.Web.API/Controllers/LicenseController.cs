using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstantLicenses.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        public async Task<IActionResult> Rent()
        {
            return new OkObjectResult("ABC123");
        }
        public async Task<IActionResult> List()
        {
            return Ok();
        }
        public async Task<IActionResult> Add()
        {
            return Ok();
        }
    }
}
