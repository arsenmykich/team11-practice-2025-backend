using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public DateTime BookingDate { get; set; }
        public int UserId { get; set; }
        public float Price { get; set; }
        public int SeatId { get; set; }
    }
}
