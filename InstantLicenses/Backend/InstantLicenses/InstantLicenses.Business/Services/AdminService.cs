using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly ILicenseDBService<License> licenseDBService;
        public AdminService(ILicenseDBService<License> getLicenseFromDB)
        {
            this.licenseDBService = getLicenseFromDB;
        }
        public async Task<IEnumerable<LicenseDTO>> ShowLicenses(int page, int size)
        {
            var licenses = await licenseDBService.GetAll(page, size);
            return ToDTOList(licenses);
        }

        public async Task<EntityStatus> PostLicense(string licenseName)
        {
            var dateNow = DateTime.UtcNow;
            return await this.licenseDBService.Store(licenseName);
        }
        public static List<LicenseDTO> ToDTOList(IEnumerable<License>? license)
        {
            if (license is null)
                return new List<LicenseDTO>();

            return license
                .Select(x => new LicenseDTO { 
                    Name = x.Name,
                    RentedAt = x.RentedAt,
                    Id = x.Id
                })
                .ToList();
        }

        public async Task DeleteLicense(string name)
        {
            await this.licenseDBService.Delete(name);
        }
    }
}
