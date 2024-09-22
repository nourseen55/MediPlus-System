using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class Nurse:ApplicationUser
    {
        public string Id { get; set; }
        
        [ForeignKey("Doctor")]
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
       

    }
}
