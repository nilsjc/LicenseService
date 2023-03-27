namespace InstantLicenses.DataLayer.DbModels
{
    public class License
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LicenseRent> Rents { get; set; }
    }

    public sealed class EmptyLicense : License
    {
        public EmptyLicense() 
        {
            Id = 0;
            Name = string.Empty;
            Rents = new List<LicenseRent>();
        }
    }
}
