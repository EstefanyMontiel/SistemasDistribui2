using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using PokemonApi.Repositories;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();

builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository,PokemonRepository>();

<<<<<<< Updated upstream
//para que sirven
builder.Services.AddScoped<IPokemonService,PokemonService>(); 
=======

builder.Services.AddSingleton<IHobbyService, HobbyService>();
builder.Services.AddScoped<IHobbyRepository,HobbyRepository>();

builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository,BookRepository>();


>>>>>>> Stashed changes

builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))); //conexion a la base de datos
var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions()); //levantar el servicio 
<<<<<<< Updated upstream
//IPokemonService es la interfaz que se va a exponer

=======
app.UseSoapEndpoint<IHobbyService>("/EstefanyMontielService.svc", new SoapEncoderOptions()); //levantar el servicio 
app.UseSoapEndpoint<IBookService>("/BookService.svc", new SoapEncoderOptions()); //levantar el servicio 
>>>>>>> Stashed changes

app.Run();
