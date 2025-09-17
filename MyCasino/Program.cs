
using Microsoft.EntityFrameworkCore;
using Data.DbContextFile;
using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Interfaces.IServices;
using Data.Repositories;
using CasinoService.Services;

namespace MyCasino
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

    

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CasinoDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<IBetRepository, BetRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();

            builder.Services.AddScoped<IWalletService, WalletService>();
            builder.Services.AddScoped<IBetService, BettingService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPlayerBonusRepository, PlayerBonusRepository>();

            
            builder.Services.AddScoped<IPlayerBonusService, PlayerBonusService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            
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
