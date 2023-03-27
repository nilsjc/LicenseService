using InstantLicenses.Core.Models;
using System.Runtime.CompilerServices;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// Connection to DB. Internal use only.
    /// </summary>
    public interface ILicenseDBService
    {
        Task<License> Get(string id);
        Task Store(License license);
        Task<IEnumerable<License>> GetAll(int size, int page);
    }
}
