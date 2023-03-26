using InstantLicenses.Core.Models;

namespace InstantLicenses.Business.Interfaces
{
    public interface GenerateLicenseInterface
    {
        License Generate(string id);
    }
}
