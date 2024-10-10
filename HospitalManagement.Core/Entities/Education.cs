using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
        public class Education
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Institution { get; set; }
            [Required]
            public string Degree { get; set; }
            [Required]
            public string? FieldOfStudy { get; set; }
            public int StartYear { get; set; }
            public int EndYear { get; set; }
            public string DoctorId { get; set; }
            [ForeignKey(nameof(DoctorId))]
            public virtual Doctor? Doctor { get; set; }
        }

}
