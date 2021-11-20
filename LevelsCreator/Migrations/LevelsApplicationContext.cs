using ICanRead.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LevelsCreator.Migrations
{
    public class LevelsApplicationContext : MyApplicationContext
    {
        public LevelsApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
