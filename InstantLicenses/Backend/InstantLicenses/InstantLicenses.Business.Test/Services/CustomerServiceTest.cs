using InstantLicenses.Business.Services;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using InstantLicenses.DataLayer.DbModels;
using Moq;

namespace InstantLicenses.Business.Test.Services
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task CheckRentLicenseAsync()
        {
            // Arrange
            
            const string FakeCustomerName = "Nils";
            const string FakeLicenseName = "ABC123";
            const EntityStatus FakeEntiyStatus = EntityStatus.LicenseCreated;
            var licenseDbServiceMock = new Mock<ILicenseDBService<License>>();
            licenseDbServiceMock.Setup(y => y.RentLicense(FakeCustomerName))
                .Returns(
                Task.FromResult((FakeLicenseName, FakeEntiyStatus)));

            CustomerService customerService = new CustomerService(licenseDbServiceMock.Object);

            // Act
            var result = await customerService.RentLicenseAsync(FakeCustomerName);
            
            // Assert
            Assert.Equal(result.Name, FakeLicenseName);
            Assert.Equal(result.Status, FakeEntiyStatus);
        }
    }
}
