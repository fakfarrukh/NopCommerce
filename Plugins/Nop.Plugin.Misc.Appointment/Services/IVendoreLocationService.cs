using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.Appointment.Domain;

namespace Nop.Plugin.Misc.Appointment.Services
{
    public interface IVendoreLocationService
    {
        Task<aaVendor> GetAsync(int id);
        Task<aaVendor> GetByVendor(int id);
    
        Task RemoveAsync(int id);
        void Save(aaVendor record);



    }
}
