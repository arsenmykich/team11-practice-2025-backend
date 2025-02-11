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
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorService _actorService;
        public ActorsController(ActorService actorService)
        {
            _actorService = actorService;
        }


        
        [HttpGet]
        public IActionResult Get()
        {
            var actors = _actorService.GetAllActors();
            return Ok(actors);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actor = _actorService.GetActorById(id);
            if (actor == null)
                return NotFound();
            return Ok(actor);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ActorDTO actorDTO)
        {
            if (actorDTO == null)
                return BadRequest();
            _actorService.AddActor(actorDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorDTO actorDTO)
        {
            if (actorDTO == null || id != actorDTO.Id)
                return BadRequest();
            _actorService.UpdateActor(actorDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _actorService.DeleteActor(id);
            return NoContent();
        }
    }
}
