using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.DTOs
{
    public class WorkShiftDTO
    {
        public Guid Id { get; set; }
        public DateOnly TimeStamp { get; set; }
        public Guid HouseWorkId { get; set; }
        public Guid RoomateId { get; set; }

        public static implicit operator WorkShiftDTO(WorkShift workshift)
        {
            WorkShiftDTO workshiftDto = new WorkShiftDTO();
            workshiftDto.Id = workshift.Id;
            workshiftDto.TimeStamp = workshift.TimeStamp;
            workshiftDto.RoomateId = workshift.RoomateId;
            workshiftDto.HouseWorkId = workshift.HouseWorkId;
            return workshiftDto;
        }
    }
}
