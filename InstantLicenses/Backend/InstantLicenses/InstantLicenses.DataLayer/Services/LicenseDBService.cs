using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using InstantLicenses.DataLayer.DbModels;
using InstantLicenses.Web.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InstantLicenses.DataLayer.Services
{
    public class LicenseDBService : ILicenseDBService<License>, IDisposable
    {
        private const int RentSeconds = 15;
        private readonly License_Context context;
        private bool disposedValue;

        public LicenseDBService()
        {
            context = new License_Context();
        }
        public async Task<(string, EntityStatus)> RentLicense(string customerName)
        {
            var now = DateTime.UtcNow;

            var activeLicenses = await this.context.Licenses
                .Where(x => x.ClientRent == customerName)
                .Where(y => y.RentedAt.Value.AddSeconds(RentSeconds) > now)
                .FirstOrDefaultAsync();

            if (activeLicenses is not null)
                return (activeLicenses.Name, EntityStatus.CustomerAlreadyRenting);

            var license = await this.context.Licenses
                .OrderBy(x => x.Name)
                .FirstAsync(l => l.RentedAt.Value.AddSeconds(RentSeconds) < now);

            if (license is null)
                return (string.Empty, EntityStatus.LicenseNotFound);

            license.ClientRent = customerName;
            license.RentedAt = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
            return (license.Name, EntityStatus.LicenseRented);
        }

        public async Task<EntityStatus> Store(string licenseName)
        {
            try
            {
                var existingLicense = await this.GetFromDB(licenseName);
                if (existingLicense is EmptyLicense)
                {
                    this.context.Add(
                        new License 
                        { 
                            Name = licenseName,
                            RentedAt = DateTime.MinValue,
                        });
                    await this.context.SaveChangesAsync();
                    return EntityStatus.LicenseCreated;
                }

                return EntityStatus.LicenseExisting;
            }
            catch(Exception ex)
            {
                // Todo Log exception
                return EntityStatus.ServerError;
            }
            
        }

        public async Task Delete(string name)
        {
            var license = await this.GetFromDB(name);
            if (license is EmptyLicense) 
                return;
            this.context.Remove(license);
            await this.context.SaveChangesAsync();
        }
        public async Task<LicenseDTO> Get(string name)
        {
            var result = await this.GetFromDB(name);
            return new LicenseDTO
            {
                Name = result.Name,
                RentedAt = DateTime.UtcNow,
                RentCustomer = result.ClientRent
            };
        }

        public async Task<IEnumerable<LicenseDTO>> GetAll(int page, int size)
        {
            var result = await GetAllFromDB(page, size);
            return ToDTOList(result);

        }
        private async Task<License> GetFromDB(string name)
        {
            return await context.Licenses
                .FirstOrDefaultAsync(x => x.Name == name) ?? new EmptyLicense();
        }

        private async Task<IEnumerable<License>> GetAllFromDB(int page, int size)
        {
            IQueryable<License> licenses = this.context.Licenses
                .OrderBy(x => x.Name)
                .Skip(page)
                .Take(size);

            return await licenses.AsNoTracking().ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
                disposedValue = true;
            }
        }

        ~LicenseDBService()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public static List<LicenseDTO> ToDTOList(IEnumerable<License>? license)
        {
            if (license is null)
                return new List<LicenseDTO>();

            return license
                .Select(x => new LicenseDTO
                {
                    Name = x.Name,
                    RentedAt = x.RentedAt,
                    Id = x.Id,
                    RentCustomer = x.ClientRent
                })
                .ToList();
        }
    }
}
