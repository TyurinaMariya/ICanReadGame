using System.IO;

namespace LevelsCreator
{
    public static class AppData
    {
        public static string DbPath => Path.Combine(System.Windows.Forms.Application.StartupPath, @"..\..\..\..\", "game.db");
    }
}
