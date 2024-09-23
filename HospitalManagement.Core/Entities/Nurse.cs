namespace HospitalSystem.Core.Entities
{
    public class Nurse:ApplicationUser
    {
        [ForeignKey("Doctor")]
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
       

    }
}
