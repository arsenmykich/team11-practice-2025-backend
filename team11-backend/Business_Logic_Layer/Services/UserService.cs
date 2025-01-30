using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using AutoMapper;
using Business_Logic_Layer.DTOs;

namespace Business_Logic_Layer.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.Get();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public UserDTO GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);
            return _mapper.Map<UserDTO>(user);
        }
        public void AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
        }
        public void UpdateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }
        public void DeleteUser(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
