using Importer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importer.Contexts
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DepartmentContext() : base(new DbContextOptions<DepartmentContext>())
        { }
        public DepartmentContext(DbContextOptions<DepartmentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=departments.db");
        //    optionsBuilder.UseSqlite(connectionString);
        //}
    }
}
