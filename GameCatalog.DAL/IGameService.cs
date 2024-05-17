using System.Collections.Generic;
using GameCatalog.DAL;

namespace GameCatalog.BLL
{
    public interface IGameService
    {
        Game GetGameByName(string name);
        List<Game> GetGamesByStudioName(string studioName);
        Game GetGameByStudioAndName(string studioName, string gameName);
        List<Game> GetGamesByStyle(string style);
        List<Game> GetGamesByReleaseYear(int year);
        List<Game> GetAllSinglePlayerGames();
        List<Game> GetAllMultiplayerGames();
        Game GetGameWithMaxSoldCopies();
        Game GetGameWithMinSoldCopies();
        List<Game> GetTop3PopularGames();
        List<Game> GetTop3UnpopularGames();
        void AddNewGame(Game newGame);
        void UpdateExistingGame(Game updatedGame);
        void DeleteExistingGame(string gameName, string studioName);
    }
}
