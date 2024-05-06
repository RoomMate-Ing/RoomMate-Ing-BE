using BLL_Service.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.ExtensionMethods
{
    public static class HouseWorkExtension
    {
        public static HouseWork HouseworkConvertion(this HouseWorkDTO houseworkDTO)
        {
            HouseWork housework = new HouseWork();
            housework.Id = houseworkDTO.Id;
            housework.Name = houseworkDTO.Name;
            housework.Description = houseworkDTO.Description;
               
            return housework;
        }
    }
}
