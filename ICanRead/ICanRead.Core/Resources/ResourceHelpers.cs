using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ICanRead.Core.Resources
{
    public class ResourceHelpers:IResourceHelpers
    {
        /// <summary>
        /// Get stream from resource file
        /// </summary>
        /// <param name="filename">File Path and Name in format folderName.subFolderName.filename</param>
        /// <returns>result stream</returns>
        public  Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(MvxApp).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(filename);
            return stream;
        }
    }
}
