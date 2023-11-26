using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Database;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//El builder.Services accede al contenedor de servicios de la aplicacion

/*.AddDbContext<DatabaseService> añade el contexto DatabaseService al contenedor de servicios, para que EF Core interactue con la BD*/

/*(options => options.UseSqlServer()) configura el servicio de DbContext añadido
 para que use SQL Server como gestor de BD, .useSqlServer() espera un string de conexion como argumento*/

/*builder.Configuration["SQLConnectionString"] obtiene el contenido que hay en la key "SQLConnectionString" en la configuracion
 del proyecto, por tanto, obtendra la cadena de conexion que esta ahí*/
builder.Services.AddDbContext<DatabaseService>( options => options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

/*.AddScoped<IDatabaseService, DatabaseService>() hace inyeccion de dependencias, osea, se requerira un IDatabaseService, y se
 proporcionara pues, la misma instancia de DatabaseService, logrando entonces depender de IDatabaseService en lugar de DatabaseService,
respetando el principio de Inversion de Dependencias, que dice que se debe depender de abstracciones y no de implementaciones concretas*/
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

//Se construye la instancia de la aplicacion
WebApplication? app = builder.Build();

/*Establece una ruta /createTest en el servidor, al llamar esa ruta se ejecutara la funcion flecha dentro, IDatabaseService
 es sustituido por DatabaseService*/
app.MapPost("/createTest", async (IDatabaseService _databaseService) => {
    //Creando nuevo usuario
    UserEntity user = new UserEntity() { FirstName = "Adrian", LastName="Polanco", UserName="adferrer", Password="GhsQMSj00" };
    /*Se llama a la tabla User (que sale del DbSet<UserEntity> User de la clase DatabaseService que hereda de DbContext), para usar
     el metodo .AddAsync para guardar el usuario que creamos previamente*/
    await _databaseService.User.AddAsync(user);
    //Se guardan los cambios hechos al hacer una operacion de edicion en la DB (Create, Update o Delete)
    await _databaseService.SaveAsync();
    //Se retorna este mensaje al cliente
    return "Resource created";
});

app.MapGet("/getTest", async(IDatabaseService _databaseService) => { 
    /*Accede a la tabla User del _databaseService y la convierte a ListAsync, espera a que se resuelva la operacion y asigna
     el resultado a users*/
    List<UserEntity> users = await _databaseService.User.ToListAsync();
    //Retorna la lista obtenida, la cual convierte automaticamente a JSON
    return users;
});

//Se ejecuta la instancia de la aplicacion previamente construida
app.Run();
