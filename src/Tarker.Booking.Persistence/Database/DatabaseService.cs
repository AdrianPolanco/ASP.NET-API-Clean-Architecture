using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.Database
{
    //Heredando de DbContext
    public class DatabaseService: DbContext, IDatabaseService
    {
        //Recibiendo la cadena de conexion en el constructor y pasandosela al constructor de DbContext
        public DatabaseService(DbContextOptions options): base(options)
        {
            
        }

        //Invocando las tablas
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        {
            //DbContext.SaveChangesAsync() verifica si han habido cambios en el DbContext y lo guarda de forma asincrona
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //.OnModelCreating(modelBuilder) aplica las configuraciones iniciales de EF Core
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            /*Crea una instancia de las respectivas configuraciones, .Entity<T> devuelve un EntityTypeBuilder de la entidad T,
             que sirve para configurar la entidad T*/
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>()); 
        }
    }
}
