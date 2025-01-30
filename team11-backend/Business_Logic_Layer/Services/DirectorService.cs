using AutoMapper;
using Data_Access_Layer.Repositories;
using Business_Logic_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class DirectorService
    {
        private UnitOfWork _unitOfWork;
        private IMapper mapper;
        public DirectorService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<DirectorDTO> GetAllDirectors()
        {
            var directors = _unitOfWork.DirectorRepository.Get();
            return mapper.Map<IEnumerable<DirectorDTO>>(directors);
        }
        public DirectorDTO GetDirectorById(int id)
        {
            var director = _unitOfWork.DirectorRepository.GetByID(id);
            return mapper.Map<DirectorDTO>(director);
        }
        public void AddDirector(DirectorDTO directorDTO)
        {
            var director = mapper.Map<Data_Access_Layer.Entities.Director>(directorDTO);
            _unitOfWork.DirectorRepository.Insert(director);
            _unitOfWork.Save();
        }
        public void UpdateDirector(DirectorDTO directorDTO)
        {
            var director = mapper.Map<Data_Access_Layer.Entities.Director>(directorDTO);
            _unitOfWork.DirectorRepository.Update(director);
            _unitOfWork.Save();
        }
        public void DeleteDirector(int id)
        {
            _unitOfWork.DirectorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
