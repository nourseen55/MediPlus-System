namespace HospitalSystem.Core.ViewModels
{
    public class NurseVM
    {
        public string? ID { get; set; } = Guid.NewGuid().ToString();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DoctorID { get; set; }
        public string? DepartmentID { get; set; }
        public  IEnumerable<Departments>? Departmentss { get; set; }
        public IEnumerable<Doctor>? Doctors { get; set; }
    }
}
