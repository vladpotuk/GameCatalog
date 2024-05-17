using System;
using GameCatalog.BLL;
using GameCatalog.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameCatalog.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<GameContext>(options => options.UseSqlServer("Server=localhost;Database=GameCatalogDB;Trusted_Connection=True;"))
                .AddScoped<IGameRepository, GameRepository>()
                .AddScoped<IGameService, GameService>()
                .BuildServiceProvider();

            var gameService = serviceProvider.GetService<IGameService>();

            
            Console.WriteLine("Введіть назву гри для пошуку:");
            string gameName = Console.ReadLine();
            var game = gameService.GetGameByName(gameName);
            if (game != null)
            {
                Console.WriteLine($"Знайдено гру: {game.Name}, студія: {game.Studio.Name}, стиль: {game.Style}, рік випуску: {game.ReleaseYear}");
            }
            else
            {
                Console.WriteLine("Гру не знайдено.");
            }
        }
    }
}
