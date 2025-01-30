using AutoMapper;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Services
{
    public class RoleService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var roles = _unitOfWork.RoleRepository.Get();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }
        public RoleDTO GetRoleById(int id)
        {
            var role = _unitOfWork.RoleRepository.GetByID(id);
            return _mapper.Map<RoleDTO>(role);
        }
        public void AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            _unitOfWork.RoleRepository.Insert(role);
            _unitOfWork.Save();
        }
        public void UpdateRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            _unitOfWork.RoleRepository.Update(role);
            _unitOfWork.Save();
        }
        public void DeleteRole(int id)
        {
            _unitOfWork.RoleRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
