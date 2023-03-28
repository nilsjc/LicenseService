namespace InstantLicenses.DataLayer.DbModels
{
    public class License
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? RentedAt { get; set; }
        public string? ClientRent { get; set; }
    }

    public sealed class EmptyLicense : License
    {
        public EmptyLicense() 
        {
            Name = string.Empty;
            RentedAt = DateTime.MinValue;
            ClientRent = string.Empty;
        }
    }
}
