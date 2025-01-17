using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BL.DTOs.DepartmentDtos;
using Project.BL.Services.Abstractions;
using Project.Core.Models;
using Project.DAL.Repositories.Abstractions;

namespace Project.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _departmentRepo = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateDepartmentAsync(DepartmentPostDto dto)
        {
            Department department = _mapper.Map<Department>(dto);
            await _departmentRepo.CreateAsync(department);
            int rows = await _departmentRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {

            if (!await _departmentRepo.IsExistAsync(id)) { throw new Exception("Something went wrong"); }
            Department department = await _departmentRepo.GetByIdAsync(id);
            if (department is null)
            {
                throw new Exception("Something went wrong");
            }
            _departmentRepo.Delete(department);
            return true;
        }

        public async Task<ICollection<Department>> GetAllDepartmentAsync()
        {

            var departments = await _departmentRepo.GetAllAsync();
            if (departments is null)
            {
                throw new Exception("Something went wrong");
            }
            ICollection<Department> entity = _mapper.Map<ICollection<Department>>(departments);
            return entity;
        }

        public async Task<Department> GetByIdDepartmentAsync(int id)
        {
            if (!await _departmentRepo.IsExistAsync(id)) { throw new Exception("Something went wrong"); }
            Department department = await _departmentRepo.GetByIdAsync(id);
            if (department is null)
            {
                throw new Exception("Something went wrong");
            }
            return department;
        }

        public async Task<bool> RestoreDepartmentAsync(int id)
        {

            Department department = await _departmentRepo.GetSingleByCondition(x => x.Id == id && x.IsDeleted);
            if (department is null) { throw new Exception("Something went wrong"); }
            department.IsDeleted = false;
            _departmentRepo.Update(department);
            int rows = await _departmentRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }

        public async Task<bool> SoftDelete(int id)
        {

            Department department = await _departmentRepo.GetSingleByCondition(x => x.Id == id && !x.IsDeleted);
            if (department is null) { throw new Exception("Something went wrong"); }
            department.IsDeleted = true;
            _departmentRepo.Update(department);
            int rows = await _departmentRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }

        public async Task<bool> UpdateDepartmentAsync(DepartmentPutDto dto)
        {
            if (!await _departmentRepo.IsExistAsync(dto.Id)) { throw new Exception("Something went wrong"); }
            Department department = await _departmentRepo.GetByIdAsync(dto.Id);
            if (department is null)
            {
                throw new Exception("Something went wrong");
            }
            _departmentRepo.Update(department);
            int rows = await _departmentRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }
    }
}
