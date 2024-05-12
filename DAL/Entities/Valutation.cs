using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Valutation
    {
        public Guid Id { get; set; }
        public int Star { get; set; }
        public Guid WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; }

    }
}
