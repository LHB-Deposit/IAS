using Repository.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public abstract class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> repository;

        protected Service(IRepository<T> repository) { this.repository = repository; }

        public void Delete(object id)
        {
            repository.Delete(id);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
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

        public IQueryable<T> Queryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
