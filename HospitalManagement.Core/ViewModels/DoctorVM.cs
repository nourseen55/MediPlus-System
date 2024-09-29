using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.ViewModels
{
    public class DoctorVM
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public string DepartmentId { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
      
    }
}
