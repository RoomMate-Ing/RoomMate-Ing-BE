using DAL.DBContext;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RoomMateDBContext _context;
        private protected DbSet<T> _dbSet;
        public GenericRepository(RoomMateDBContext context)
        { 
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<Guid> AddAsync(T entity)
        {
            try 
            {
                _context.Attach(entity).State = EntityState.Added;

                if (_context.Entry(entity).State == EntityState.Added)
                {
                    await _context.SaveChangesAsync();
                    return GetEntityId(entity);
                }
                else 
                { 
                    throw new InvalidOperationException("Impossible to retrive the ID from th entity");
                }
            }
            catch 
            {
                throw;
            }
           
        }

        private Guid GetEntityId(T entity)
        {
            
            var property = entity.GetType().GetProperty("ID");
            if (property != null)
            {
                return (Guid)property.GetValue(entity);
            }
            else
            {
                throw new InvalidOperationException("Impossible to recover a ID property for this entity.");
            }
        }



        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var result = _dbSet.Update(entity);
            return (result.State == EntityState.Modified) ? true : false;
        }
    }
}
