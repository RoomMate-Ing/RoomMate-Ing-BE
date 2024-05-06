using BLL_Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.Interface
{
    public interface IHouseWorkService
    {
        Task<ResponseDTO<Guid>> AddAsync(HouseWorkDTO roomateDTO);
        Task<ResponseDTO<bool>> RemoveAsync(Guid id);
        Task<ResponseDTO<bool>> UpdateAsync(HouseWorkDTO roomateDTO);
        Task<ResponseDTO<HouseWorkDTO>> FindAsync(Guid id);
        Task<ResponseDTO<IEnumerable<HouseWorkDTO>>> GetAll();
    }
}
