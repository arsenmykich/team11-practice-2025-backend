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
    public class SessionsController : ControllerBase
    {
        private readonly SessionService _sessionService;
        public SessionsController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var sessions = _sessionService.GetAllSessions();
            return Ok(sessions);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var session = _sessionService.GetSessionById(id);
            if (session == null)
                return NotFound();
            return Ok(session);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SessionDTO sessionDTO)
        {
            if (sessionDTO == null)
                return BadRequest();
            _sessionService.AddSession(sessionDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SessionDTO sessionDTO)
        {
            if (sessionDTO == null || id != sessionDTO.Id)
                return BadRequest();
            _sessionService.UpdateSession(sessionDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sessionService.DeleteSession(id);
            return NoContent();
        }
        [HttpGet("{sessionId}/seats")]
        public async Task<IActionResult> GetSeatAvailability(int sessionId)
        {
            var result = await _sessionService.GetSeatAvailabilityAsync(sessionId);
            return Ok(new { availableSeats = result.availableSeats, reservedSeats = result.reservedSeats });
        }

    }
}
