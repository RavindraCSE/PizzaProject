using ePizzaHub.Infrastructure.Models;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // This will interact with the db context
        protected PB655Context _dbContext;
        public GenericRepository(PB655Context dbContext)
        {
            _dbContext = dbContext;
        }
        //public void Add(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //}

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query.ToList();
        }
    }
}
