using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;

namespace Business_Logic_Layer.Services
{
    public class BookingService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<BookingDTO> GetAllBookings()
        {
            var bookings = _unitOfWork.BookingRepository.Get();
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }
        public BookingDTO GetBookingById(int id)
        {
            var booking = _unitOfWork.BookingRepository.GetByID(id);
            return _mapper.Map<BookingDTO>(booking);
        }
        public void AddBooking(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            _unitOfWork.BookingRepository.Insert(booking);
            _unitOfWork.Save();
        }
        public void UpdateBooking(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            _unitOfWork.BookingRepository.Update(booking);
            _unitOfWork.Save();
        }
        public void DeleteBooking(int id)
        {
            _unitOfWork.BookingRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
