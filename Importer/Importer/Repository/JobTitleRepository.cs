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
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly ILogger<JobTitleRepository> logger;
        public JobTitleRepository(ILogger<JobTitleRepository> _logger)
        {
            logger = _logger;
        }

        public void Add(JobTitle value)
        {
            using (var context = new JobTitleContext())
            {
                context.JobTitles.Add(value);
                context.SaveChanges();
                logger.LogInformation($"JobTitle {value.Name} added");
            }
        }

        public JobTitle Get(int id)
        {
            using (var context = new JobTitleContext())
            {
                var element = context.JobTitles.Find(id);
                if (element == null)
                {
                    logger.LogDebug($"JobTitle {id} not got");
                    return element;
                }
                else
                {
                    logger.LogInformation($"JobTitle {element.Name} got");
                    return element;
                }
            }
        }

        public ICollection<JobTitle> GetAll()
        {
            using (var context = new JobTitleContext())
            {
                return context.JobTitles.ToList();
                logger.LogInformation($"All JobTitles got");
            }
        }

        public void Update(JobTitle value)
        {
            using (var context = new JobTitleContext())
            {
                var oldElement = context.JobTitles.Where(d => d.Name == value.Name).FirstOrDefault();
                if (oldElement != null)
                {
                    context.JobTitles.Remove(oldElement);
                    context.Add(value);
                    context.SaveChanges();
                    logger.LogInformation($"JobTitle {value.Name} updated");
                }
            }
        }
    }
}
