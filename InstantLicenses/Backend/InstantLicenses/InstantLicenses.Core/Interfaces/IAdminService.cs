using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// For insert a single license. Exposed to client.
    /// </summary>
    internal interface IAdminService
    {
        /// <summary>
        /// Inserts a new License. Exposed to client.
        /// </summary>
        /// <param name="licenseDTO">Add your new license here</param>
        /// <returns></returns>
        Task<bool> Post(LicenseDTO licenseDTO);

        /// <summary>
        /// Get a list of licenses. Exposed to client.
        /// </summary>
        /// <param name="size">How many license in list</param>
        /// <param name="page">From where in list. 0 = start</param>
        /// <returns></returns>
        Task<IEnumerable<LicenseDTO>> Get(int size, int page);
    }
}
