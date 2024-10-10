using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.ViewModels
{
	public class ContactFormVM
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public string Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Subject { get; set; }
		public string? Message { get; set; }
		public bool SubscribeNewsletter { get; set; } 
	}
}
