using EmployeeDataLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataLib
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions options)
     : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Database=WebApiAuthenticationDb;Trusted_Connection=True");
        }
    }
}
