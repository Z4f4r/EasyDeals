using EasyDeals.Data.Configurations;
using EasyDeals.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : 
    IdentityDbContext<AppUser>(dbContextOptions)
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Favorite> Favorites { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Product> Products { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new CityConfiguration());
        builder.ApplyConfiguration(new StateConfiguration());

        base.OnModelCreating(builder);

        builder.Entity<Favorite>(x => x.HasKey(p => new { p.AppUserId, p.ProductId }));

        builder.Entity<Favorite>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Favorites)
            .HasForeignKey(u => u.AppUserId);

        builder.Entity<Favorite>()
            .HasOne(u => u.Product)
            .WithMany(u => u.Favorites)
            .HasForeignKey(u => u.ProductId);

        List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
            };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
