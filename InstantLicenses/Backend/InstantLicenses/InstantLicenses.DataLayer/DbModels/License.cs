namespace InstantLicenses.DataLayer.DbModels
{
    internal class License
    {
        public int LicenseId { get; set; }
        public string Name { get; set; }
        public List<LicenseRent> Rents { get; set; }
    }
}
