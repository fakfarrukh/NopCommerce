using Nop.Data;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Services.Interface;

namespace Nop.Plugin.Appy.Appointment4.Services
{
    public class aaOrderListService : IaaOrderList
    {
            private readonly IRepository<aaorderitemappointment> _repository;
            public aaOrderListService(IRepository<aaorderitemappointment> repository)
            {
                _repository = repository;
            }
            public async virtual Task<IList<aaorderitemappointment>> GetaaOrdersAsync(int[] orderIds)
            {

            return  _repository.Table.Where(x => orderIds.Contains(x.OrderId)).ToList();
        }
        
    }
}
