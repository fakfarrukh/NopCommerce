using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Services.Interface;
using Nop.Services.Localization;

namespace Nop.Plugin.Appy.Appointment4.Services
{
    public class aaVendorSettingService : IaaVendorSettingService
    {
        private readonly IRepository<aaVendor> _repository;

        #region Ctor

        public aaVendorSettingService(IRepository<aaVendor> repository)
        {
            _repository = repository;
        }

        #endregion
        public virtual async Task InsertVendorSettingAsync(aaVendor aaVendor)
        {
            await _repository.InsertAsync(aaVendor);
        }

        public virtual async Task<List<aaVendor>> LoadVendorSettingAsync()
        {
           return await _repository.Table.ToListAsync();
        }
    }
}
