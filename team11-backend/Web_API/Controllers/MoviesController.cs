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
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var movie = _movieService.GetMovieById(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}
            //return Ok(movie);
            if(_movieService.GetMovieById(id) == null)
                return NotFound();
            return Ok(_movieService.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovieDTO movieDTO)
        {
            if (movieDTO == null)
            {
                return BadRequest();
            }

            _movieService.AddMovie(movieDTO);
            return CreatedAtAction(nameof(GetById), new { id = movieDTO.Id }, movieDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovieDTO movieDTO)
        {
            if (movieDTO == null || movieDTO.Id != id)
            {
                return BadRequest();
            }

            _movieService.UpdateMovie(movieDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}
