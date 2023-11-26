namespace Tarker.Booking.Api
{
    public static class DependencyInjectionService
    {
        /*Se utiliza un metodo de extension al usar this, haciendo este metodo disponible para los objetos de instancia de tipo
         IServiceCollection*/
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            return services;
        }
    }
}
