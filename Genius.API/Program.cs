using Genius.API.Mapper;
using Genius.API.Middleware;
using Genius.Domain;
using Genius.Infraestructure;
using Genius.Infraestructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependecy inyection

builder.Services.AddScoped<IDriverDomain, DriverDomain>();
builder.Services.AddScoped<IDriverInfraestructure, DriverInfraestructure>();

builder.Services.AddScoped<ICarDomain, CarDomain>();
builder.Services.AddScoped<ICarInfraestructure, CarInfraestructure>();



builder.Services.AddScoped<IUserInfraestructure, UserInfraestructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IEncryptDomain, EncryptDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();


//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("GeniusConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));


//jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});



builder.Services.AddDbContext<GeniusDBContext>(
    dbContextOptions =>
    { //CADENA DE CONEXION 
        dbContextOptions.UseMySql(connectionString, 
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5, // MAXIMO 5 VECES
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });



builder.Services.AddAutoMapper(
typeof(ModelToResponse),
typeof(InputToModel));


var app = builder.Build();
//validacion
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<GeniusDBContext>())
{
    context.Database.EnsureCreated();
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();