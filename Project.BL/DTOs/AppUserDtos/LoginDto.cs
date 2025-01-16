using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AppUserDtos
{
    public class LoginDto
    { 
        public string Password { get; set;}
        public string EmailOrUserName { get; set;}
    }
}
