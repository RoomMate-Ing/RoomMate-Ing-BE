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
    public class HouseWorkRepository : GenericRepository<HouseWork>, IHouseWorkRepository
    {
        public HouseWorkRepository(RoomMateDBContext context) : base(context)
        {
        }
    }
}
