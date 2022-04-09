using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfoSys.Application.Contracts
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<IReadOnlyList<Patient>> getAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task UpdatePatientAsync(Patient patient);
    }
}
