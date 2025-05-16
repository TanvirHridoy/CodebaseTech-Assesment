
using Microsoft.EntityFrameworkCore;
using UserOnboarding.API.Extensions;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Application.Services;
using UserOnboarding.Infrastructure;

namespace UserOnboarding.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IOtpService, OtpService>();
            builder.Services.AddScoped<IUserService, UserService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline. kept swagger open for testing purposes
            //if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapUserEndpoints();
            app.MapOtpEndpoints();
            app.Run();
        }
    }
}
