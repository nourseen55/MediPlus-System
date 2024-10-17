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
        public DayOfWeek Day { get; set; }
        public TimeSpan StartHour { get; set; } 
        public TimeSpan EndHour { get; set; }
        public string? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
