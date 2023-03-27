using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILicenseDBService<License> getLicenseFromDB;
        public CustomerService(ILicenseDBService<License> getLicenseFromDB)
        {
            this.getLicenseFromDB = getLicenseFromDB;
        }

        public Task<bool> AddClientAsync(int licenseId, string user)
        {
            throw new NotImplementedException();
        }

        public Task<int> CheckFreeLicenseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LicenseDTO> RentLicenseAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
