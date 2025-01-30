using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Services
{
    public class SessionService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SessionService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<SessionDTO> GetAllSessions()
        {
            var sessions = _unitOfWork.SessionRepository.Get();
            return _mapper.Map<IEnumerable<SessionDTO>>(sessions);
        }
        public SessionDTO GetSessionById(int id)
        {
            var session = _unitOfWork.SessionRepository.GetByID(id);
            return _mapper.Map<SessionDTO>(session);
        }
        public void AddSession(SessionDTO sessionDTO)
        {
            var session = _mapper.Map<Session>(sessionDTO);
            _unitOfWork.SessionRepository.Insert(session);
            _unitOfWork.Save();
        }
        public void UpdateSession(SessionDTO sessionDTO)
        {
            var session = _mapper.Map<Session>(sessionDTO);
            _unitOfWork.SessionRepository.Update(session);
            _unitOfWork.Save();
        }
        public void DeleteSession(int id)
        {
            _unitOfWork.SessionRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
