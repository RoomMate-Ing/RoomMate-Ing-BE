using BLL_Service.DTOs;
using BLL_Service.Interface;
using BLL_Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace RoomMate_Ing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly IWorkShiftService _workshiftservice;
        public WorkShiftController(IWorkShiftService workShiftService) 
        {
            _workshiftservice = workShiftService;
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkShift(WorkShiftDTO workshiftDTO)
        {
            try
            {
                var result = await _workshiftservice.AddAsync(workshiftDTO);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetWorkShift(Guid id)
        {
            try
            {
                var result = await _workshiftservice.FindAsync(id);
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
                var result = await _workshiftservice.GetAll();
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                var result = await _workshiftservice.RemoveAsync(id);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(WorkShiftDTO workshiftDto)
        {
            try
            {
                var result = await _workshiftservice.UpdateAsync(workshiftDto);
                return StatusCode(result.StatusCode, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
