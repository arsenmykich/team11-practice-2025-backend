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
    //[Route("api/[controller]")]
    //[ApiController]
    //public class MoviesController : ControllerBase
    //{
    //    //private readonly CinemaContext _context;
    //    private readonly UnitOfWork _unitOfWork;

    //    //public MoviesController(CinemaContext context)
    //    //{
    //    //    _context = context;
    //    //}
    //    public MoviesController(UnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    // GET: api/Movies
    //    //[HttpGet]
    //    //public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    //    //{
    //    //    return await _context.Movies.ToListAsync();
    //    //}

    //    [HttpGet]
    //    public IActionResult Get()
    //    {
    //        var movies = _unitOfWork.MovieRepository.Get();
    //        return Ok(movies);
    //    }


    //    //// GET: api/Movies/5
    //    //[HttpGet("{id}")]
    //    //public async Task<ActionResult<Movie>> GetMovie(int id)
    //    //{
    //    //    var movie = await _context.Movies.FindAsync(id);

    //    //    if (movie == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    return movie;
    //    //}
    //    [HttpGet("{id}")]
    //    public IActionResult GetById(int id)
    //    {
    //        var movie = _unitOfWork.MovieRepository.GetByID(id);
    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(movie);
    //    }

    //    //// PUT: api/Movies/5
    //    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    //[HttpPut("{id}")]
    //    //public async Task<IActionResult> PutMovie(int id, Movie movie)
    //    //{
    //    //    if (id != movie.Id)
    //    //    {
    //    //        return BadRequest();
    //    //    }

    //    //    _context.Entry(movie).State = EntityState.Modified;

    //    //    try
    //    //    {
    //    //        await _context.SaveChangesAsync();
    //    //    }
    //    //    catch (DbUpdateConcurrencyException)
    //    //    {
    //    //        if (!MovieExists(id))
    //    //        {
    //    //            return NotFound();
    //    //        }
    //    //        else
    //    //        {
    //    //            throw;
    //    //        }
    //    //    }

    //    //    return NoContent();
    //    //}

    //    // POST: api/Movies
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    public IActionResult Put(int id, [FromBody] Movie movie)
    //    {
    //        if (movie == null || movie.Id != id)
    //        {
    //            return BadRequest();
    //        }

    //        _unitOfWork.MovieRepository.Update(movie);
    //        _unitOfWork.Save();

    //        return NoContent();
    //    }

    //    //[HttpPost]
    //    //public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    //    //{
    //    //    _context.Movies.Add(movie);
    //    //    await _context.SaveChangesAsync();

    //    //    return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
    //    //}
    //    [HttpPost]
    //    public IActionResult Post([FromBody] Movie movie)
    //    {
    //        if (movie == null)
    //        {
    //            return BadRequest();
    //        }

    //        _unitOfWork.MovieRepository.Insert(movie);
    //        _unitOfWork.Save();

    //        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    //    }

    //    //// DELETE: api/Movies/5
    //    //[HttpDelete("{id}")]
    //    //public async Task<IActionResult> DeleteMovie(int id)
    //    //{
    //    //    var movie = await _context.Movies.FindAsync(id);
    //    //    if (movie == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    _context.Movies.Remove(movie);
    //    //    await _context.SaveChangesAsync();

    //    //    return NoContent();
    //    //}

    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        _unitOfWork.MovieRepository.Delete(id);
    //        _unitOfWork.Save();

    //        return NoContent();
    //    }

    //    //***ADD IF EXISTS METHOD**//


    //    //private bool MovieExists(int id)
    //    //{
    //    //    return _context.Movies.Any(e => e.Id == id);
    //    //}
    //}

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
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
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
