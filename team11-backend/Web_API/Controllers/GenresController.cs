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

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreService.GetAllGenres();
            return Ok(genres);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null)
                return NotFound();
            return Ok(genre);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null)
                return BadRequest();
            _genreService.AddGenre(genreDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null || id != genreDTO.Id)
                return BadRequest();
            _genreService.UpdateGenre(genreDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var genre = _genreService.GetGenreById(id);

            if (genre == null)
            {
                return NotFound(new { message = "Genre not found" });
            }

            _genreService.DeleteGenre(id);
            return Ok(new { message = "Genre deleted successfully" });
        }
    }
}
