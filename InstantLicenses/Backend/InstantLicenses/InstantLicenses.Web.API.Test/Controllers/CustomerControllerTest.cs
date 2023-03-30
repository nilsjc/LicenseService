using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantLicenses.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using InstantLicenses.Business.Interfaces;
using Moq;
using InstantLicenses.Core.DTOs;
using System.Text.Json;

namespace InstantLicenses.Web.API.Test.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task TestController()
        {
            const string FakeLicenseName = "abc123";
            // Arrange
            const string FakeCustomerUser = "nils";
            CustomerLicenseDTO fakeDTO = new CustomerLicenseDTO
            {
                Name = FakeLicenseName,
                Status = Core.Models.EntityStatus.LicenseRented
            };
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.RentLicenseAsync(FakeCustomerUser))
                .Returns(Task.FromResult(fakeDTO));
            CustomerController controller = new CustomerController(customerServiceMock.Object);

            // Act
            var jsonResult = await controller.Get(FakeCustomerUser) as JsonResult;
            var result = (CustomerLicenseDTO)jsonResult.Value;

            // Assert
            Assert.Equal(FakeLicenseName, result.Name);
            Assert.Equal(Core.Models.EntityStatus.LicenseRented, result.Status);
        }
    }
}
