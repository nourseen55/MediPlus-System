using HospitalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.ViewModels
{
    public class NurseVM
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

        public string? DoctorID { get; set; }
        public string? DepartmentID { get; set; }
    }
}
