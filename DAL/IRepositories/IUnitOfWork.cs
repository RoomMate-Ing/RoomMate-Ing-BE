using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IRepositories;

namespace DAL.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        IRoomateRepository RoomateRepository { get; }

        Task<int> Save();
        
        
    }
}
