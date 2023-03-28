using InstantLicenses.Core.Models;

namespace InstantLicenses.Web.API.DTOs
{
    public class LicenseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? RentedAt { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}
