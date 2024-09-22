using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
    }
    
}
