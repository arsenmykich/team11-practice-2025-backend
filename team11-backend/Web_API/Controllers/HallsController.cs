using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly HallService _hallService;
        public HallsController(HallService hallService)
        {
            _hallService = hallService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var halls = _hallService.GetAllHalls();
            return Ok(halls);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hall = _hallService.GetHallById(id);
            if (hall == null)
                return NotFound();
            return Ok(hall);
        }
        [HttpPost]
        public IActionResult Post([FromBody] HallDTO hallDTO)
        {
            if (hallDTO == null)
                return BadRequest();
            _hallService.AddHall(hallDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HallDTO hallDTO)
        {
            if (hallDTO == null || id != hallDTO.Id)
                return BadRequest();
            _hallService.UpdateHall(hallDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _hallService.DeleteHall(id);
            return NoContent();
        }
    }
}
