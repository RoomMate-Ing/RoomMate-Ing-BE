using BLL_Service.DTOs;
using BLL_Service.Interface;
using DAL.Entities;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL_Service.Service
{
    public class RoomateService : IRoomateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string phone_pattern = "^(\\+\\d{1,3})?\\s?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$\r\n";
        private Regex phone_regex = new(phone_pattern, RegexOptions.IgnoreCase);

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

        public Task<RoomateDTO> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomateDTO> Find(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomateDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(RoomateDTO roomateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
