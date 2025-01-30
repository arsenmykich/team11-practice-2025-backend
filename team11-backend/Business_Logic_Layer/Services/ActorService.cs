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
    public class ActorService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActorService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ActorDTO> GetAllActors()
        {
            var actors = _unitOfWork.ActorRepository.Get();
            return _mapper.Map<IEnumerable<ActorDTO>>(actors);
        }
        public ActorDTO GetActorById(int id)
        {
            var actor = _unitOfWork.ActorRepository.GetByID(id);
            return _mapper.Map<ActorDTO>(actor);
        }
        public void AddActor(ActorDTO actorDTO)
        {
            var actor = _mapper.Map<Actor>(actorDTO);
            _unitOfWork.ActorRepository.Insert(actor);
            _unitOfWork.Save();
        }
        public void UpdateActor(ActorDTO actorDTO)
        {
            var actor = _mapper.Map<Actor>(actorDTO);
            _unitOfWork.ActorRepository.Update(actor);
            _unitOfWork.Save();
        }
        public void DeleteActor(int id)
        {
            _unitOfWork.ActorRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
