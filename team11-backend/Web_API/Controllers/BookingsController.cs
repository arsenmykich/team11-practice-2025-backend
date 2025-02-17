using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService _bookingService;
        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingRequest bookingRequest)
        {
            
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized("User not found");

            int userId = int.Parse(userIdClaim.Value);

            
            var createdBooking = await _bookingService.CreateBookingAsync(userId, bookingRequest);

            if (createdBooking == null)
                return BadRequest("Booking failed. Seat may be taken or incorrect hall.");

            return Ok(createdBooking);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null || id != bookingDTO.Id)
                return BadRequest();
            _bookingService.UpdateBooking(bookingDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var booking = _bookingService.GetBookingById(id);

            if (booking == null)
            {
                return NotFound(new { message = "Booking not found" });
            }

            _bookingService.DeleteBooking(id);
            return Ok(new { message = "Booking deleted successfully" });
        }


        [HttpGet("user-seats")]
        public async Task<IActionResult> GetUserSeats(int userId, int sessionId)
        {
            var seats = await _bookingService.GetUserBookedSeatsAsync(userId, sessionId);

            if (seats == null || seats.Count == 0)
                return NotFound("No seats found for this session.");

            return Ok(seats);
        }
        [HttpGet("all-seats")]
        public async Task<IActionResult> GetAllSeats(int sessionId)
        {
            var seats = await _bookingService.GetAllBookedSeatsAsync(sessionId);

            if (seats == null || seats.Count == 0)
                return NotFound("No seats found for this session.");

            return Ok(seats);
        }
    }
}
