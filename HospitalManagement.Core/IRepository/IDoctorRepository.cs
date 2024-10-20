namespace HospitalSystem.Core.IRepository
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
	{
		Task< List<Doctor>> GetByDepartmentId(string Id);
	}
}
