using BLL_Service.DTOs;
using BLL_Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RoomMate_Ing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseWorkController : ControllerBase
    {
        private readonly IHouseWorkService _houseWorkService;

        public HouseWorkController (IHouseWorkService houseWorkService)
        {
            _houseWorkService = houseWorkService;
        }
        [HttpPost]
        public async Task<IActionResult> AddHouseWork(HouseWorkDTO houseWorkDTO)
        {
            try
            {
                var result = await _houseWorkService.AddAsync(houseWorkDTO);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }



        }
        [HttpGet]
        public async Task<IActionResult> GetHouseWork(Guid id)
        {
            try 
            {
                var result = await _houseWorkService.FindAsync(id);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _houseWorkService.GetAll();
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> remove(Guid id)
        {
            try
            {
                var result = await _houseWorkService.RemoveAsync(id);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(HouseWorkDTO houseworDto)
        {
            try
            {
                var result = await _houseWorkService.UpdateAsync(houseworDto);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
