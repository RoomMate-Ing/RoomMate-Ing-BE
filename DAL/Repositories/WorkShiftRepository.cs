using DAL.DBContext;
using DAL.Entities;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WorkShiftRepository : GenericRepository<WorkShift>, IWorkShiftRepository
    {
        public WorkShiftRepository(RoomMateDBContext context) : base(context)
        {

        }

    }
}
