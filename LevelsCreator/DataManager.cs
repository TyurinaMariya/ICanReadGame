using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelsCreator.Model;
using System;

namespace LevelsCreator
{
    public class DataManager
    {
        readonly MyApplicationContext _context;
        public MyApplicationContext Context => _context;
        public DataManager(string path)
        {
            var builder = new DbContextOptionsBuilder<MyApplicationContext>();
            builder.UseSqlite($"Filename={path}");
            _context = new MyApplicationContext(builder.Options);
        }


        public async Task<GameType> GetGameById(long gameId)
        {
            return await _context.GameTypes
                .Where(g => g.Id == gameId)
                .Include(user => user.Levels)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<Word>> GetLevelWords(long levelId)
        {
            var wordIds = await _context.LevelWords
                .Where(l => l.LevelId == levelId)
                .Select(w => w.Word)
                .ToListAsync();
            return wordIds;
        }
        public async Task<Entity> AddNewWord()
        {
            var entity = new Entity { PictureFileName = ".png" };
            _context.Entities.Add(entity);
            foreach (var lang in Enum.GetValues (typeof(Languages)))
            {
                _context.Words.Add(new Word() { Entity = entity, Lang = lang.ToString(), Text = "-new word-" });
            }
            await SaveChanges();
            return entity;
        }

        public async Task AddWordToLevel(Level level, Word word)
        {
            level.Words ??= new List<Word>();
            level.Words.Add(word);
            await SaveChanges();
        }

        //public async Task AddWordToLevel(Level level, Entity entity)
        //{
        //    var word = entity.Words.First(w => w.Lang == level.GameType.Lang);
        //    await AddWordToLevel(level, word);
        //}

        public IList<Word> GetWordsNotInGame(GameType gameType)
        {

            var levels = gameType.Levels
                .Select(l => l.Id)
                .ToArray();
            var gameWords = _context.LevelWords
                .Where(lv => levels.Contains(lv.LevelId))
                .Select(lv => lv.WordId)
                .ToArray();
            return _context.Words
                .Where(w => w.Lang == gameType.Lang && !gameWords.Contains(w.Id))
                .ToList();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        internal async Task RemoveLevelWord(Level level, Word word)
        {
            var levelWord = _context.LevelWords.First(lv => lv.Level.Id == level.Id && lv.Word.Id == word.Id);
            _context.LevelWords.Remove(levelWord);
            await SaveChanges();
        }

        internal async Task<Level> AddNewLevel(GameType gt)
        {
            var level = _context.Levels.Add(new Level() { Number = _context.Levels.Max(l => l.Number + 1), GameType = gt }).Entity;
            await SaveChanges();
            return level;
        }
    }
}
