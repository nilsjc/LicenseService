using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantLicenses.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InstantLicenses.Web.API.Test.Controllers
{
    public class LicenseControllerTest
    {
        [Fact]
        public async Task TestController()
        {
            // Arrange
            LicenseController controller = new();

            // Act
            var result = await controller.Rent();

            // Assert
            Assert.Equal("ABC123", (result as OkObjectResult).Value.ToString());

        }
    }
}
