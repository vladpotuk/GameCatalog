using GameCatalog.BLL;

namespace GameCatalog.DAL
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}

