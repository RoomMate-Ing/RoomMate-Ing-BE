using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class House
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Prize> Prizes { get; set; }
        public IList<Roomate> Roomates { get; set; }

    }
}
