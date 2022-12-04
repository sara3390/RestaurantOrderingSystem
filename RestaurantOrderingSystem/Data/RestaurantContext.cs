using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RestaurantOrderingSystem.Data {
    public class RestaurantContext : IdentityDbContext<ApplicationUser> {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) {}

        public DbSet<Table>? tables {get; set;}
        public DbSet<MenuItem>? menuItems {get; set;}
        public DbSet<Reservation>? reservations {get; set;}
        public DbSet<Ingredient>? ingredients {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        }
    }
}