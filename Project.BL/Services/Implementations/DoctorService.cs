using AutoMapper;
using Project.BL.DTOs.DoctorDtos;
using Project.BL.Services.Abstractions;
using Project.Core.Models;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateDoctorAsync(DoctorPostDto dto)
        {
            Doctor doctor = _mapper.Map<Doctor>(dto);
            await _doctorRepo.CreateAsync(doctor);
            int rows = await _doctorRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            if (!await _doctorRepo.IsExistAsync(id)) { throw new Exception("Something went wrong"); }
            Doctor doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor is null)
            {
                throw new Exception("Something went wrong");
            }
            _doctorRepo.Delete(doctor);
            return true;
        }

        public async Task<ICollection<Doctor>> GetAllDoctorAsync()
        {
          var doctors = await _doctorRepo.GetAllAsync();
            if(doctors is  null)
            {
                throw new Exception("Something went wrong");
            }
            ICollection<Doctor> entity = _mapper.Map<ICollection<Doctor>>(doctors);
            return entity;
            

        }

        public async Task<Doctor> GetByIdDoctorAsync(int id)
        {
            if (!await _doctorRepo.IsExistAsync(id)) { throw new Exception("Something went wrong"); }
            Doctor doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor is null)
            {
                throw new Exception("Something went wrong");
            }
            return doctor;
        }

        public async Task<bool> RestoreDoctorAsync(int id)
        {
            Doctor doctor = await _doctorRepo.GetSingleByCondition(x => x.Id == id && x.IsDeleted);
            if (doctor is null) { throw new Exception("Something went wrong"); }
            doctor.IsDeleted = false;
            _doctorRepo.Update(doctor);
            int rows = await _doctorRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;

        }

        public async Task<bool> SoftDelete(int id)
        {
            Doctor doctor = await _doctorRepo.GetSingleByCondition(x => x.Id == id && !x.IsDeleted);
            if (doctor is null) { throw new Exception("Something went wrong"); }
            doctor.IsDeleted = true;
            _doctorRepo.Update(doctor);
            int rows = await _doctorRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }

        public async Task<bool> UpdateDoctorAsync(DoctorPutDto dto)
        {
            if (!await _doctorRepo.IsExistAsync(dto.Id)) { throw new Exception("Something went wrong"); }
            Doctor doctor = await _doctorRepo.GetByIdAsync(dto.Id);
            if (doctor is null)
            {
                throw new Exception("Something went wrong");
            }
            _doctorRepo.Update(doctor);
            int rows = await _doctorRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong"); }
            return true;
        }
    }
}
