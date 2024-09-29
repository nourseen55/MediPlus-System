using AutoMapper;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientVM>();
            CreateMap<PatientVM, Patient>();

            CreateMap<Doctor, DoctorVM>();
            CreateMap<DoctorVM, Doctor>();

            CreateMap<Nurse, NurseVM>();
            CreateMap<NurseVM, Nurse>()
            .ForMember(dest => dest.Doctor, opt => opt.Ignore()) 
            .ForMember(dest => dest.Departments, opt => opt.Ignore());
        }
        

    }
}
