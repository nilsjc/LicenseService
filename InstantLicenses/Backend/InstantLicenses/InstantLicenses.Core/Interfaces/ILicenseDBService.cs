using InstantLicenses.Core.Models;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// Connection to DB. Internal use only.
    /// </summary>
    public interface ILicenseDBService<T> where T : class
    {
        Task<T> Get(string name);
        Task<EntityStatus> Store(string licenseName);
        Task<IEnumerable<T>> GetAll(int page, int size);
        Task Delete(string name);
        Task<(string, EntityStatus)> RentLicense(string customerName);
    }
}
