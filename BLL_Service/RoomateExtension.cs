using BLL_Service.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service
{
    public static class RoomateExtension
    {
        public static Roomate RoomateConvertion(this RoomateDTO roomateDTO)
        {
            Roomate roomate = new Roomate();
            roomate.ID = roomateDTO.ID;
            roomate.Name = roomateDTO.Name;
            roomate.Phone = roomateDTO.Phone;
            roomate.Email = roomateDTO.Email;
            return roomate;
        }
    }
}
