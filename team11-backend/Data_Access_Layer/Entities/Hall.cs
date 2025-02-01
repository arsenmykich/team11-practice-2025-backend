using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
