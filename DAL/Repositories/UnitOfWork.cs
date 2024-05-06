using DAL.DBContext;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoomMateDBContext _context;

        public IRoomateRepository RoomateRepository { get; private set; }
        public IHouseWorkRepository HouseWorkRepository { get; private set; }
        public IWorkShiftRepository WorkShiftRepository { get; private set; }

        public UnitOfWork(RoomMateDBContext context)
        {
            _context = context;
            RoomateRepository = new RoomateRepository(_context);
            HouseWorkRepository = new HouseWorkRepository(_context);
            WorkShiftRepository = new WorkShiftRepository(_context);
            
        }

        

        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) 
            {
                throw ex;
            }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
