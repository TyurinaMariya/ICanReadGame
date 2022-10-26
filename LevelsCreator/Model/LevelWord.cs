namespace LevelsCreator.Model
{
    public class LevelWord
    {
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
