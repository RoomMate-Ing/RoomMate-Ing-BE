using BLL_Service.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.ExtensionMethods
{
    public static class WorkShiftExtension
    {
        public static WorkShift WorkShiftConvertion(this WorkShiftDTO workShiftDTO)
        {
            WorkShift workShift = new WorkShift();
            workShift.Id = workShiftDTO.Id;
            workShift.TimeStamp = workShiftDTO.TimeStamp;
            workShift.RoomateId = workShiftDTO.RoomateId;
            workShift.HouseWorkId = workShift.HouseWorkId;
           

            return workShift;
        }
    }
}
