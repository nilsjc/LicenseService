namespace InstantLicenses.Core.DTOs
{
    using InstantLicenses.Core.Models;
    /// <summary>
    /// Minimal DTO for customer
    /// </summary>
    public class CustomerLicenseDTO
    {
        /// <summary>
        /// Name of license like ABC123
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Status. Used for API communication
        /// </summary>
        public EntityStatus Status { get; set; }
    }
}
