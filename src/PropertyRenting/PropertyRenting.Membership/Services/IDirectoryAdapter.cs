using System.IO;

namespace PropertyRenting.Membership.Services
{
    public interface IDirectoryAdapter
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
