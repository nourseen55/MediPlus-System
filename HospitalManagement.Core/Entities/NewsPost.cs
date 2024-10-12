using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.Entities
{
    public class NewsPost
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
        [ValidateNever]
        public ApplicationUser? User { get; set; }
        public string? PostImg { get; set; }
    }
}
