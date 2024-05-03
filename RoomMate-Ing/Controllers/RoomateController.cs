using BLL_Service.DTOs;
using BLL_Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RoomMate_Ing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomateController : ControllerBase
    {
        private readonly IRoomateService _roomateservice;
        public RoomateController(IRoomateService roomateservice)
        {
            _roomateservice = roomateservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomate(RoomateDTO roomateDTO)
        {
            try
            {
                var result = await _roomateservice.AddAsync(roomateDTO);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
        [HttpGet]
        public async Task<IActionResult> FindRoomateById(Guid roomateID)
        {
            try
            {
                var result = await _roomateservice.FindAsync(roomateID);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("FindRoomateByEmail")]
        public async Task<IActionResult> FindRoomateByEmail(string email)
        {
            try
            {
                var result = await _roomateservice.FindAsync(email);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var result = await _roomateservice.GetAll();
                return StatusCode(result.StatusCode, result.Data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomateDTO roomateDTO)
        {
            try 
            {

                var result = await _roomateservice.UpdateAsync(roomateDTO);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid guid)
        {
            try 
            {
                var result = await _roomateservice.RemoveAsync(guid);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch( Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
