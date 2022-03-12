using Microsoft.AspNetCore.Http;

namespace PropertyRenting.Membership.Services
{
    public interface IFileAdapter
    {
        bool Exists(string path);
    }
}
