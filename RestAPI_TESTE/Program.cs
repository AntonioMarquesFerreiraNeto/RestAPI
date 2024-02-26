
using Microsoft.EntityFrameworkCore;
using RestAPI_TESTE.Data;
using RestAPI_TESTE.Repository;
using RestAPI_TESTE.Repository.Interfaces;

namespace RestAPI_TESTE {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var conexao = builder.Configuration.GetConnectionString("ConnectionSqlServer");
            builder.Services.AddDbContext<BancoContext>( x => x.UseSqlServer(conexao));
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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
