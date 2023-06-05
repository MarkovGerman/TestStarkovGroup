using Importer.Contexts;
using Importer.Entities;
using Importer.Repositories;
using Importer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject;

internal class Program
{
    private static void Main(string[] args)
    {
        var container = new StandardKernel();
        container.Bind<IDepartmentRepository>().To<DepartmentRepository>();
        container.Bind<IEmployeeRepository>().To<EmployeeRepository>();
        container.Bind<IJobTitleRepository>().To<JobTitleRepository>();

        var builder = new ConfigurationBuilder();
       
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        // создаем конфигурацию
        var config = builder.Build();
        // получаем строку подключения

        var optionsBuilderDepartment = new DbContextOptionsBuilder<DepartmentContext>();
        var optionsDepartment = optionsBuilderDepartment.UseSqlite(config.GetConnectionString("DepartmentConnection")).Options;

        var optionsBuilderEmployee = new DbContextOptionsBuilder<EmployeesContext>();
        var optionsEmployee = optionsBuilderDepartment.UseSqlite(config.GetConnectionString("EmployeeConnection")).Options;

        var optionsBuilderJob = new DbContextOptionsBuilder<JobTitleContext>();
        var optionsJob = optionsBuilderDepartment.UseSqlite(config.GetConnectionString("JobTitleConnection")).Options;

    }
}