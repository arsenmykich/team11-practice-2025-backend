using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public ICollection<SalesStatistics> SalesStatistics { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float Price { get; set; }
        public string Hall { get; set; }

    }
}
