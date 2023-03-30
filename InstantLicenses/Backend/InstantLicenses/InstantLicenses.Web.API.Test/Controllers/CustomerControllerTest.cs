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

namespace InstantLicenses.Web.API.Test.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task TestController()
        {
            // Arrange
            const string FakeCustomerUser = "nils";
            CustomerLicenseDTO fakeDTO = new CustomerLicenseDTO
            {
                Name = "abc123",
                Status = Core.Models.EntityStatus.LicenseCreated
            };
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.RentLicenseAsync(FakeCustomerUser))
                .Returns(Task.FromResult(fakeDTO));
            CustomerController controller = new CustomerController(customerServiceMock.Object);

            // Act
            var result = await controller.Get(FakeCustomerUser) as JsonResult;

            // Assert

        }
    }
}
