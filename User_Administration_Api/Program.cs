using User_Administration_Api.Middlewares;
using User_Administration_Api.Repository;
using User_Administration_Api.Repository.Interfaces;

namespace User_Administration_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionsMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
