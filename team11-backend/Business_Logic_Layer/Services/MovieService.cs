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
            var movies = _unitOfWork.MovieRepository.Get(includeProperties: "MovieGenres.Genre,MovieActors.Actor");

            return movies.Select(movie => new MovieDTO
            {
                Id = movie.Id,
                FilmName = movie.FilmName,
                Description = movie.Description,
                Trailer = movie.Trailer,
                Duration = movie.Duration,
                AgeRating = movie.AgeRating,
                ReleaseDate = movie.ReleaseDate,
                PosterPath = movie.PosterPath,
                BackgroundImagePath = movie.BackgroundImagePath,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                DirectorId = movie.DirectorId,
                Genres = movie.MovieGenres.Select(mg => mg.GenreId).ToList(),
                Actors = movie.MovieActors.Select(ma => ma.ActorId).ToList()
            }).ToList();
        }

        public MovieDTO GetMovieById(int id)
        {
            //var movie = _unitOfWork.MovieRepository.GetByID(id);
            //return _mapper.Map<MovieDTO>(movie);
            var movie = _unitOfWork.MovieRepository.Get(
                filter: m => m.Id == id,
                includeProperties: "MovieGenres.Genre,MovieActors.Actor"
                ).FirstOrDefault();

            if (movie == null) return null;

            return new MovieDTO
            {
                Id = movie.Id,
                FilmName = movie.FilmName,
                Description = movie.Description,
                Trailer = movie.Trailer,
                Duration = movie.Duration,
                AgeRating = movie.AgeRating,
                ReleaseDate = movie.ReleaseDate,
                PosterPath = movie.PosterPath,
                BackgroundImagePath = movie.BackgroundImagePath,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                DirectorId = movie.DirectorId,
                Genres = movie.MovieGenres.Select(mg => mg.GenreId).ToList(),
                Actors = movie.MovieActors.Select(ma => ma.ActorId).ToList()
            };
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);

            // Fetch genres and actors from DB
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
            var existingMovie = _unitOfWork.MovieRepository.GetByID(movieDTO.Id);
            if (existingMovie == null) return;

            _mapper.Map(movieDTO, existingMovie);

            // Clear previous relationships
            existingMovie.MovieGenres.Clear();
            existingMovie.MovieActors.Clear();

            // Add new relationships
            existingMovie.MovieGenres = movieDTO.Genres
                .Select(genreId => new MovieGenre { MovieId = existingMovie.Id, GenreId = genreId })
                .ToList();

            existingMovie.MovieActors = movieDTO.Actors
                .Select(actorId => new MovieActor { MovieId = existingMovie.Id, ActorId = actorId })
                .ToList();

            _unitOfWork.MovieRepository.Update(existingMovie);
            _unitOfWork.Save();
        }


        public void DeleteMovie(int id)
        {
            _unitOfWork.MovieRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
