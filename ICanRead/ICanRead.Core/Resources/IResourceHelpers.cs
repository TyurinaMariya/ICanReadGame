using System.IO;

namespace ICanRead.Core.Resources
{
    public interface IResourceHelpers
    {
        /// <summary>
        /// Get stream from resource file
        /// </summary>
        /// <param name="filename">File Path and Name in format folderName.subFolderName.filename</param>
        /// <returns>result stream</returns>
        Stream GetStreamFromFile(string filename);
    }
}