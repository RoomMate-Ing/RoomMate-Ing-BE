using BLL_Service.DTOs;
using BLL_Service.Interface;
using DAL.Entities;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_Service.Service
{
    public class RoomateService : IRoomateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string phone_pattern = @"^(\+\d{1,3})?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
        private Regex phone_regex = new Regex(phone_pattern, RegexOptions.IgnoreCase);
        private const string email_pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private Regex email_regex = new Regex(email_pattern, RegexOptions.IgnoreCase);

        public RoomateService( IUnitOfWork unitOfWork) 
        {

            _unitOfWork = unitOfWork;

        }

        public async Task<ResponseDTO<Guid>> AddAsync(RoomateDTO roomateDTO)
        {
            try 
            {
               
                Roomate roomate = new Roomate() { ID = roomateDTO.ID, Name = roomateDTO.Name, Phone = roomateDTO.Phone };
                if (phone_regex.IsMatch(roomateDTO.Phone)) return new ResponseDTO<Guid> { StatusCode = 400, Success = false, ErrorMessage = "Phone attribute is in a wrong format"};      
                        
              
                var result = await _unitOfWork.RoomateRepository.AddAsync(roomate);
                //if (result == Guid.Empty) return new ResponseDTO<Guid> { Success = false, ErrorMessage = "Error: Roomate not saved" };
                return new ResponseDTO<Guid> { StatusCode = 200, Success = true, Data = result };
            }
            catch 
            {
                throw;
                
            }
            
        }
       

        public async Task<ResponseDTO<RoomateDTO>> FindAsync(Guid id)
        {
            try 
            {
                var roomateToSend = await _unitOfWork.RoomateRepository.FindAsync(id);
                RoomateDTO roomateToSendDTO = roomateToSend;
                if(roomateToSend is null) return new ResponseDTO<RoomateDTO>() { Success = false, StatusCode = 404, ErrorMessage = "Error: Roomate not Found"};
                return new ResponseDTO<RoomateDTO>() {  StatusCode = 200, Success = true, Data=roomateToSendDTO };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDTO<RoomateDTO>> FindAsync(string email)
        {
            try
            {
                var roomateToSend = await _unitOfWork.RoomateRepository.FindAsync(email);
                if (roomateToSend is null) return new ResponseDTO<RoomateDTO>() { Success = false, StatusCode = 404, ErrorMessage = "Error: Roomate not Found" };
                RoomateDTO roomateToSendDTO = roomateToSend;
                return new ResponseDTO<RoomateDTO>() { StatusCode = 200, Success = true, Data = roomateToSendDTO };
            }
            catch 
            {
                throw;
            }
        }

        public async Task<ResponseDTO<IEnumerable<RoomateDTO>>> GetAll()
        {
            try
            {
                var roomateList = await _unitOfWork.RoomateRepository.FindAllAsync();
                if (roomateList.Count == 0) return new ResponseDTO<IEnumerable<RoomateDTO>>() { Success = false, StatusCode = 404, ErrorMessage = "Error: No Roomates Found" };

                //Extended Method
                var roomateDTOList = roomateList.RoomateListConvertion();

                return new ResponseDTO<IEnumerable<RoomateDTO>>() { Success = true, StatusCode = 200, Data = roomateDTOList };

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
                var roomateTodelete = await _unitOfWork.RoomateRepository.FindAsync(id);
                _unitOfWork.RoomateRepository.
            }
            catch 
            {

            }
        }

        public async Task<ResponseDTO<bool>> UpdateAsync(RoomateDTO roomateDTO)
        {
            try 
            {
                Roomate roomate = roomateDTO.RoomateConvertion();
                if (await _unitOfWork.RoomateRepository.UpdateAsync(roomate)) return new ResponseDTO<bool>() { Success = true, StatusCode = 200 };
                else return new ResponseDTO<bool> { Success = false, StatusCode = 400, ErrorMessage = "Error: During saving the updates for this roomate" };
                
            }
            catch 
            {
                throw;
            }
        }
    }
}
