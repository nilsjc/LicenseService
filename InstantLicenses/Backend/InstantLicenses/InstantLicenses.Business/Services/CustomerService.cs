namespace InstantLicenses.Business.Services
{
    using InstantLicenses.Business.Interfaces;
    using InstantLicenses.Core.DTOs;
    using InstantLicenses.Core.Interfaces;
    using InstantLicenses.DataLayer.DbModels;
    public class CustomerService : ICustomerService
    {
        private readonly ILicenseDBService<License> licenseDBService;
        public CustomerService(ILicenseDBService<License> licenseDBService)
        {
            this.licenseDBService = licenseDBService;
        }
        public async Task<CustomerLicenseDTO> RentLicenseAsync(string customerName)
        {
            var license = await this.licenseDBService.RentLicense(customerName);
            
            return new CustomerLicenseDTO { Name = license.Item1, Status = license.Item2 };
        }
    }
}
