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
        public DateTime TimeStamp { get; set; }
        public string HouseWorkId { get; set; }
        public string RoomateId { get; set; }

        public static implicit operator WorkShiftDTO(WorkShift workshift)
        {
            WorkShiftDTO workshiftDto = new WorkShiftDTO();
            workshiftDto.Id = workshift.Id;
            workshiftDto.TimeStamp = workshift.TimeStamp;
            workshiftDto.RoomateId = workshift.HouseId.ToString();
            workshiftDto.HouseWorkId = workshift.HouseWorkId.ToString();
            return workshiftDto;
        }
    }
}
