namespace InstantLicenses.DataLayer.DbModels
{
    /// <summary>
    /// Used by Entity Framework
    /// </summary>
    public class License
    {
        /// <summary>
        /// Id for DB
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the license number like ABC123
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Latest rent datetime
        /// </summary>
        public DateTime? RentedAt { get; set; }
        /// <summary>
        /// Customer name
        /// </summary>
        public string? ClientRent { get; set; }
    }

    /// <summary>
    /// Used for define a empty license. Not used by EF
    /// </summary>
    public sealed class EmptyLicense : License
    {
        /// <summary>
        /// Used for define a empty license. Not used by EF
        /// </summary>
        public EmptyLicense() 
        {
            Name = string.Empty;
            RentedAt = DateTime.MinValue;
            ClientRent = string.Empty;
        }
    }
}
