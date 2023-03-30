using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service interface
    /// </summary>
    public partial interface IaaStateProvinceService
    {
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStateProvinceAsync(aaStateProvince stateProvince);

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        Task<aaStateProvince> GetStateProvinceByIdAsync(int stateProvinceId);

        

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStateProvinceAsync(aaStateProvince stateProvince);

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStateProvinceAsync(aaStateProvince stateProvince);

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<IList<aaStateProvince>> GetStatesByCountryId(int? CountryId);
    }
}
