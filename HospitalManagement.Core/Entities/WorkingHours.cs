using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class WorkingHours
    { 
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public string Day { get; set; }
        public int StartHour { get; set; } 
        public int EndHour { get; set; }
        public string? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
