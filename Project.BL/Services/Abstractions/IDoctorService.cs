using Project.BL.DTOs.DoctorDtos;
using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        Task<bool> CreateDoctorAsync(DoctorPostDto dto);
        Task<bool> DeleteDoctorAsync(int id);
        Task<bool> UpdateDoctorAsync(DoctorPutDto dto);
        Task<ICollection<Doctor>> GetAllDoctorAsync();
        Task<Doctor> GetByIdDoctorAsync(int id);
        Task<bool> RestoreDoctorAsync(int id);
        Task<bool> SoftDelete( int id);
    }
}
