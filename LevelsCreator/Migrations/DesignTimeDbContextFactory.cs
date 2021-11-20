using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsCreator.Migrations
{
    public class DesignTimeDbContextFactory
    : IDesignTimeDbContextFactory<LevelsApplicationContext>
    {

        public LevelsApplicationContext CreateDbContext(params string[] args)
        {
            var builder = new DbContextOptionsBuilder<LevelsApplicationContext>();
            builder.UseSqlite($"Data Source = {AppData.DbPath}");
            return new LevelsApplicationContext(builder.Options);
        }
    }
}
