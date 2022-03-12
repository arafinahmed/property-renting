using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PropertyRenting.Membership.Services
{
    public class FileAdapter : IFileAdapter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IPathService _pathService;
        private readonly IDirectoryAdapter _directoryAdapter;

        public FileAdapter(IWebHostEnvironment webHostEnvironment,
                           IPathService pathService,
                           IDirectoryAdapter directoryAdapter)
        {
            _webHostEnvironment = webHostEnvironment;
            _pathService = pathService;
            _directoryAdapter = directoryAdapter;
        }

        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return File.Exists(path);
        }
    }
}
