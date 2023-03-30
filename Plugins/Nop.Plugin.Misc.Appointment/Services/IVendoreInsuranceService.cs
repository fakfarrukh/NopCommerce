using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.Appointment.Domain;

namespace Nop.Plugin.Misc.Appointment.Services
{
    public interface IVendoreInsuranceService
  {
    Task<aaInsurance> GetAsync(int id);
    Task RemoveAsync(int id);
    Task Save(aaInsurance record);
    Task<List<aaInsurance>> GetAllByVendorId(int id);



    }
}
