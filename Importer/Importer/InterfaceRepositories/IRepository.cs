using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Repositories
{
    public interface IRepository<TValue>
    {
        void Add(TValue value);
        void Update(TValue value);
        TValue Get(int id);
        ICollection<TValue> GetAll();
    }
}
