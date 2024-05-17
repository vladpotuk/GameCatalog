using System.Collections.Generic;
using GameCatalog.DAL;

namespace GameCatalog.BLL
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game GetGameByName(string name)
        {
            return _gameRepository.FindGameByName(name);
        }

        public List<Game> GetGamesByStudioName(string studioName)
        {
            return _gameRepository.FindGamesByStudioName(studioName);
        }

        public Game GetGameByStudioAndName(string studioName, string gameName)
        {
            return _gameRepository.FindGameByStudioAndName(studioName, gameName);
        }

        public List<Game> GetGamesByStyle(string style)
        {
            return _gameRepository.FindGamesByStyle(style);
        }

        public List<Game> GetGamesByReleaseYear(int year)
        {
            return _gameRepository.FindGamesByReleaseYear(year);
        }

        public List<Game> GetAllSinglePlayerGames()
        {
            return _gameRepository.GetAllSinglePlayerGames();
        }

        public List<Game> GetAllMultiplayerGames()
        {
            return _gameRepository.GetAllMultiplayerGames();
        }

        public Game GetGameWithMaxSoldCopies()
        {
            return _gameRepository.GetGameWithMaxSoldCopies();
        }

        public Game GetGameWithMinSoldCopies()
        {
            return _gameRepository.GetGameWithMinSoldCopies();
        }

        public List<Game> GetTop3PopularGames()
        {
            return _gameRepository.GetTop3PopularGames();
        }

        public List<Game> GetTop3UnpopularGames()
        {
            return _gameRepository.GetTop3UnpopularGames();
        }

        public void AddNewGame(Game newGame)
        {
            _gameRepository.AddGame(newGame);
        }

        public void UpdateExistingGame(Game updatedGame)
        {
            _gameRepository.UpdateGame(updatedGame);
        }

        public void DeleteExistingGame(string gameName, string studioName)
        {
            _gameRepository.DeleteGame(gameName, studioName);
        }
    }
}
