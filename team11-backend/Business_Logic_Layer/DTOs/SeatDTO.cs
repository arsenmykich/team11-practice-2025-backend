using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HallId { get; set; }
    }
}
