using Project.BL.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IAccountService
    {
        Task RegisterAsync(CreateDto createDto);
        Task LoginAsync(LoginDto loginDto);
        Task<bool> LogoutAsync();
    }
}
