using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<BusinessHour> BusinessHours { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<ExtraService> ExtraServices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MenuImage> MenuImages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }
        public DbSet<RestaurantExtraService> RestaurantExtraServices { get; set; }
        public DbSet<RestaurantImage> RestaurantImages { get; set; }
        public DbSet<RestaurantService> RestaurantServices { get; set; }
        public DbSet<RestaurantSuitability> RestaurantSuitabilities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Suitability> Suitabilities { get; set; }
        public DbSet<TypeOfCuisine> TypeOfCuisines { get; set; }
        public DbSet<TypeOfService> TypeOfServices { get; set; }
        public DbSet<Ward> Wards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantCuisine>()
                .HasKey(rc => new {rc.TypeOfCuisineId, rc.RestaurantId});

            builder.Entity<RestaurantService>()
                .HasKey(rs => new {rs.RestaurantId, rs.TypeOfServiceId});

            builder.Entity<RestaurantSuitability>()
                .HasKey(rs => new {rs.RestaurantId, rs.SuitabilityId});

            builder.Entity<RestaurantExtraService>()
                .HasKey(rs => new {rs.RestaurantId, rs.ExtraServiceId});

            builder.Entity<Restaurant>()
                        .HasOne(c => c.User)
                        .WithMany(u => u.Restaurants)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Reservation>()
                        .HasOne(c => c.Restaurant)
                        .WithMany(u => u.Reservations)
                        .HasForeignKey(c => c.RestaurantId)
                        .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Reservation>()
                        .HasOne(c => c.User)
                        .WithMany(u => u.Reservations)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<TypeOfService>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 

            builder.Entity<TypeOfCuisine>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 

            builder.Entity<Suitability>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever();

            builder.Entity<ExtraService>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever();  

            builder.Entity<Ward>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 

            builder.Entity<District>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 

            builder.Entity<City>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 

            builder.Entity<Role>()
                        .Property(t => t.Id)
                        .ValueGeneratedNever(); 
        }
    }
}