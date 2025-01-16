using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.DoctorDtos
{
    public class DoctorPutDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int DepartmentId { get; set; }
        public int Id { get; set; }
    }
}
