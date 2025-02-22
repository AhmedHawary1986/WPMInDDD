using Microsoft.EntityFrameworkCore;
using WPM.Management.Domain.Entities;
using WPM.Management.Domain.ValueObjects;

namespace WPM.Management.API.Infrastructure
{
    public class ManagementDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pet>().HasKey(p => p.Id);
            modelBuilder.Entity<Pet>().Property(p => p.BreedId).HasConversion(v => v.Value, v => BreedId.Create(v));
            modelBuilder.Entity<Pet>().OwnsOne(w => w.Weight);
        }
    }

    public static class ManagementDBContextExtension
    {
        public static void EnsureDbIsCreate(this IApplicationBuilder app)
        {
            using var scope= app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ManagementDBContext>();
            context.Database.EnsureCreated();
            context.Database.CloseConnection();

        }
    }
}
