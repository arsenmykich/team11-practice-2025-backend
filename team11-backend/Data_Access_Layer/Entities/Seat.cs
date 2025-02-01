using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
