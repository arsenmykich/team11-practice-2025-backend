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
            _unitOfWork.MovieRepository.Insert(movie);
            _unitOfWork.Save();
        }

        public void UpdateMovie(MovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
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
