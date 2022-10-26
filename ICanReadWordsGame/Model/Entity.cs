using System.ComponentModel.DataAnnotations.Schema;

namespace ICanReadWordsGame.Model
{
    [Table("entities")]
    public class Entity
    {
        public int Id { get; set; }

        public string NameId { get =>Path.GetFileNameWithoutExtension(PictureFileName);  }
        public string PictureFileName { get; set; }

        public IList<Word> Words { get; set; }
    }
}
