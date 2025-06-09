using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Contract
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> AddAsync(T entity);
        IEnumerable<T>GetAll();
        Task<int> CommitAsync();
    }
}
