using Nop.Data;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Plugin.Appy.Appointment4.Services.Interface;

namespace Nop.Plugin.Appy.Appointment4.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<aaAppointment> _repository;
        public AppointmentService(IRepository<aaAppointment> repository)
        {
            _repository = repository;
        }
        public virtual void Log(aaAppointment record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _repository.InsertAsync(record);
        }
    }
}
