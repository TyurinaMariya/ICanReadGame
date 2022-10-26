using System.ComponentModel.DataAnnotations.Schema;

namespace ICanReadWordsGame.Model
{

    public class Word
    {
        public int Id { get; init; }
        public Entity Entity { get; set; }

        public IList<Level> Levels { get; set; }
        public int EntityId { get; set; }
        public string Text { get; set; }
        public int Complexity { get; set; }
        public string Lang { get; set; }
        [NotMapped]
        public string AudioFileName => $"{Path.GetFileNameWithoutExtension(Entity.PictureFileName)}_{Lang}.mp3";
        //{
        //    get; set;
        //}
        public override bool Equals(object obj)
        {
            if (!(obj is Word word))
                return false;
            return Id == word.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
