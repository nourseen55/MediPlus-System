using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class WorkingHours
    { 
        public int Id {  get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartHour { get; set; } 
        public TimeSpan EndHour { get; set; }
        public string? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
