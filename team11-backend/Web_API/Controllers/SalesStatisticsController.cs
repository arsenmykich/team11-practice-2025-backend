using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesStatisticsController : ControllerBase
    {
        private readonly SalesStatisticsService _salesStatisticsService;
        public SalesStatisticsController(SalesStatisticsService salesStatisticsService)
        {
            _salesStatisticsService = salesStatisticsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var salesStatistics = _salesStatisticsService.GetAllSalesStatistics();
            return Ok(salesStatistics);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var salesStatistic = _salesStatisticsService.GetSalesStatisticsById(id);
            if (salesStatistic == null)
                return NotFound();
            return Ok(salesStatistic);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SalesStatisticsDTO salesStatisticDTO)
        {
            if (salesStatisticDTO == null)
                return BadRequest();
            _salesStatisticsService.AddSalesStatistics(salesStatisticDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalesStatisticsDTO salesStatisticDTO)
        {
            if (salesStatisticDTO == null || id != salesStatisticDTO.Id)
                return BadRequest();
            _salesStatisticsService.UpdateSalesStatistics(salesStatisticDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _salesStatisticsService.DeleteSalesStatistics(id);
            return NoContent();
        }
    }
}
