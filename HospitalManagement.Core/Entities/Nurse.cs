namespace HospitalSystem.Core.Entities
{
    public class Nurse:ApplicationUser
    {
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
       

    }
}
