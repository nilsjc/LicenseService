namespace InstantLicenses.Core.Interfaces
{
    /// <summary>
    /// Connection to DB. Internal use only.
    /// </summary>
    public interface IGetLicenseFromDB
    {
        string Get(string id);
    }
}
