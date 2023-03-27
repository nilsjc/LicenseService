namespace InstantLicenses.DataLayer.DbModels
{
    internal class LicenseRent
    {
        public DateTime? CreatedAt { get; set; }
        public string User { get; set; }
        public string LicenseId { get; set; }
        public License License { get; set; }
    }
}
