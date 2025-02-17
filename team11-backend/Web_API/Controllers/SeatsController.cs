using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly SeatService _seatService;
        public SeatsController(SeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var seats = _seatService.GetAllSeats();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var seat = _seatService.GetSeatsById(id);
            if (seat == null)
                return NotFound();
            return Ok(seat);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] SeatDTO seatDTO)
        {
            if (seatDTO == null)
                return BadRequest();
            _seatService.AddSeat(seatDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] SeatDTO seatDTO)
        {
            if (seatDTO == null || id != seatDTO.Id)
                return BadRequest();
            _seatService.UpdateSeat(seatDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var seat = _seatService.GetSeatsById(id);

            if (seat == null)
            {
                return NotFound(new { message = "Seat not found" });
            }

            _seatService.DeleteSeat(id);
            return Ok(new { message = "Seat deleted successfully" });
        }
    }
}
