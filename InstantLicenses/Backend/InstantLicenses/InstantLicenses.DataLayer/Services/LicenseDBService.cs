using InstantLicenses.Core.Interfaces;
using InstantLicenses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantLicenses.DataLayer.Services
{
    public class LicenseDBService : ILicenseDBService, IDisposable
    {
        private volatile bool disposed = false;
        private readonly LicenseContext context;

        public Task<License> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<License>> GetAll(int size, int page)
        {
            throw new NotImplementedException();
        }

        public Task Store(License license)
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
