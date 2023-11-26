using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        /*entityBuilder es un objeto de tipo EntityTypeBuilder<T> que usa en EF Core para configurar las propiedades
         y relaciones de una entidad*/
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            //Indicando a EF Core que el campo UserId es la clave primaria de esta tabla o entidad
            entityBuilder
                .HasKey(x => x.UserId);
            //Indicando a EF Core que la propiedad FirstName de la clase UserEntity sera requerida
            entityBuilder.Property(x => x.FirstName).IsRequired();
            entityBuilder.Property(x => x.LastName).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired();
            entityBuilder.Property(x => x.Password).IsRequired();

            /*.hasMany(x => x.Bookings) establece que la entidad actual (en este caso UserEntity tendra una relacion
             de uno a muchos con la entidad del campo relacionado, en este caso, x.Bookings es de tipo
            BookingEntity por lo que la relacion 1:N se establecera con la entidad BookingEntity*/

            /*.WithOne(x => x.User) establece la relacion inversa 1:N en cada BookingEntity de la relacion, es decir,
             debido a que antes usamos .HasMany, y se determino que la relacion era con BookingEntity, ahora en .WithOne
            x es igual a la entidad BookingEntity, por tanto en .WithOne(x => x.User) se esta diciendo que, cada registro
            de la entidad BookingEntity tendra relacion con un solo UserEntity
            
             TIP ADICIONAL: Al hacer referencia a un User, en EF Core puedes acceder a esa instancia asociada de User por este metodo,
            sin necesidad de consultas adicionales: UserEntity user = bookings.User*/

            /* Finalmente .HasForeignKey(x => x.UserId) establece que la propiedad UserId de la entidad BookingEntity
             sera la lalve foranea que haga referencia al UserEntity con el que este asociados*/

            /*En resumen, este codigo de abajo se puede leer como:
             "entityBuilder: Cada registro de esta entidad UserEntity tiene una relacion 1:N con la entidad a la 
            que pertence el campo UserEntity.Bookings, cada registro de esa entidad BookingEntity, tiene relacion con un solo registro
            de esta entidad UserEntity, y el campo UserId de esa entidad a la que esta haciendo referencia esta entidad UserEntity
            es el sera la clave foranea para hacer referencia a esta entidad UserEntity"*/
            entityBuilder.HasMany(x => x.Bookings).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
