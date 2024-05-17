using System.Collections.Generic;
using System.Linq;
using GameCatalog.BLL;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.DAL
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public Game FindGameByName(string gameName)
        {
            return _context.Games.FirstOrDefault(g => g.Name == gameName);
        }

        public List<Game> FindGamesByStudioName(string studioName)
        {
            return _context.Games.Include(g => g.Studio).Where(g => g.Studio.Name == studioName).ToList();
        }

        public Game FindGameByStudioAndName(string studioName, string gameName)
        {
            return _context.Games.Include(g => g.Studio).FirstOrDefault(g => g.Name == gameName && g.Studio.Name == studioName);
        }

        public List<Game> FindGamesByStyle(string style)
        {
            return _context.Games.Where(g => g.Style == style).ToList();
        }

        public List<Game> FindGamesByReleaseYear(int year)
        {
            return _context.Games.Where(g => g.ReleaseYear == year).ToList();
        }

        public List<Game> GetAllSinglePlayerGames()
        {
            return _context.Games.Where(g => g.IsSinglePlayer).ToList();
        }

        public List<Game> GetAllMultiplayerGames()
        {
            return _context.Games.Where(g => !g.IsSinglePlayer).ToList();
        }

        public Game GetGameWithMaxSoldCopies()
        {
            return _context.Games.OrderByDescending(g => g.SoldCopies).FirstOrDefault();
        }

        public Game GetGameWithMinSoldCopies()
        {
            return _context.Games.OrderBy(g => g.SoldCopies).FirstOrDefault();
        }

        public List<Game> GetTop3PopularGames()
        {
            return _context.Games.OrderByDescending(g => g.SoldCopies).Take(3).ToList();
        }

        public List<Game> GetTop3UnpopularGames()
        {
            return _context.Games.OrderBy(g => g.SoldCopies).Take(3).ToList();
        }

        public void AddGame(Game newGame)
        {
            var existingGame = _context.Games.FirstOrDefault(g => g.Name == newGame.Name && g.StudioId == newGame.StudioId);
            if (existingGame == null)
            {
                _context.Games.Add(newGame);
                _context.SaveChanges();
            }
        }

        public void UpdateGame(Game updatedGame)
        {
            var existingGame = _context.Games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (existingGame != null)
            {
                existingGame.Name = updatedGame.Name;
                existingGame.Style = updatedGame.Style;
                existingGame.ReleaseYear = updatedGame.ReleaseYear;
                existingGame.SoldCopies = updatedGame.SoldCopies;
                existingGame.IsSinglePlayer = updatedGame.IsSinglePlayer;
                _context.SaveChanges();
            }
        }

        public void DeleteGame(string gameName, string studioName)
        {
            var gameToDelete = _context.Games.Include(g => g.Studio).FirstOrDefault(g => g.Name == gameName && g.Studio.Name == studioName);
            if (gameToDelete != null)
            {
                Console.WriteLine($"Ви дійсно хочете видалити гру {gameName} студії {studioName}? (y/n)");
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y")
                {
                    _context.Games.Remove(gameToDelete);
                    _context.SaveChanges();
                }
            }
        }
    }
}

