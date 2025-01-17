using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BL.DTOs.AppUserDtos;
using Project.Core.Models;

namespace Project.BL.Profiles.AccountProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<LoginDto, AppUser>().ReverseMap();
        }
    }
}
