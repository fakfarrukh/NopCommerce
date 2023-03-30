using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Nop.Data;
using Nop.Plugin.Misc.AppyTwoAppointment.Models.AppyAppointmentModel;

namespace Nop.Plugin.Misc.AppyTwoAppointment.Infrastructure.Data
{
    public class Appointment2Appy_db_Context : DbContext
    {
        public Appointment2Appy_db_Context(DbContextOptions<Appointment2Appy_db_Context> options)
        : base(options)
        {
        }


        public virtual DbSet<VendorStaff> VendorStaffs { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductServiceCategory> ProductServiceCategory { get; set; }
        public virtual DbSet<InsuranceCompany> InsuranceCompany { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost; port=3306; database=nop_db; user=root; password=P@ssw0rd123!@#; Persist Security Info=False; Connect Timeout=300";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");
            }

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationEntityTypeConfiguration).Assembly);



        }
    }

    public class AppointmentContextFactory : IDesignTimeDbContextFactory<Appointment2Appy_db_Context>
    {
        public Appointment2Appy_db_Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Appointment2Appy_db_Context>();
            var connectionString = "server=localhost; port=3306; database=nop_db; user=root; password=P@ssw0rd123!@#; Persist Security Info=False; Connect Timeout=300";
            try
            {
                connectionString = DataSettingsManager.LoadSettings().ConnectionString;

            }
            catch (Exception)
            {

                // throw;
            }


            optionsBuilder.UseMySql(connectionString,


              ServerVersion.AutoDetect(connectionString));

            return new Appointment2Appy_db_Context(optionsBuilder.Options);
        }
    }
}
