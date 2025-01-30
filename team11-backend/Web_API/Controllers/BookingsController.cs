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
        [HttpPost]
        public IActionResult Post([FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null)
                return BadRequest();
            _bookingService.AddBooking(bookingDTO);
            return Ok();
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
        public IActionResult Delete(int id)
        {
            _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
