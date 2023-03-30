using Nop.Plugin.Appy.Appointment4.Domain;

namespace Nop.Plugin.Appy.Appointment4.Services.Interface
{
    public interface IaaVendorSettingService
    {
        Task InsertVendorSettingAsync(aaVendor aaVendor);
        Task<List<aaVendor>> LoadVendorSettingAsync();
    }
}
