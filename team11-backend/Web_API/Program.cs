 using System.Text;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
//using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using Data_Access_Layer.Repositories;
using Business_Logic_Layer.Mappings;
using AutoMapper;
using Business_Logic_Layer.Services;
using Business_Logic_Layer.DTOs;



namespace Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CinemaContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("CinemaDb")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddScoped<UnitOfWork>();
            //builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<MovieService>();
            builder.Services.AddScoped<ActorService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<DirectorService>();
            builder.Services.AddScoped<GenreService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<SalesStatisticsService>();
            builder.Services.AddScoped<SessionService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<SeatService>();
            builder.Services.AddScoped<HallService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
