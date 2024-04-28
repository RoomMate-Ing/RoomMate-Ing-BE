using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FindAsync(Guid id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<Guid> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
