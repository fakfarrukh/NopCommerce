using Nop.Data;
using Nop.Plugin.Misc.Appointment.Domain;
using System;
using System.Linq;

namespace Nop.Plugin.Misc.Appointment.Services
{
    public class VendoreInsuranceService : IVendoreInsuranceService
    {
        private readonly IRepository<aaInsurance> repository;

    public VendoreInsuranceService(IRepository<aaInsurance> repository)
    {
      this.repository = repository;
    }

   

       

        public async Task Save(aaInsurance record)
        {
           var item= await  repository.GetByIdAsync(record.Id);

      if (item != null)
      {
        
        item.Title = record.Title;
        
        await repository.UpdateAsync(item);
      }
      else {
        var max = 1;
        if (repository.GetAll().Any())
        {
          max = repository.GetAll().Max(i => i.Id)+1;
        }

        record.Id =  max;
        await repository.InsertAsync(record);
      
      }


           
           
        }

        public async Task<aaInsurance> GetAsync(int id)
        {
           return await repository.GetByIdAsync(id);
        }

       

        public async Task RemoveAsync(int id)
        {
            var item = await repository.GetByIdAsync(id);
            await repository.DeleteAsync(item);
        }

  

    public async Task<List<aaInsurance>> GetAllByVendorId(int id)
    {
      var item = await repository.GetAllAsync(query =>
      {
        return from c in query

               where c.VendoreId == id
               select c;
      });
      if (item.Any())
      {


        return item.ToList();
      }
      else { return new List<aaInsurance>(); };
    }
  }
}
