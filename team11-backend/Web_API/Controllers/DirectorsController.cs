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
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService _directorService;
        public DirectorsController(DirectorService directorService)
        {
            _directorService = directorService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var directors = _directorService.GetAllDirectors();
            return Ok(directors);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
                return NotFound();
            return Ok(director);
        }
        [HttpPost]
        public IActionResult Post([FromBody] DirectorDTO directorDTO)
        {
            if (directorDTO == null)
                return BadRequest();
            _directorService.AddDirector(directorDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DirectorDTO directorDTO)
        {
            if (directorDTO == null || id != directorDTO.Id)
                return BadRequest();
            _directorService.UpdateDirector(directorDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _directorService.DeleteDirector(id);
            return NoContent();
        }
    }
}
