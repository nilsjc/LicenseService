using InstantLicenses.Core.Interfaces;
using InstantLicenses.Web.API.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantLicenses.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IAdminService adminService;
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<LicenseDTO>> GetAsync(int page, int size=20)
        {
            var result = await this.adminService.ShowLicenses(page, size);
            return result;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(string licenseName)
        {
            var result = await this.adminService.PostLicense(licenseName);
            if (result == Core.Models.EntityStatus.LicenseCreated)
            {
                return Ok();
            }
            else if(result == Core.Models.EntityStatus.LicenseExisting)
            {
                return new OkObjectResult("License already in database");
            }
            return BadRequest();
        }

        
        [HttpDelete("{name}")]
        public async void Delete(string name)
        {
            await this.adminService.DeleteLicense(name);
        }
    }
}
