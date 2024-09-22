using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Infrastructure.Context
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Patient> Patients { set;get; }
        public DbSet<Appointment> Appointments { set;get; }
        public DbSet<Doctor> Doctors { set;get; }
        public DbSet<MedicalRecord> MedicalRecords { set;get; }
        public DbSet<Nurse> Nurses { set;get; }
        public DbSet<ApplicationUser> ApplicationUsers { set;get; }




    }
}
