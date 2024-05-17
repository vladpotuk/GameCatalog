namespace GameCatalog.DAL
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public int ReleaseYear { get; set; }
        public int SoldCopies { get; set; }
        public bool IsSinglePlayer { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
