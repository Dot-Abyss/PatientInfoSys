using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientInfoSys.Application.Contracts;
using PatientInfoSys.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PatientInfoSys.Persistance
{
    public static class PersistanceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PCS")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            return services;
        }
    }
}
