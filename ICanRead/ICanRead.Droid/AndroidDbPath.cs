using System;
using EFCoreApp.Droid;
using System.IO;
using Xamarin.Forms;
using ICanRead.Core.Services;
using System.Reflection;
using System.Linq;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace EFCoreApp.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
           // if (!File.Exists(filename))
            {
                var embeddedResourceDb = Assembly.GetExecutingAssembly().
                    GetManifestResourceNames().First(s => s.Contains(filename));
                var embeddedResourceDbStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResourceDb);


                using (var br = new BinaryReader(embeddedResourceDbStream))

                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        var buffer = new byte[2048];
                        int len;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
            return dbPath;
        }
    }
}