using Nop.Plugin.Appy.Appointment4.Domain;

namespace Nop.Plugin.Appy.Appointment4.Services.Interface
{
    public interface IaaOrderList
    {
        Task<IList<aaorderitemappointment>> GetaaOrdersAsync(int[] orderIds);
    }
}
