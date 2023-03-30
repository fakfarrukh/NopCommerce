using Nop.Data;
using Nop.Plugin.Misc.Appointment.Domain;
using System;
using System.Linq;

namespace Nop.Plugin.Misc.Appointment.Services
{
    public class VendoreLocationService : IVendoreLocationService
    {
        private readonly IRepository<aaVendor> _vendoreLocationRecordRepository;

        public VendoreLocationService(IRepository<aaVendor> vendoreLocationRecordRepository)
        {
            _vendoreLocationRecordRepository = vendoreLocationRecordRepository;
        }

       

        public async void Save(aaVendor record)
        {
           var item= await  _vendoreLocationRecordRepository.GetByIdAsync(record.VendoreId);

      if (item != null)
      {
        item.Id = record.VendoreId;
        item.ParrentVendor = record.ParrentVendor;
        item.Latitude = record.Latitude;
        item.Longitude = record.Longitude;
        await _vendoreLocationRecordRepository.UpdateAsync(item);
      }
      else {
        record.Id = record.VendoreId;
        await _vendoreLocationRecordRepository.InsertAsync(record);
      
      }


           
           
        }

        public async Task<aaVendor> GetAsync(int id)
        {
           return await _vendoreLocationRecordRepository.GetByIdAsync(id);
        }

        public async Task<aaVendor> GetByVendor(int id)
        {
            var Item = await _vendoreLocationRecordRepository.GetAllAsync(query =>
            {
                return from c in query

                       where c.VendoreId == id
                       select c;
            });
            if (Item.Any())
            { 
            
            return Item.First();
            }
            return null ;
        }

        public async Task RemoveAsync(int id)
        {
            var item = await _vendoreLocationRecordRepository.GetByIdAsync(id);
            await _vendoreLocationRecordRepository.DeleteAsync(item);
        }
    }
}
