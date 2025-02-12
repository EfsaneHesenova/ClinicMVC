﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Project.BL.DTOs.AppUserDtos;
using Project.BL.Services.Abstractions;
using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> LoginAsync(LoginDto loginDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginDto.EmailOrUserName);
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(loginDto.EmailOrUserName);
                if (user is null)
                {
                    throw new Exception("Something went wrong");
                }
            }
            var entity = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.IsPersistant, false);
            if (!entity.Succeeded) { throw new Exception("Something went wrong"); }
            return entity.Succeeded;
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(CreateDto createDto)
        {
            AppUser user = _mapper.Map<AppUser>(createDto);
            var result = await _userManager.CreateAsync(user, createDto.PassWord);
            if(!result.Succeeded) { throw new Exception("Something went wrong"); }
            return result.Succeeded;

        }
    }
}
