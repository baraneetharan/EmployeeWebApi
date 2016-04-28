using System.IO;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;

namespace EmployeeWebApi.Models
{
    public class EmployeeDbContext : DbContext
    {
        
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     var path = PlatformServices.Default.Application.ApplicationBasePath;
        //     optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, "EmployeeWebApi.db"));
        // }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<EmployeeMasters>().HasKey(m => m.EmpID); 
             
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
      public DbSet<EmployeeMasters> Employees { get; set; }
    }
}
