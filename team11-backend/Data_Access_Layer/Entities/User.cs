using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } 
        public ICollection<Booking> Bookings { get; set; }
    }
}
