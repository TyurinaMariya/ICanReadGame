using EFCoreApp.UWP;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
using ICanRead.Core.Services;

[assembly: Dependency(typeof(UwpDbPath))]
namespace EFCoreApp.UWP
{
    public class UwpDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        }
    }
}