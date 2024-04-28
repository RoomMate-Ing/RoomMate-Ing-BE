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
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
           
            
        }
    }
}
