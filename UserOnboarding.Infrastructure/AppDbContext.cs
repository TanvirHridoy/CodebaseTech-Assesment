using Microsoft.EntityFrameworkCore;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<OTP> OTPs => Set<OTP>();


}



