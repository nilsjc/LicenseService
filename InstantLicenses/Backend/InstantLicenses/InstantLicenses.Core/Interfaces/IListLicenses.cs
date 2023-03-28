using InstantLicenses.Web.API.DTOs;

namespace InstantLicenses.Core.Interfaces
{
    public interface IListLicenses
    {
        Task<IEnumerable<LicenseDTO>> GetLicensesAsync(int size, int page);
    }
}
