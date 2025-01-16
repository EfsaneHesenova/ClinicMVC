using AutoMapper;
using Project.BL.DTOs.DoctorDtos;
using Project.BL.Services.Abstractions;
using Project.Core.Models;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
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
          var entity =  _mapper.Map<Doctor>(dto);
            await _doctorRepo.CreateAsync(entity);
            int rows = await _doctorRepo.SaveChangesAsync();
            if (rows == 0) { throw new Exception("Something went wrong");  }
            return true;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            if(!await _doctorRepo.IsExistAsync(id)) { throw new Exception("Something went wrong"); }
        }

        public Task<ICollection<Doctor>> GetAllDoctorAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetByIdDoctorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDoctorAsync(DoctorPutDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
