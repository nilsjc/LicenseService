using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Interfaces
{
    /// <summary>
    /// For renting a single license
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Rent a license. Exposed to client.
        /// </summary>
        /// <param name="id">Id of license</param>
        /// <returns></returns>
        Task<LicenseDTO> RentLicenseAsync(string id);
        Task<int> CheckFreeLicenseAsync();
        Task<Boolean> AddClientAsync(int licenseId, string user);

    }
}
