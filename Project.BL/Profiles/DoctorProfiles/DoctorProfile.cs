using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BL.DTOs.DoctorDtos;
using Project.Core.Models;

namespace Project.BL.Profiles.DoctorProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        { 
            CreateMap<DoctorPutDto, Doctor>().ReverseMap();
            CreateMap<DoctorPostDto, Doctor>().ReverseMap();
            
        }
    }
}
