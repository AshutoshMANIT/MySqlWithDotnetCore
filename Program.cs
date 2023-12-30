using Microsoft.EntityFrameworkCore;
using MySqlSampleConnection.UserDbContext;
using System;

namespace MySqlSampleConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
          
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           // var cst = "server= `127.0.0.1` ;database=akash;User id=root;Password=ntpc";
            var cst = builder.Configuration.GetConnectionString("MyDatabase");
            builder.Services.AddDbContext<MyUserDbContext>(options => options.UseMySql(cst,
                new MySqlServerVersion(new Version())
                //ServerVersion.AutoDetect("MyDatabase")
                // new mysqlserverversion(new version(8, 0, 11))
                ));
            //builder.Services.AddDbContext<MyUserDbContext>(options => options.UseMySql(@"server= `127.0.0.1` ;database=akash;User id=root;Password=ntpc", ServerVersion.AutoDetect("MyDatabase")));


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