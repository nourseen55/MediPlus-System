﻿namespace HospitalSystem.Core.ViewModels
{
    public class PatientVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }

        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
