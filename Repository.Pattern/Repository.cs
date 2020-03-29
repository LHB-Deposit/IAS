using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertGraphRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
