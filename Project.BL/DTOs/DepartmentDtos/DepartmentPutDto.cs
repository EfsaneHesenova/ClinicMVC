using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.BL.DTOs.DepartmentDtos
{
    public class DepartmentPutDto
    {
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
