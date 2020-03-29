using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pattern
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertOrUpdateGraph(T entity);
        void InsertGraphRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}
