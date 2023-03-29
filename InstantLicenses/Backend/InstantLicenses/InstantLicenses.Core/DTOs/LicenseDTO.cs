using InstantLicenses.Core.Models;

namespace InstantLicenses.Web.API.DTOs
{
    /// <summary>
    /// License class for internal use and admin
    /// </summary>
    public class LicenseDTO
    {
        /// <summary>
        /// Id in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of license like ABC123
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Time latest rent
        /// </summary>
        public DateTime RentedAt { get; set; }
        /// <summary>
        /// Status for API communication
        /// </summary>
        public EntityStatus EntityStatus { get; set; }
        /// <summary>
        /// Name of latest customer
        /// </summary>
        public string? RentCustomer { get; set; }
        /// <summary>
        /// Time left of rent (zero if not rented)
        /// </summary>
        public double TimeLeft { get; set; } = 0;
    }
}
