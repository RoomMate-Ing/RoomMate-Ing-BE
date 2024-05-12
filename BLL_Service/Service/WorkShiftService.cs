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

        public async Task<ResponseDTO<WorkShiftDTO>> FindAsync(Guid id)
        {
            try 
            {
                var workshift = await _unitOfWork.WorkShiftRepository.FindAsync(id);
                if (workshift is null) return new ResponseDTO<WorkShiftDTO>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error finding The Workshift" };
                WorkShiftDTO workShiftDTO = workshift;
                return new ResponseDTO<WorkShiftDTO>() { Success = true, StatusCode = 200, Data = workShiftDTO };

            } 
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<IEnumerable<WorkShiftDTO>>> GetAll()
        {
            try 
            {
                var workshiftList = await _unitOfWork.WorkShiftRepository.FindAllAsync();
                if (workshiftList.Count == 0) return new ResponseDTO<IEnumerable<WorkShiftDTO>>() { Success = false, StatusCode = 404, ErrorMessage = "Error: Error no Workshift Found" };
                List<WorkShiftDTO> workShiftDTOList = workshiftList.ToWorkshift();
                return new ResponseDTO<IEnumerable<WorkShiftDTO>>() { Success = true, StatusCode = 200, Data = workShiftDTOList };
            }
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<bool>> RemoveAsync(Guid id)
        {
            try 
            {
                var workshift = await _unitOfWork.WorkShiftRepository.FindAsync(id);
                var res = await _unitOfWork.WorkShiftRepository.DeleteAsync(workshift);
                if (res) return new ResponseDTO<bool>() { Success = true, StatusCode = 200, Data = res };
                return new ResponseDTO<bool>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error Deleting Worshift" };
            } 
            catch 
            {
                throw;
            }
            
        }

        public async Task<ResponseDTO<bool>> UpdateAsync(WorkShiftDTO workshiftDTO)
        {
            try 
            {
                WorkShift workShift = workshiftDTO.WorkShiftConvertion();
                var res = await _unitOfWork.WorkShiftRepository.UpdateAsync(workShift);
                if(res) return new ResponseDTO<bool>() { Success = true, StatusCode = 200, Data=res };
                return new ResponseDTO<bool>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error Updating the Workshift" };
            }
            catch 
            {
                throw;
            }
        }
    }
}
