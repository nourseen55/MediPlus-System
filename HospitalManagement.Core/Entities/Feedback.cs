using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class Feedback
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser  { get; set; }
        public string Comments { get; set; }
        public DateTime DateFeedback { get; set; } = DateTime.Now;






    }
}
