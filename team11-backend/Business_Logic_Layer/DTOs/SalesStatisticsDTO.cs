using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class SalesStatisticsDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int TicketsSold { get; set; }
        public float TotalIncome { get; set; }
    }
}
