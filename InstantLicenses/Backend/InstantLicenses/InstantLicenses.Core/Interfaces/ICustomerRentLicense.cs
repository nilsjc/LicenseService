using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Business.Interfaces
{
    /// <summary>
    /// For renting a single license
    /// </summary>
    public interface ICustomerRentLicense
    {
        /// <summary>
        /// Rent a license. Exposed to client.
        /// </summary>
        /// <param name="id">Id of license</param>
        /// <returns></returns>
        LicenseDTO Rent(string id);
    }
}
