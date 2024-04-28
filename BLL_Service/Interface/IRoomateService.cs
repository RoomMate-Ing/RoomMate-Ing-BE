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
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(RoomateDTO roomateDTO);
        Task<RoomateDTO> Find(Guid id);
        Task<RoomateDTO> Find(string email);
        Task<IEnumerable<RoomateDTO>> GetAll();

    }
}
