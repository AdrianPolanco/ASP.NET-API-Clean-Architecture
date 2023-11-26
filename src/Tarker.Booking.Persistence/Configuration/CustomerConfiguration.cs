using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder
                .HasKey(e => e.CustomerId);
            entityBuilder.Property(e => e.DocumentNumber).IsRequired();
            entityBuilder.Property(e => e.FullName).IsRequired();
            entityBuilder.HasMany(e => e.Bookings).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId);
        }
    }
}
