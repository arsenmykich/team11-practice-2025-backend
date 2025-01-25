using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{

    public class Booking

    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public int SessionId { get; set; }
        public DateTime BookingDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public float Price { get; set; }
        public string ChairNumber { get; set; }
    }
}
