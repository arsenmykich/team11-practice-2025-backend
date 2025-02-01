using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class HallDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
