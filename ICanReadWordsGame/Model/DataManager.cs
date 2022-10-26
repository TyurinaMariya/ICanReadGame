using ICanReadWordsGame.Services;
using Microsoft.EntityFrameworkCore;

namespace ICanReadWordsGame.Model
{
    public interface IDataManager
    {
        Task Initialise();
        Task<GameType> GetGame(GameTypes gameType, string lang);
        Task<Level> GetLevelById(int levelId);
        Task<Word> GetLevelWord(Level level, int wordNum);

        Task<Word[]> GetListWithRandomWords(Word answerWord, int wordsCount);

        Task<Level> GetNextLevel(Level level);
        Task SaveLevelStars(int levelId, int starsCount);

        Task InitStarsCount(IEnumerable<Level> sortedLevelsList);
        Task UnlockNextLevel(IEnumerable<Level> sortedLevelsList);
    }

    internal class DatabaseInitializer : IMauiInitializeService
    {
        public void Initialize(IServiceProvider services)
        {
            var dbService = services.GetRequiredService<IDataManager>();
            Task.Run(async () =>
            {
                await dbService.Initialise();
            }).GetAwaiter().GetResult();
        }
    }

    public class DataManager : IDataManager
    {
        DbContextOptions _options;
        private readonly IUserSettings _settings;
        private bool _isInitialized ;
        public DataManager(IUserSettings settings)
        {
            _settings = settings;


        }
        public void CopyStream(Stream stream, string destPath)
        {
            using var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
        }
        public async Task Initialise()
        {
            if (_isInitialized) return;
          
            string path = Path.Combine(FileSystem.AppDataDirectory, AppSettings.DbFileName);

            //if (! File.Exists(path))
            //{
                var stream = await FileSystem.OpenAppPackageFileAsync(AppSettings.DbFileName);
                CopyStream(stream, path);
            //}

            var builder = new DbContextOptionsBuilder<MyApplicationContext>();
            builder.UseSqlite($"Filename={path}");
            _options = builder.Options;
           // SQLitePCL.Batteries_V2.Init();
            await using var db = new MyApplicationContext(_options);
            var res = await db.Database.EnsureCreatedAsync();
            _isInitialized = true;
            System.Diagnostics.Debug.Assert(!res, "Database should exists");
        }

        public async Task<Level> GetLevelById(int levelId)
        {
            await Initialise();
            await using var context = new MyApplicationContext(_options);
            return await context.Levels
                .Where(l => l.Id == levelId)
                .Include(l => l.Words)
                .Include(l => l.GameType)
                .SingleOrDefaultAsync();
        }
        public async Task<Word> GetLevelWord(Level level, int wordNum)
        {
            await Initialise();
            await using var context = new MyApplicationContext(_options);
            var wordId = level.Words.Skip(wordNum).First().Id;//wordId
            return await context.Words
                .Where(w => w.Id == wordId)
                .Include(w => w.Entity)
                .SingleOrDefaultAsync();
        }

        public async Task<Level> GetNextLevel(Level level)
        {
            await Initialise();
            await using var context = new MyApplicationContext(_options);
            return await context.Levels
                .Where(l => l.GameType == level.GameType && l.Number == level.Number + 1)
                .Include(l => l.Words)
                .SingleOrDefaultAsync();
        }
        private ICollection<T> ShuffleAndSelect<T>(ICollection<T> list, int resultCount)
        {
            return Enumerable
                 .Range(0, list.Count)
                 .OrderBy(g => Guid.NewGuid())
                 .Take(list.Count > resultCount ? resultCount : list.Count)
                 .Select(list.ElementAt)
                 .ToList();
        }
        public async Task<Word[]> GetListWithRandomWords(Word answerWord, int wordsCount)
        {
            await Initialise();

            var wordsworth = await GetWordsWithSameCompatibility(answerWord);

            //if (otherwords.Length < wordsCount - 1)
            //    throw new ArgumentException($"Cannt load 7 words for complexity level {answerWord.Complexity}");
            var list = ShuffleAndSelect(wordsworth, wordsCount - 1).ToList();
            list.Insert(new Random().Next(0, list.Count), answerWord);
            list.ForEach(w => w.Text = w.Text.ToUpper());
            return list.ToArray();
        }


        private async Task<Word[]> GetWordsWithSameCompatibility(Word answerWord)
        {
            await using var context = new MyApplicationContext(_options);
            return await context.Words
                .Where(l => l.Id != answerWord.Id
                            &&
                            l.Complexity == answerWord.Complexity
                            &&
                            l.Lang == answerWord.Lang)
                .Include(l => l.Entity)
                .ToArrayAsync();
        }

        public async Task<GameType> GetGame(GameTypes gameType, string lang)
        {
            await Initialise();

            await using var context = new MyApplicationContext(_options);
            var gameId = (await context.GameTypes.ToArrayAsync())
                .First(g => g.GameValue == gameType && g.Lang == lang).Id;
            return await context
                .GameTypes
                .Where(g => g.Id == gameId)
                .Include(user => user.Levels)
                .SingleOrDefaultAsync();
        }

        public async Task SaveLevelStars(int levelId, int starsCount)
        {
            await Initialise();

            if (starsCount > _settings.GetLevelStars(levelId))
                _settings.SetLevelStars(levelId, starsCount);
        }

        public async Task InitStarsCount(IEnumerable<Level> sortedLevelsList)
        {
            await Initialise();
            foreach (var l in sortedLevelsList)
            {
                l.StarsCount = _settings.GetLevelStars(l.Id);
                if (l.StarsCount < 0)
                    break;
            }
        }
        public async Task UnlockNextLevel(IEnumerable<Level> sortedLevelsList)
        {
            await Initialise();
            var nextLevel = sortedLevelsList.SkipWhile(l => l.StarsCount > 0).FirstOrDefault();
            if (nextLevel != null)
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
