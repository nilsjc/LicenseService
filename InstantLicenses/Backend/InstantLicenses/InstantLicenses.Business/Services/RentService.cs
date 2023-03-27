using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using InstantLicenses.Web.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
