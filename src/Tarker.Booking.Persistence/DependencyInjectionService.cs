using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Persistence.Database;

namespace Tarker.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            //El builder.Services (IServiceCollection services) accede al contenedor de servicios de la aplicacion

            /*.AddDbContext<DatabaseService> añade el contexto DatabaseService al contenedor de servicios, para que EF Core interactue con la BD*/

            /*(options => options.UseSqlServer()) configura el servicio de DbContext añadido
             para que use SQL Server como gestor de BD, .useSqlServer() espera un string de conexion como argumento*/

            /*builder.Configuration["SQLConnectionString"](IConfiguration configuration)
             obtiene el contenido que hay en la key "SQLConnectionString" en la configuracion
             del proyecto, por tanto, obtendra la cadena de conexion que esta ahí*/
            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));

            /*.AddScoped<IDatabaseService, DatabaseService>() hace inyeccion de dependencias, osea, se requerira un IDatabaseService, y se
             proporcionara pues, la misma instancia de DatabaseService, logrando entonces depender de IDatabaseService en lugar de DatabaseService,
            respetando el principio de Inversion de Dependencias, que dice que se debe depender de abstracciones y no de implementaciones concretas*/
            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}
