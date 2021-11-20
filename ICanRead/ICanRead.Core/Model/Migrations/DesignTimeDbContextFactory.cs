using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsCreator
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using global::ICanRead.Core.Model;
    using System.IO;
    using Xamarin.Essentials;

    namespace ICanRead.Core.Model.Migrations
    {
        public class DesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<MyApplicationContext>
        {
            
            public MyApplicationContext CreateDbContext(params string[] args)
            {
                var builder = new DbContextOptionsBuilder<MyApplicationContext>();

                string dbPath = @"C:\Users\tyuri\source\repos\ICanRead\game.db"; //Path.Combine(FileSystem.AppDataDirectory, FileSys);

                builder.UseSqlite(dbPath);
                return new MyApplicationContext(builder.Options);
            }
        }
    }
}
