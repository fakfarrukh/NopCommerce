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
    public partial class aaProductService : IaaProductService
    {
        #region Fields

        private readonly IRepository<aaProduct> _repository;

        #endregion

        #region Ctor

        public aaProductService(IRepository<aaProduct> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteaaProductAsync(aaProduct aaProduct)
        {
            await _repository.DeleteAsync(aaProduct);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<aaProduct> GetaaProductByIdAsync(int stateProvinceId)
        {
            try
            {
                var data = _repository?.Table.Where(x => x.ProductId == stateProvinceId).FirstOrDefault();
                return data;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertaaProductAsync(aaProduct stateProvince)
        {
            await _repository.InsertAsync(stateProvince);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateaaProductAsync(aaProduct stateProvince)
        {
            await _repository.UpdateAsync(stateProvince);
        }

        #endregion
    }
}