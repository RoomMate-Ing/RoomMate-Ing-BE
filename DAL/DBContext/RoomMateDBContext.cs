using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class RoomMateDBContext : DbContext
    {
        public RoomMateDBContext(DbContextOptions<RoomMateDBContext> options) : base(options)
        {

        }
        internal DbSet<Roomate> RoomMate { get; set; }
        internal DbSet<HouseWork> HouseWork { get; set; }
        internal DbSet<WorkShift> WorkShift { get; set; }
        internal DbSet<House> House { get; set; }
        internal DbSet<Prize> Prize { get; set; }
        internal DbSet<Valutation> Valutation { get; set; }


    }
}
