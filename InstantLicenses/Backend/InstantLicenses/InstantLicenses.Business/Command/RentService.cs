using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using InstantLicenses.Web.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantLicenses.Business.Command
{
    public class CustomerRentLicense : ICustomerRentLicense
    {
        private readonly IGetLicenseFromDB getLicenseFromDB;
        public CustomerRentLicense(IGetLicenseFromDB getLicenseFromDB)
        {
            this.getLicenseFromDB = getLicenseFromDB;
        }
        public LicenseDTO Rent(string id)
        {
            throw new NotImplementedException();
        }
    }
}
