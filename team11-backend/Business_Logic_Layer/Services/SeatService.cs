using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class SeatService
    {
        private UnitOfWork _unitOfWork;
        private IMapper mapper;
        public SeatService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<SeatDTO> GetAllSeats()
        {
            var seats = _unitOfWork.SeatRepository.Get();
            return mapper.Map<IEnumerable<SeatDTO>>(seats);
        }
        public SeatDTO GetSeatsById(int id)
        {
            var seat = _unitOfWork.SeatRepository.GetByID(id);
            return mapper.Map<SeatDTO>(seat);
        }
        public void AddSeat(SeatDTO seatDTO)
        {
            var seat = mapper.Map<Data_Access_Layer.Entities.Seat>(seatDTO);
            _unitOfWork.SeatRepository.Insert(seat);
            _unitOfWork.Save();
        }
        public void UpdateSeat(SeatDTO seatDTO)
        {
            var seat = mapper.Map<Data_Access_Layer.Entities.Seat>(seatDTO);
            _unitOfWork.SeatRepository.Update(seat);
            _unitOfWork.Save();
        }
        public void DeleteSeat(int id)
        {
            _unitOfWork.SeatRepository.Delete(id);
            _unitOfWork.Save();
        }

    }
}
