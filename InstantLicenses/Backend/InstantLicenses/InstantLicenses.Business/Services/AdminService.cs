namespace InstantLicenses.Business.Services
{
    using InstantLicenses.Core.Interfaces;
    using InstantLicenses.Core.Models;
    using InstantLicenses.DataLayer.DbModels;
    using InstantLicenses.Web.API.DTOs;
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
            var now = DateTime.Now;
            licenses.ToList().ForEach(license =>
            {
                if (license.RentedAt != null)
                {
                    var timeLeft = Math.Round((now - license.RentedAt).TotalSeconds, 0);
                    if(timeLeft < 0 || timeLeft > 15)
                    {
                        license.TimeLeft = 0;
                    }
                    else
                    {

                        license.TimeLeft = 15 - timeLeft;
                    }

                }
                else
                {
                    license.TimeLeft = 0;
                }
            }); 
                
            return licenses;
        }

        public async Task<EntityStatus> PostLicense(string licenseName)
        {
            var dateNow = DateTime.UtcNow;
            return await this.licenseDBService.Store(licenseName);
        }
        
        public async Task DeleteLicense(string name)
        {
            await this.licenseDBService.Delete(name);
        }
    }
}
