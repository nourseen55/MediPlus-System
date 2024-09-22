using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Doctor:ApplicationUser
    {
        [Key]
        public string Id { get; set; }  
        [Required]
        public string Specialization { get; set; }
      

    }
}