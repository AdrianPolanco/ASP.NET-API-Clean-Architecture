
using Tarker.Booking.Api;
using Tarker.Booking.Common;
using Tarker.Booking.Application;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddWebApi().AddCommon().AddApplication().AddExternal(builder.Configuration).AddPersistence(builder.Configuration);
//Se construye la instancia de la aplicacion
var app = builder.Build();


//Se ejecuta la instancia de la aplicacion previamente construida
app.Run();
