using Api_WildOasis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildOasis.Core.Interfaces;
using WildOasis.Infrastructure.Repositories;

namespace WildOasis.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // Register the DbContext
            //services.AddDbContext<WildOasisContext>(options =>
            //    options.UseSqlServer("Server=.;Database=Wild_oasis;Trusted_Connection=True;TrustServerCertificate=True;"));
            // Register the DbContext
            services.AddDbContext<WildOasisContext>(options =>
                options.UseSqlServer("Server=db7945.databaseasp.net;Database=db7945;User Id=db7945;Password=wildoasisDb12;Encrypt=False;MultipleActiveResultSets=True;"));


            // Register repositories
            services.AddScoped <IPersonRepository, PersonRepository>();
            // Register other repositories here...
            services.AddScoped<ICabinsRepository, CabinsRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}