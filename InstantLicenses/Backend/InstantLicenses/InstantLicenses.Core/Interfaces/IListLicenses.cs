using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// For listing all licenses in system. Exposed to client.
    /// </summary>
    internal interface IListLicenses
    {
        /// <summary>
        /// Get a list of licenses. Exposed to client.
        /// </summary>
        /// <param name="size">How many license in list</param>
        /// <param name="page">From where in list. 0 = start</param>
        /// <returns></returns>
        IEnumerable<LicenseDTO> Get(int size, int page);
    }
}
