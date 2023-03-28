namespace InstantLicenses.Business.Interfaces
{
    using InstantLicenses.Core.DTOs;
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
        Task<CustomerLicenseDTO> RentLicenseAsync(string customerUser);
    }
}
