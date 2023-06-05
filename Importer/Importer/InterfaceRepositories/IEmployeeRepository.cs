using Importer.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Repositories
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        int FindOnName(string name);
    }
}
