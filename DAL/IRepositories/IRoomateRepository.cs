using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRoomateRepository : IGenericRepository<Roomate>
    {
        Task<Roomate> FindAsync(string email);
    }
}
