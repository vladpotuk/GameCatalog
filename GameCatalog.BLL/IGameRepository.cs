using GameCatalog.BLL;
using System.Collections.Generic;

namespace GameCatalog.DAL
{
    public interface IGameRepository
    {
        Game FindGameByName(string gameName);
        List<Game> FindGamesByStudioName(string studioName);
        Game FindGameByStudioAndName(string studioName, string gameName);
        List<Game> FindGamesByStyle(string style);
        List<Game> FindGamesByReleaseYear(int year);
        List<Game> GetAllSinglePlayerGames();
        List<Game> GetAllMultiplayerGames();
        Game GetGameWithMaxSoldCopies();
        Game GetGameWithMinSoldCopies();
        List<Game> GetTop3PopularGames();
        List<Game> GetTop3UnpopularGames();
        void AddGame(Game newGame);
        void UpdateGame(Game updatedGame);
        void DeleteGame(string gameName, string studioName);
    }
}
