using Importer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Contexts
{
    public class EmployeesContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeesContext() : base(new DbContextOptions<EmployeesContext> ())
        { }
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlite("Data Source=employees.db");
        //    optionsBuilder.UseSqlite(connectionString);
        //}
    }
}
