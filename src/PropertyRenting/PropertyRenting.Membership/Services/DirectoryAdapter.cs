using System;
using System.IO;

namespace PropertyRenting.Membership.Services
{
    public class DirectoryAdapter : IDirectoryAdapter
    {
        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.Exists(path);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.CreateDirectory(path);
        }
    }
}
