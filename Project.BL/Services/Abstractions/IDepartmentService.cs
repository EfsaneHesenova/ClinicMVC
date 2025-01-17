using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.BL.DTOs.DepartmentDtos;
using Project.Core.Models;

namespace Project.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartmentAsync(DepartmentPostDto dto);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<bool> UpdateDepartmentAsync(DepartmentPutDto dto);
        Task<ICollection<Department>> GetAllDepartmentAsync();
        Task<Department> GetByIdDepartmentAsync(int id);
        Task<bool> RestoreDepartmentAsync(int id);
        Task<bool> SoftDelete(int id);
    }
}
