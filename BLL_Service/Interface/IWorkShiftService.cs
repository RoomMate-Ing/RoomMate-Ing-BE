using BLL_Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.Interface
{
    public interface IWorkShiftService
    {
        Task<ResponseDTO<Guid>> AddAsync(WorkShiftDTO workshiftDTO);
        Task<ResponseDTO<bool>> RemoveAsync(Guid id);
        Task<ResponseDTO<bool>> UpdateAsync(WorkShiftDTO workshiftDTO);
        Task<ResponseDTO<WorkShiftDTO>> FindAsync(Guid id);
        Task<ResponseDTO<IEnumerable<WorkShiftDTO>>> GetAll();
    }
}
