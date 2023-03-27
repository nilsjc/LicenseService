using InstantLicenses.Core.Interfaces;
using InstantLicenses.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InstantLicenses.DataLayer.Services
{
    public class LicenseDBService : ILicenseDBService<License>, IDisposable
    {
        private readonly License_Context context;
        private bool disposedValue;

        public LicenseDBService()
        {
            context = new License_Context();
        }

        public async Task<License> Get(int id)
        {
            return await context.Licenses
                .FirstOrDefaultAsync(x => x.Id == id) ?? new EmptyLicense();
        }

        public async Task<IEnumerable<License>> GetAll(int size, int page)
        {
            IQueryable<License> licenses = this.context.Licenses
                .OrderBy(x => x.Id)
                .Skip(page)
                .Take(size);

            return await licenses.AsNoTracking().ToListAsync();
        }

        public async Task Store(params License[] license)
        {
            foreach(var lic in license)
            {
                this.context.Add(lic);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var license = await this.Get(id);
            if (license is EmptyLicense) 
                return;
            this.context.Remove(license);
            await this.context.SaveChangesAsync();
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
    }
}
