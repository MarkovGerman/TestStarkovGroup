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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ILogger<DepartmentRepository> logger;
        public DepartmentRepository(ILogger<DepartmentRepository> _logger) 
        {
            logger = _logger;
        }

        public void Add(Department value)
        {
            using (var context = new DepartmentContext())
            {
                context.Departments.Add(value);
                context.SaveChanges();
                logger.LogInformation($"Department {value.Name} {value.ParentID} added");
            }
        }

        public int FindOnName(string name)
        {
            using (var context = new DepartmentContext())
            {
                var department = context.Departments.Where(d => d.Name==name).FirstOrDefault();
                return department != null ? department.Id : -1;
            }
        }

        public Department Get(int id)
        {
            using (var context = new DepartmentContext())
            {
                var element = context.Departments.Find(id);
                if (element == null)
                {
                    logger.LogDebug($"Department {id} not got");
                    return null;
                }
                else
                {
                    logger.LogInformation($"Department {element.Name} {element.ParentID} got");
                    return element;
                }
            }
        }

        public ICollection<Department> GetAll()
        {
            using (var context = new DepartmentContext())
            {
                return context.Departments.ToList();
                logger.LogInformation($"All departments got");
            }
        }

        public void Update(Department value)
        {
            using (var context = new DepartmentContext())
            {
                var oldElement = context.Departments.Where(d => d.Name == value.Name && d.ParentID == value.ParentID).FirstOrDefault();
                if (oldElement != null)
                {
                    context.Departments.Remove(oldElement);
                    context.Add(value);
                    context.SaveChanges();
                    logger.LogInformation($"Department {value.Name} {value.ParentID} updated");
                }
            }
        }
    }
}
