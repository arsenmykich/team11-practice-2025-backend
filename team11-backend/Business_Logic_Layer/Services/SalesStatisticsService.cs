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
    public class SalesStatisticsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SalesStatisticsService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<SalesStatisticsDTO> GetAllSalesStatistics()
        {
            var salesStatistics = _unitOfWork.SalesStatisticsRepository.Get();
            return _mapper.Map<IEnumerable<SalesStatisticsDTO>>(salesStatistics);
        }
        public SalesStatisticsDTO GetSalesStatisticsById(int id)
        {
            var salesStatistics = _unitOfWork.SalesStatisticsRepository.GetByID(id);
            return _mapper.Map<SalesStatisticsDTO>(salesStatistics);
        }
        public void AddSalesStatistics(SalesStatisticsDTO salesStatisticsDTO)
        {
            var salesStatistics = _mapper.Map<SalesStatistics>(salesStatisticsDTO);
            _unitOfWork.SalesStatisticsRepository.Insert(salesStatistics);
            _unitOfWork.Save();
        }
        public void UpdateSalesStatistics(SalesStatisticsDTO salesStatisticsDTO)
        {
            var salesStatistics = _mapper.Map<SalesStatistics>(salesStatisticsDTO);
            _unitOfWork.SalesStatisticsRepository.Update(salesStatistics);
            _unitOfWork.Save();
        }
        public void DeleteSalesStatistics(int id)
        {
            _unitOfWork.SalesStatisticsRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
