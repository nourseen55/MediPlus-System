namespace HospitalSystem.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> _patientRepository { get; }
        int Complete();

    }
}
