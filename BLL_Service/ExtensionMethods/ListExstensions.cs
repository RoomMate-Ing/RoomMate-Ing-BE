using BLL_Service.DTOs;
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
        public static List<RoomateDTO> ToRoomate(this List<Roomate> roomates)
        {
            List<RoomateDTO> roomatesDto = [];

            foreach (var roomate in roomates)
            {
                roomatesDto.Add(roomate);
            }

            return roomatesDto;
        }
        public static List<HouseWorkDTO> ToHouseWork(this List<HouseWork> houseworks)
        {
            List<HouseWorkDTO> houseworksDto = [];

            foreach (var housework in houseworks)
            {
                houseworksDto.Add(housework);
            }

            return houseworksDto;
        }
        public static List<WorkShiftDTO> ToWorkshift(this List<WorkShift> workShifts)
        {

            List<WorkShiftDTO> workShiftDTOList = [];
            foreach (var workshift in workShifts)
            {
                workShiftDTOList.Add(workshift);
            }
            return workShiftDTOList;
        }
    }
}
