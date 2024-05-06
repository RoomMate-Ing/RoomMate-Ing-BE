using BLL_Service.DTOs;
using BLL_Service.ExtensionMethods;
using BLL_Service.Interface;
using DAL.Entities;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.Service
{
    public class WorkShiftService : IWorkShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkShiftService(IUnitOfWork unitOfWork) 
        {
        
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseDTO<Guid>> AddAsync(WorkShiftDTO workShiftDTO)
        {
            try
            {
                WorkShift workShift = workShiftDTO.WorkShiftConvertion();
                var res = await _unitOfWork.WorkShiftRepository.AddAsync(workShift);
                if (res == Guid.Empty) return new ResponseDTO<Guid>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error During Error Message" };
                return new ResponseDTO<Guid> { Success = true,Data = res, StatusCode = 200 };
            }
            catch 
            {
                throw;
            }
        }

        public Task<ResponseDTO<WorkShiftDTO>> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<WorkShiftDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> UpdateAsync(WorkShiftDTO workshiftDTO)
        {
            throw new NotImplementedException();
        }
    }
}
