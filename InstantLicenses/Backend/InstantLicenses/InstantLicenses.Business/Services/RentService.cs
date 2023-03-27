﻿using InstantLicenses.Business.Interfaces;
using InstantLicenses.Core.Interfaces;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Services
{
    public class CustomerRentLicense : ICustomerService
    {
        private readonly ILicenseDBService<License> getLicenseFromDB;
        public CustomerRentLicense(ILicenseDBService<License> getLicenseFromDB)
        {
            this.getLicenseFromDB = getLicenseFromDB;
        }

        public Task<LicenseDTO> RentLicenseAsync(string id)
        {
            // check availablity
            // select if available
            // add timestamp to specific
            // get license 
            // map it to DTO
            throw new NotImplementedException();
        }
    }
}
