using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.DTOs
{
    public class RoomateDTO
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }


        public static implicit operator RoomateDTO(Roomate roomate)
        {
            RoomateDTO roomateDto = new RoomateDTO();
            roomateDto.ID = roomate.ID;
            roomateDto.Name = roomate.Name;
            roomateDto.Phone = roomate.Phone;
            roomateDto.Email = roomate.Email;
            return roomateDto;
        }
    }
}
