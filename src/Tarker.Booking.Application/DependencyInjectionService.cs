using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Configuracion de AutoMapper
            var mapper = new MapperConfiguration(config =>
            {
                //Agrega perfil de mapeo personalizado de AutoMapper, MapperProfile es una clase que hereda de Profile de AutoMapper
                config.AddProfile(new MapperProfile());
            });

            
            //Se crea un singleton de la instancia de mapper.CreateMapper(), que devolveria un IMapper
            services.AddSingleton(mapper.CreateMapper());
            return services;
        }
    }
}
