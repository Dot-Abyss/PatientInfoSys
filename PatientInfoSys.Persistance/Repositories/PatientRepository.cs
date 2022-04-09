using Microsoft.EntityFrameworkCore;
using PatientInfoSys.Application.Contracts;
using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfoSys.Persistance.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(PatientDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Patient>> getAllPatientsAsync()
        {
            List<Patient> allPatients = new List<Patient>();
            allPatients = await _dbContext.patients.ToListAsync();
            return allPatients;
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            Patient patient = new Patient();
            patient = await _dbContext.patients.FirstOrDefaultAsync(x => x.Id == id);
            return patient;
        }
        public async Task UpdatePatientAsync(Patient patient)
        {

            _dbContext.Entry(patient).State = EntityState.Modified;
            _dbContext.Entry(patient).Property(p => p.recordCreationDate).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }
    }
}
