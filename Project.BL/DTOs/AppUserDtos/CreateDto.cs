using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AppUserDtos
{
    public class CreateDto
    {
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set;}
        public string Email { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string UserName { get; set;}
    }
}
