using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service interface
    /// </summary>
    public partial interface IaaAppointmentService
    {
        Task DeleteaaAppointmentAsync(aaAppointment aaAppointment);

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        Task<aaAppointment> GetaaAppointmentByIdAsync(int stateProvinceId);

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertaaAppointmentAsync(aaAppointment stateProvince);

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateaaAppointmentAsync(aaAppointment stateProvince);
    }
}
