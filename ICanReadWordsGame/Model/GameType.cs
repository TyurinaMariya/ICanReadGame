﻿using System.ComponentModel.DataAnnotations.Schema;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.Model
{
    public class GameType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public string Game { get; set; }
        [NotMapped]
        public GameTypes GameValue => (GameTypes)Enum.Parse(typeof(GameTypes), Game);
        public virtual ICollection<Level> Levels { get; set; } = new HashSet<Level>();
        public override string ToString()
        {
            return $"{Name} ({Lang})";
        }

    }
}
