using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
