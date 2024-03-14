using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portofolio> Portofolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portofolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));
            builder.Entity<Portofolio>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.Portofolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portofolio>()
                .HasOne(x => x.Stock)
                .WithMany(x => x.Portofolios)
                .HasForeignKey(x => x.StockId);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
