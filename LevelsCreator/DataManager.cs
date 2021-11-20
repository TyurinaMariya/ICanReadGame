using ICanRead.Core.Model;
using ICanRead.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LevelsCreator
{
    public class DataManager
    {
        MyApplicationContext context;
        public MyApplicationContext Context => context;
        public DataManager(string path)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyApplicationContext>();
            optionsBuilder.UseSqlite($"Data Source ={path}");

            context = new MyApplicationContext(optionsBuilder.Options);
        }


        public async Task<GameType> GetGameById(long gameId)
        {
            return await context.GameTypes
                .Where(g => g.Id == gameId)
                .Include(user => user.Levels)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<Word>> GetLevelWords(long levelId)
        {
            var wordIds = await context.LevelWords
                .Where(l => l.LevelId == levelId)
                .Select(w => w.Word)
                .ToListAsync();
            return wordIds;
        }
        public async Task<Entity> AddNewWord()
        {
            var entity = new Entity() { PictureFileName = ".png" };
            context.Entities.Add(entity);
            foreach (var lang in AppSettings.Languages)
            {
                context.Words.Add(new Word() { Entity = entity, Lang = lang, Text = "-new word-" });
            }
            await SaveChanges();
            return entity;
        }

        public async Task AddWordToLevel(Level level, Word word)
        {
            if (level.Words == null)
                level.Words = new List<Word>();
            level.Words.Add(word);
            await SaveChanges();
        }

        public async Task AddWordToLevel(Level level, Entity entity)
        {
            var word = entity.Words.First(w => w.Lang == level.GameType.Lang);
            await AddWordToLevel(level, word);
        }

        public IList<Word> GetWordsNotInGame(GameType gameType)
        {

            var levels = gameType.Levels
                .Select(l => l.Id)
                .ToArray();
            var gameWords = context.LevelWords
                .Where(lv => levels.Contains(lv.LevelId))
                .Select(lv => lv.WordId)
                .ToArray();
            return context.Words
                .Where(w => w.Lang == gameType.Lang && !gameWords.Contains(w.Id))
                .ToList();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        internal async Task RemoveLevelWord(Level level, Word word)
        {
            var levelWord = context.LevelWords.First(lv => lv.Level.Id == level.Id && lv.Word.Id == word.Id);
            context.LevelWords.Remove(levelWord);
            await SaveChanges();
        }

        internal async Task<Level> AddNewLevel(GameType gt)
        {
            var level = context.Levels.Add(new Level() { Number = context.Levels.Max(l => l.Number + 1), GameType = gt }).Entity;
            await SaveChanges();
            return level;
        }
    }
}
