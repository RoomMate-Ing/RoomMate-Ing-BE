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
        public DateTime TimeStamp { get; set; }
        public Guid HouseWorkId { get; set; }
        public Guid HouseId { get; set; }
        public virtual House House { get; set; }
        public virtual HouseWork HouseWork { get; set; }
        public IList<Valutation> valutations { get; set; }

        
    }
}
