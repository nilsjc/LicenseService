using InstantLicenses.Core.Models;
using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// Connection to DB. Internal use only.
    /// </summary>
    public interface ILicenseDBService<T> where T : class
    {
        Task<EntityStatus> Store(string licenseName);
        Task<IEnumerable<LicenseDTO>> GetAll(int page, int size);
        Task Delete(string name);
        Task<(string, EntityStatus)> RentLicense(string customerName);
    }
}
