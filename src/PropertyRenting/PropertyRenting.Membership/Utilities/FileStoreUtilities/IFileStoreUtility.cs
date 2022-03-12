using Microsoft.AspNetCore.Http;

namespace PropertyRenting.Membership.Utilities.FileStoreUtilities
{
    public interface IFileStoreUtility
    {
        public (string fileName, string filePath) StoreFile(IFormFile file);
    }
}
