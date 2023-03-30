using MaxMind.GeoIP2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Nop.Data;
using Nop.Plugin.Appy.Appointment4.Domain;
using Nop.Web.Areas.Admin.Models.Directory;

namespace Nop.Plugin.Appy.Appointment4.Database
{
    public class DbContextAppointment : DbContext
    {
        public DbContextAppointment(DbContextOptions<DbContextAppointment> options)
        : base(options)
        {
        }
        public virtual DbSet<aaAppointment> aaAppointment { get; set; }
        public virtual DbSet<aaProductLanguage> aaProductLanguage { get; set; }
        public virtual DbSet<aaProductServiceCategory> aaProductServiceCategory { get; set; }
        public virtual DbSet<aaProductRange> aaProductRange { get; set; }
        public virtual DbSet<aaProduct> aaproduct { get; set; }
        public virtual DbSet<aaStateProvince> aaStateProvince { get; set; }
        public virtual DbSet<aaCustomerRelative> aacustomerrelative { get; set; }
        public virtual DbSet<aaServiceCatagory> aaServiceCatagory { get; set; }
        public virtual DbSet<aaInsuranceCompany> aaInsuranceCompany { get; set; }
        public virtual DbSet<aaVendor> aaVendor { get; set; }
        public virtual DbSet<aaVendorInsurance> aaVendorInsurances { get; set; }

        public virtual DbSet<aaVendorStaff>aaVendorStaff { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost; database=nopdb; user=root; password=Appy@innovate; Persist Security Info=False; Connect Timeout=300";
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

    public class AppointmentContextFactory : IDesignTimeDbContextFactory<DbContextAppointment>
    {
        public DbContextAppointment CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextAppointment>();
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

            return new DbContextAppointment(optionsBuilder.Options);
        }
    }
}
