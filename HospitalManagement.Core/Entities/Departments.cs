using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class Departments
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string DepartmentName { get; set; }
        public string Description { get; set; }

    }
}
