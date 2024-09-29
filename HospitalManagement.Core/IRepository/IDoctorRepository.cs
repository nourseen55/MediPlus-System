using HospitalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.IRepository
{
	public interface IDoctorRepository:IGenericRepository<Doctor>
	{
		Task< List<Doctor>> GetByDepartmentId(string Id);
	}
}
