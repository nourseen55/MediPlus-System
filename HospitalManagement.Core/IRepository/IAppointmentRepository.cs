namespace HospitalSystem.Core.IRepository
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(string doctorId);
		Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(string patientId);
	}
}
