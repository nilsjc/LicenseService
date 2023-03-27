using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// For insert a single license. Exposed to client.
    /// </summary>
    internal interface IInsertLicense
    {
        /// <summary>
        /// Inserts a new License. Exposed to client.
        /// </summary>
        /// <param name="licenseDTO">Add your new license here</param>
        /// <returns></returns>
        bool Post(LicenseDTO licenseDTO);
    }
}
