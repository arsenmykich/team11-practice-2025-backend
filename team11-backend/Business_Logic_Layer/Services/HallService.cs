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
    public class HallService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HallService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<HallDTO> GetAllHalls()
        {
            var actors = _unitOfWork.HallRepository.Get();
            return _mapper.Map<IEnumerable<HallDTO>>(actors);
        }
        public HallDTO GetHallById(int id)
        {
            var hall = _unitOfWork.HallRepository.GetByID(id);
            return _mapper.Map<HallDTO>(hall);
        }
        public void AddHall(HallDTO HallDTO)
        {
            var hall = _mapper.Map<Hall>(HallDTO);
            _unitOfWork.HallRepository.Insert(hall);
            _unitOfWork.Save();
        }
        public void UpdateHall(HallDTO HallDTO)
        {
            var hall = _mapper.Map<Hall>(HallDTO);
            _unitOfWork.HallRepository.Update(hall);
            _unitOfWork.Save();
        }
        public void DeleteHall(int id)
        {
            _unitOfWork.HallRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
