using System;
using Xamarin.Forms;
using System.IO;
using EFCoreApp.iOS;
using ICanRead.Core.Services;

[assembly: Dependency(typeof(IosDbPath))]
namespace EFCoreApp.iOS
{
    public class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", sqliteFilename);
        }
    }
}