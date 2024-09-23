using HospitalSystem.Core.Entities;
using HospitalSystem.Core.IRepository;

namespace HospitalSystem.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> _patientRepository { get; }
        int Complete();

    }
}
