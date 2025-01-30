using AutoMapper;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;

namespace Business_Logic_Layer.Services
{
    public class GenreService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GenreService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<GenreDTO> GetAllGenres()
        {
            var genres = _unitOfWork.GenreRepository.Get();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }
        public GenreDTO GetGenreById(int id)
        {
            var genre = _unitOfWork.GenreRepository.GetByID(id);
            return _mapper.Map<GenreDTO>(genre);
        }
        public void AddGenre(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Data_Access_Layer.Entities.Genre>(genreDTO);
            _unitOfWork.GenreRepository.Insert(genre);
            _unitOfWork.Save();
        }
        public void UpdateGenre(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Data_Access_Layer.Entities.Genre>(genreDTO);
            _unitOfWork.GenreRepository.Update(genre);
            _unitOfWork.Save();
        }
        public void DeleteGenre(int id)
        {
            _unitOfWork.GenreRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
