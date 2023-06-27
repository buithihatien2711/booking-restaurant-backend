using System.Text;
using backend.Data;
using backend.Data.Repository.LocationRepository;
using backend.Data.Repository.ReservationRepository;
using backend.Data.Repository.RestaurantRepository;
using backend.Data.Repository.UserRepository;
using backend.Data.Seed;
using backend.Mapping;
using backend.Services.LocationService;
using backend.Services.ReservationService;
using backend.Services.RestaurantService;
using backend.Services.UploadImageService;
using backend.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.

services.AddControllersWithViews();

services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddScoped<IRestaurantRepository, RestaurantRepository>();
services.AddScoped<IRestaurantService, RestaurantService>();

services.AddScoped<ISuitabilityRepository, SuitabilityRepository>();
services.AddScoped<ISuitabilityService, SuitabilityService>();

services.AddScoped<IServiceRepository, ServiceRepository>();
services.AddScoped<IServicesService, ServicesService>();

services.AddScoped<ICuisineRepository, CuisineRepository>();
services.AddScoped<ICuisineService, CuisineService>();

services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();
services.AddScoped<IExtraServiceService, ExtraServiceService>();

services.AddScoped<ILocationRepository, LocationRepository>();
services.AddScoped<ILocationService, LocationService>();

services.AddScoped<IReservationRepository, ReservationRepository>();
services.AddScoped<IReservationService, ReservationService>();

services.AddScoped<IUploadImageService, UploadImageService>();

services.AddAutoMapper(typeof(AutoMappingConfiguration).Assembly);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
        };
    });


var app = builder.Build();

using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
// Seed service
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedService(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
// Seed cuisine
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedCuisine(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
// Seed extra service
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedExtraService(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
// Seed suitability
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    
    Seed.SeedSuitability(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
// Seed role
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedRole(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}

// // Seed restaurant
// try
// {
//     var context = serviceProvider.GetRequiredService<DataContext>();
//     Seed.SeedRestaurants(context);
//     context.Database.Migrate();
// }
// catch (Exception ex)
// {
//     var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "Migration Failed");
// }

// Seed ward, district, city
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedCity(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedDistrict(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedWard(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}

// Seed user
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedUser(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}

// Seed location
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    Seed.SeedLocation(context);
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
