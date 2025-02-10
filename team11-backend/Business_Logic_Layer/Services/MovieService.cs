using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class MovieService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MovieDTO> GetAllMovies()
        {
            var movies = _unitOfWork.MovieRepository.Get();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public MovieDTO GetMovieById(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetByID(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);

            movie.MovieGenres = movieDTO.Genres
                .Select(genreId => new MovieGenre { GenreId = genreId })
                .ToList();

            movie.MovieActors = movieDTO.Actors
                .Select(actorId => new MovieActor { ActorId = actorId })
                .ToList();

            _unitOfWork.MovieRepository.Insert(movie);
            _unitOfWork.Save();
        }


        public void UpdateMovie(MovieDTO movieDTO)
        {
            var movie = _unitOfWork.MovieRepository.Get(
                filter: m => m.Id == movieDTO.Id,
                includeProperties: "MovieGenres,MovieActors"
            ).FirstOrDefault();

            if (movie == null) return;

            movie.FilmName = movieDTO.FilmName;
            movie.Description = movieDTO.Description;
            movie.Trailer = movieDTO.Trailer;
            movie.Duration = movieDTO.Duration;
            movie.AgeRating = movieDTO.AgeRating;
            movie.ReleaseDate = movieDTO.ReleaseDate;
            movie.PosterPath = movieDTO.PosterPath;
            movie.BackgroundImagePath = movieDTO.BackgroundImagePath;
            movie.VoteAverage = movieDTO.VoteAverage;
            movie.VoteCount = movieDTO.VoteCount;
            movie.DirectorId = movieDTO.DirectorId;

            movie.MovieGenres = movieDTO.Genres.Select(gId => new MovieGenre { MovieId = movie.Id, GenreId = gId }).ToList();
            movie.MovieActors = movieDTO.Actors.Select(aId => new MovieActor { MovieId = movie.Id, ActorId = aId }).ToList();

            _unitOfWork.MovieRepository.Update(movie);
            _unitOfWork.Save();
        }



        public void DeleteMovie(int id)
        {
            _unitOfWork.MovieRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
