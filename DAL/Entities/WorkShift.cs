using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class WorkShift
    {
        public Guid Id { get; set; }
        public DateOnly TimeStamp { get; set; }
        public Guid HouseWorkId { get; set; }
        public Guid RoomateId { get; set; }
        public virtual Roomate Roomate { get; set; }
        public virtual HouseWork HouseWork { get; set; }

        
    }
}
