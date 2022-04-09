using Microsoft.EntityFrameworkCore;
using PatientInfoSys.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Persistance
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> patients { get; set; }
    }
}
