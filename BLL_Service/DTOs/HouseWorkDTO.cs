using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.DTOs
{
    public class HouseWorkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static implicit operator HouseWorkDTO(HouseWork housework)
        {
            HouseWorkDTO houseworkDto = new HouseWorkDTO();
            houseworkDto.Id = housework.Id;
            houseworkDto.Name = housework.Name;
            houseworkDto.Description = housework.Description;
           
            return houseworkDto;
        }
    }
}
