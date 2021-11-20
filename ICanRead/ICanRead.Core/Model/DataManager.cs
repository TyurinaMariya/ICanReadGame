using ICanRead.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;

namespace ICanRead.Core.Model
{
    public interface IDataManager
    {
        Task<GameType> GetGame(GameTypes gameType, string lang);
        Task<Level> GetLevelById(int levelId);
        Task<Word> GetLevelWord(Level level, int wordNum);

        Task<Word[]> GetListWithRandomWords(Word answerWord, int wordsCount);

        Task<Level> GetNextLevel(Level level);
        void SaveLevelStars(int levelId, int starsCount);

        void InitStarsCount(IEnumerable<Level> sortedLevelsList);
        void UnlockNextLevel(IEnumerable<Level> sortedLevelsList);
    }

    public class DataManager :IDataManager
    {
        DbContextOptions _options;
        private IUserSettings _settings;

        public DataManager(IUserSettings settings, IPath pathService)
        {
            this._settings = settings;
            var dbPath = pathService.GetDatabasePath(AppSettings.DbFileName);
            var builder = new DbContextOptionsBuilder<MyApplicationContext>();
            builder.UseSqlite($"Filename={dbPath}");
            _options = builder.Options;

            using (var db = new MyApplicationContext(_options))
            {
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
            }
        }

        
        public async Task<Level> GetLevelById(int levelId)
        {
            using (var context = new MyApplicationContext(_options))
            {
                return await context.Levels
                    .Where(l => l.Id == levelId)
                    .Include(l => l.Words)
                    .Include (l=>l.GameType)
                    .SingleOrDefaultAsync();
            }
        }
        public async Task<Word> GetLevelWord(Level level, int wordNum)
        {
            using (var context = new MyApplicationContext(_options))
            {
                var wordId = level.Words.Skip(wordNum).First().Id;//wordId
                return await context.Words
                    .Where(w => w.Id == wordId)
                    .Include(w => w.Entity)
                    .SingleOrDefaultAsync();
            }
        }

        public async Task<Level> GetNextLevel(Level level)
        {
            using (var context = new MyApplicationContext(_options))
            {
                return await context.Levels
                    .Where(l => l.GameType == level.GameType && l.Number==level.Number+1)
                    .Include(l => l.Words)
                    .SingleOrDefaultAsync();
            }
        }
        private ICollection<T> ShuffleAndSelect<T>(ICollection<T> list, int resultCount)
        {
            return Enumerable
                 .Range(0, list.Count)
                 .OrderBy(g => Guid.NewGuid())
                 .Take(list.Count>resultCount?resultCount:list.Count)
                 .Select(i => list.ElementAt(i))
                 .ToList();
        }
        public async Task<Word[]> GetListWithRandomWords(Word answerWord, int wordsCount)
        {
            var otherwords = await GetWordsWithSameCompatibility(answerWord);

            //if (otherwords.Length < wordsCount - 1)
            //    throw new ArgumentException($"Cannt load 7 words for complexity level {answerWord.Complexity}");
            var list = ShuffleAndSelect(otherwords, wordsCount - 1).ToList();
            list.Insert(new Random().Next(0, list.Count ), answerWord);
            list.ForEach(w => w.Text = w.Text.ToUpper());
            return list.ToArray();
        }


        private async Task<Word[]> GetWordsWithSameCompatibility(Word answerWord)
        {
            using (var context = new MyApplicationContext(_options))
            {
                return await context.Words
                    .Where(l => l.Id != answerWord.Id
                         &&
                         l.Complexity == answerWord.Complexity
                         &&
                         l.Lang == answerWord.Lang)
                    //.Include(l=>l.Entity)
                    .ToArrayAsync();
            }
        }

        public async Task<GameType> GetGame(GameTypes gameType, string lang)
        {
            using (var context = new MyApplicationContext(_options))
            {
                var gameId = (await context.GameTypes.ToArrayAsync()).First(g => g.GameValue == gameType && g.Lang == lang).Id;
                return await context.GameTypes.Where (g => g.Id == gameId).Include(user => user.Levels).SingleOrDefaultAsync();
            }
        }
        public void SaveLevelStars(int levelId, int starsCount)
        {
            if (starsCount > _settings.GetLevelStars(levelId))
                _settings.SetLevelStars(levelId, starsCount);
        }

        public void InitStarsCount(IEnumerable<Level> sortedLevelsList)
        {
            foreach (var l in sortedLevelsList)
            {
                l.StarsCount = _settings.GetLevelStars(l.Id);
                if (l.StarsCount < 0)
                    break;
            }
        }
        public void UnlockNextLevel(IEnumerable<Level> sortedLevelsList)
        {
            var nextLevel = sortedLevelsList.SkipWhile(l => l.StarsCount > 0).FirstOrDefault();
            if (nextLevel!=null)
                nextLevel.StarsCount = 0;
        }
        //private IEnumerable<int> GetRandomNumbers(int maxVal, int count)
        //{
        //    var a = new Random();
        //    var randomList = new List<int>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        var newNum = a.Next(0, maxVal);
        //        if (!randomList.Contains(newNum))
        //            randomList.Add(newNum);
        //    }
        //    return randomList;
        //}
    }
}
