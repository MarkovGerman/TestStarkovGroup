using Importer.Contexts;
using Importer.Entities;
using Importer.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> logger;
        public EmployeeRepository(ILogger<EmployeeRepository> _logger)
        {
            logger = _logger;
        }

        public void Add(Employee value)
        {
            using (var context = new EmployeesContext())
            {
                context.Employees.Add(value);
                context.SaveChanges();
                logger.LogInformation($"Employee {value.FullName} added");
            }
        }

        public int FindOnName(string name)
        {
            using (var context = new EmployeesContext())
            {
                return context.Employees.Where(e => e.FullName == name)
                    .FirstOrDefault().Id;
            }
        }

        public Employee Get(int id)
        {
            using (var context = new EmployeesContext())
            {
                var element = context.Employees.Find(id);
                if (element == null)
                {
                    logger.LogDebug($"Employee {id} not got");
                    return null;
                }
                else
                {
                    logger.LogInformation($"Employee {element.FullName} got");
                    return element;
                }
            }
        }

        public ICollection<Employee> GetAll()
        {
            using (var context = new EmployeesContext())
            {
                return context.Employees.ToList();
                logger.LogInformation($"All employees got");
            }
        }

        public void Update(Employee value)
        {
            using (var context = new EmployeesContext())
            {
                var oldElement = context.Employees.Where(d => d.FullName == value.FullName).FirstOrDefault();
                if (oldElement != null)
                {
                    context.Employees.Remove(oldElement);
                    context.Add(value);
                    context.SaveChanges();
                    logger.LogInformation($"Department {value.FullName} updated");
                }
            }
        }
    }
}
