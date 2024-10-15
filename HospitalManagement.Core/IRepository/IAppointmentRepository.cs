using HospitalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.IRepository
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(string doctorId);
		Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(string patientId);
	}
}
