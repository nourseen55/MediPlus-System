using HospitalSystem.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Infrastructure.Context;
using HospitalSystem.Core.UnitOfWork;
using HospitalSystem.Core.Entities;
namespace HospitalSystem.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public IRepository<Patient> _patientRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _patientRepository = new PatientRepository(applicationDbContext);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
