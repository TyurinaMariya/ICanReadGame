using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace LevelsCreator.Model
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
