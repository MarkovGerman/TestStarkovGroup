using Importer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Repositories
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        int FindOnName(string name);
    }
}
