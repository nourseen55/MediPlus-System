using HospitalSystem.Core.Entities;
using HospitalSystem.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Patient> _patientRepository { get; }
        int Complete();
        
    }
}
