﻿using BLL_Service.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.ExtensionMethods
{
    public static class ListExstensions
    {
        public static List<RoomateDTO> RoomateListConvertion(this List<Roomate> roomates)
        {
            List<RoomateDTO> roomatesDto = [];

            foreach (var roomate in roomates)
            {
                roomatesDto.Add(roomate);
            }

            return roomatesDto;
        }
        public static List<HouseWorkDTO> HouseWorkListConvertion(this List<HouseWork> houseworks)
        {
            List<HouseWorkDTO> houseworksDto = [];

            foreach (var housework in houseworks)
            {
                houseworksDto.Add(housework);
            }

            return houseworksDto;
        }
    }
}