using BLL_Service.DTOs;
using BLL_Service.ExtensionMethods;
using BLL_Service.Interface;
using DAL.Entities;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.Service
{
    public class HouseWorkService : IHouseWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public HouseWorkService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }   
        public async Task<ResponseDTO<Guid>> AddAsync(HouseWorkDTO houseworkDTO)
        {
            try 
            {
                HouseWork housework = houseworkDTO.HouseworkConvertion();
                var res = await _unitOfWork.HouseWorkRepository.AddAsync(housework);
                if (res == Guid.Empty) return new ResponseDTO<Guid>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error Saving HouseWorkEntity" };
                return new ResponseDTO<Guid>() { Success = true, StatusCode = 200, Data = res };

            }
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<HouseWorkDTO>> FindAsync(Guid id)
        {
            try 
            {
                var housework = await _unitOfWork.HouseWorkRepository.FindAsync(id);
                if (housework is null) return new ResponseDTO<HouseWorkDTO>() { Success = false, StatusCode = 404, ErrorMessage = "Error, housework not found" };
                var houseworkDto = housework;
                return new ResponseDTO<HouseWorkDTO>() { Success = true, StatusCode = 200, Data = houseworkDto };
            }
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<IEnumerable<HouseWorkDTO>>> GetAll()
        {
            try 
            { 
                var houseworkList = await _unitOfWork.HouseWorkRepository.FindAllAsync();
                if (houseworkList.Count == 0) return new ResponseDTO<IEnumerable<HouseWorkDTO>>() { Success = false, StatusCode = 404, ErrorMessage = "Error: No Houseworks Found" };
                var houseworkDtoList = houseworkList.HouseWorkListConvertion();
                return new ResponseDTO<IEnumerable<HouseWorkDTO>>() { Success = true, StatusCode = 200, Data = houseworkDtoList };
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
               
                var houseWorkToDelete = await _unitOfWork.HouseWorkRepository.FindAsync(id);
                var res = await _unitOfWork.HouseWorkRepository.DeleteAsync(houseWorkToDelete);
                if (res) return new ResponseDTO<bool>() { Success = true, StatusCode = 200, Data = res };
                return new ResponseDTO<bool>() { Success = false, StatusCode = 404, ErrorMessage = "Error: Error deleting Housework" };
            }
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<bool>> UpdateAsync(HouseWorkDTO houseworkDTO)
        {
            try
            {
                var housework = houseworkDTO.HouseworkConvertion();
                var res = await _unitOfWork.HouseWorkRepository.UpdateAsync(housework);
                if (res) return new ResponseDTO<bool>() { Success = true, StatusCode = 200, Data = res };
                return new ResponseDTO<bool>() { Success = false, StatusCode = 400, ErrorMessage = "Error: Error suring Updating Housework" };
            }
            catch
            {
                throw;
            }
        } 
    }
}
