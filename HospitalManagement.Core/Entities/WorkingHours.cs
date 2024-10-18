using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class WorkingHours
    { 
        public string Id {  get; set; }= Guid.NewGuid().ToString();
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly Day { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public string? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public bool IsValid { get; set; } = true;

    }
}
