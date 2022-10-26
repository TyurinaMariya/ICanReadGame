using System.ComponentModel.DataAnnotations.Schema;

namespace ICanReadWordsGame.Model
{
    public class Level
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Locked { get; set; }
        //   public virtual ICollection<Word> Words { get; set; } = new HashSet<Word>();

        public IList<Word> Words { get; set; }
        public virtual GameType GameType { get; set; }

        public int GameTypeId { get; set; }

        [NotMapped]
        public int StarsCount { get; set; } = -1;
        
        [NotMapped]
        public LevelState State
        {
            get
            {
                if (Locked)
                    return LevelState.Locked;
                switch (StarsCount)
                {
                    case 0: return LevelState.Unlocked;
                    case 1: return LevelState.OneStar;
                    case 2: return LevelState.TwoStars;
                    case 3: return LevelState.ThreeStars;
                    default: return LevelState.Locked;


                }
            }
        }
        public override string ToString()
        {
            return $"{Number} IsLocked={Locked}";
        }
    }
}
