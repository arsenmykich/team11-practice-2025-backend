using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class SalesStatistics
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public int SessionId { get; set; }
        public int TicketsSold { get; set; }
        public float TotalIncome { get; set; }
    }
}
