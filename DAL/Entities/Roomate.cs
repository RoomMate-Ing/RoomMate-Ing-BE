﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Roomate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid HouseId { get; set; }
        public virtual House House { get; set; }
        //TO DO Administrator settings, vedere su Registry
        
    }
}
