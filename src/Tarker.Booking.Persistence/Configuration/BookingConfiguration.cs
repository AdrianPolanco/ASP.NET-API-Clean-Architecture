using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => e.BookingId);
            entityBuilder.Property(e => e.RegisterDate).IsRequired();
            entityBuilder.Property(e => e.Code).IsRequired();
            entityBuilder.Property(e => e.Type).IsRequired();
            entityBuilder.Property(e => e.UserId).IsRequired();
            entityBuilder.Property(e => e.CustomerId).IsRequired();

            /*Se puede leer como: "Esta entidad esta asociada mediante su propiedad UserId (como clave foranea), con solo
             un usuario en la entidad UserEntity, el cual puede relacionarse con varios registros de esta entidad BookingEntity"*/
            entityBuilder.HasOne(e => e.User).WithMany(e => e.Bookings).HasForeignKey(e => e.UserId);
            entityBuilder.HasOne(e => e.Customer).WithMany(e => e.Bookings).HasForeignKey(e => e.CustomerId);
        }
    }
}
