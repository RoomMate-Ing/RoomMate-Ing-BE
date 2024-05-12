using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Prize
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid HouseId { get; set; }
        public virtual House House { get; set; }

    }
}
