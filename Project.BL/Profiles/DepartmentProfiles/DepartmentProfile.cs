using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BL.DTOs.DepartmentDtos;
using Project.Core.Models;

namespace Project.BL.Profiles.DepartmentProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentPostDto, Department>().ReverseMap();
            CreateMap<DepartmentPutDto, Department>().ReverseMap();
        }
    }
}
