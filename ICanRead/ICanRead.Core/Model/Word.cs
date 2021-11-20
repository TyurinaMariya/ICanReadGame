using ICanRead.Core.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICanRead.Core.Model
{

    public class Word
    {
        public int Id { get; set; }
        public Entity Entity { get; set; }

        public IList<Level> Levels { get; set; }
        public int EntityId { get; set; }
        public string Text { get; set; }
        public int Complexity { get; set; }
        public string Lang { get; set; }
        public string AudioFileName
        {
            get; set;
        }
    

    }
}
