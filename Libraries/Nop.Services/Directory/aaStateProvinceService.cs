using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Localization;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service
    /// </summary>
    public partial class aaStateProvinceService : IaaStateProvinceService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<aaStateProvince> _aastateProvinceRepository;

        #endregion

        #region Ctor

        public aaStateProvinceService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<aaStateProvince> stateProvinceRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _aastateProvinceRepository = stateProvinceRepository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteStateProvinceAsync(aaStateProvince stateProvince)
        {
            await _aastateProvinceRepository.DeleteAsync(stateProvince);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<aaStateProvince> GetStateProvinceByIdAsync(int stateProvinceId)
        {
            return await _aastateProvinceRepository.GetByIdAsync(stateProvinceId);
        }

        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        public virtual async Task<aaStateProvince> GetStateProvinceByAddressAsync(Address address)
        {
            return await GetStateProvinceByIdAsync(address?.StateProvinceId ?? 0);
        }


        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        public async Task<IList<aaStateProvince>> GetStatesByCountryId(int? CountryId)
        {
            try
            {
                var query = _aastateProvinceRepository?.Table.Where(x => x.CountryId == CountryId).ToList();
                return query;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            


            //var stateProvinces = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.StateProvincesAllCacheKey, showHidden), async () => await query.ToListAsync());

            
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertStateProvinceAsync(aaStateProvince stateProvince)
        {
            await _aastateProvinceRepository.InsertAsync(stateProvince);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateStateProvinceAsync(aaStateProvince stateProvince)
        {
            await _aastateProvinceRepository.UpdateAsync(stateProvince);
        }

        #endregion
    }
}