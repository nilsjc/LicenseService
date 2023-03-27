using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Services
{
    public class CustomerRentLicense : ICustomerRentLicense
    {
        private readonly ILicenseDBService getLicenseFromDB;
        public CustomerRentLicense(ILicenseDBService getLicenseFromDB)
        {
            this.getLicenseFromDB = getLicenseFromDB;
        }
        public LicenseDTO Rent(string id)
        {
            throw new NotImplementedException();
        }
    }
}
