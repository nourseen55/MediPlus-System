﻿namespace HospitalSystem.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientVM>();
            CreateMap<PatientVM, Patient>();

            CreateMap<Doctor, DoctorVM>();
            CreateMap<DoctorVM, Doctor>();
            CreateMap<NurseVM, Nurse>();
            CreateMap<Nurse, NurseVM>();
            CreateMap<ApplicationUser , ContactFormVM>();
			CreateMap<ApplicationUser, ContactFormVM>();

		}
	}
}
