namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// Connection to DB. Internal use only.
    /// </summary>
    public interface ILicenseDBService<T> where T : class
    {
        Task<T> Get(int id);
        Task Store(params T[] license);
        Task<IEnumerable<T>> GetAll(int size, int page);
        Task Delete(int id);
    }
}
