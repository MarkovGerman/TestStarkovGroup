using Importer.Entities;
using Microsoft.EntityFrameworkCore;


namespace Importer.Contexts
{
    public class JobTitleContext:DbContext
    {
        public DbSet<JobTitle> JobTitles { get; set; }

        public JobTitleContext() : base(new DbContextOptions<JobTitleContext>())
        { }

        public JobTitleContext(DbContextOptions<JobTitleContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlite("Data Source=jobtiles.db");
        //    optionsBuilder.UseSqlite(connectionString);
        //}
    }
}
