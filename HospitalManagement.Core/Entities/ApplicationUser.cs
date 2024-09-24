namespace HospitalSystem.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Img { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
    }
    
}
