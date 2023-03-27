namespace InstantLicenses.DataLayer.DbModels
{
    public class LicenseRent
    {
        public DateTime? CreatedAt { get; set; }
        public string User { get; set; }
        public int Id { get; set; }
        public License License { get; set; }
    }
}
