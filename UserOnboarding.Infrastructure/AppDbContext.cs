using Microsoft.EntityFrameworkCore;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<OTP> OTPs => Set<OTP>();

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<User>()
    //        .HasIndex(u => u.ICNumber)
    //        .IsUnique();

    //    modelBuilder.Entity<OTP>()
    //        .HasOne(o => o.User)
    //        .WithMany()
    //        .HasForeignKey(o => o.UserId);

    //    base.OnModelCreating(modelBuilder);
    //}
}



