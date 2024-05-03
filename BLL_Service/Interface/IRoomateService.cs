using BLL_Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.Interface
{
    public interface IRoomateService
    {
        Task<ResponseDTO<Guid>> AddAsync(RoomateDTO roomateDTO);
        Task<ResponseDTO<bool>> RemoveAsync(Guid id);
        Task<ResponseDTO<bool>> UpdateAsync(RoomateDTO roomateDTO);
        Task<ResponseDTO<RoomateDTO>> FindAsync(Guid id);
        Task<ResponseDTO<RoomateDTO>> FindAsync(string email);
        Task<ResponseDTO<IEnumerable<RoomateDTO>>> GetAll();

    }
}
