using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Services { 
    public class PathService : IPathService
    {
        public string DefaultFileStoragePath { get; private set; }
        public string ProfileImagePath { get; private set; }
        public string CompanyLogoPath { get; private set; }
        public string DefaultMaleAvaterImagePath { get; private set; }
        public string DefaultFemaleAvaterImagePath { get; private set; }
        public string DefaultProfileImagePath { get; private set; }
        public string DefaultCompanyLogoPath { get; private set; }
        public string DefaultProfileImage { get; private set; }
        public string DefaultCompanyLogo { get; private set; }
        public string TempFolder { get; private set; }

        public string AttachPathWithProfileImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;
            return Path.Combine(ProfileImagePath, imageName);
        }

        public string AttachPathWithCompanyLogo(string copanyLogo)
        {
            if (string.IsNullOrWhiteSpace(copanyLogo))
                return null;
            return Path.Combine(CompanyLogoPath, copanyLogo);
        }

        public PathService(IOptions<PathSettings> settings, IOptions<DefaultSiteSettings> defaultSiteSettings)
        {
            var paths = settings.Value;
            var defaultSitePaths = defaultSiteSettings.Value;
            DefaultFileStoragePath = paths.DefaultFileStoragePath;
            ProfileImagePath = paths.ProfileImagePath;
            CompanyLogoPath = paths.CompanyLogoPath;
            DefaultProfileImagePath = paths.DefaultProfileImagePath;
            DefaultCompanyLogoPath = paths.DefaultCompanyLogoPath;
            TempFolder = paths.TempFolder;
            DefaultProfileImage = defaultSitePaths.DefaultProfileImage;
            DefaultCompanyLogo = defaultSitePaths.DefaultCompanyLogo;
        }

        public string AttachPathWithFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new InvalidOperationException("File name must be provided to attach path with file!");

            return Path.Combine(DefaultFileStoragePath, fileName);
        }

        public string AttachPathWithDefaultProfileImage(string defaultProfileImageName)
        {
            if (string.IsNullOrWhiteSpace(defaultProfileImageName))
                throw new InvalidOperationException("Default Profile image name must be provided to attach path with Default Profile image!");

            return Path.Combine(DefaultProfileImagePath, DefaultProfileImage);
        }

        public string AttachPathWithDefaultCompanyLogo(string defaultCompanyLogoName)
        {
            if (string.IsNullOrWhiteSpace(defaultCompanyLogoName))
                throw new InvalidOperationException("Default Profile image name must be provided to attach path with Default Profile image!");

            return Path.Combine(DefaultCompanyLogoPath, DefaultCompanyLogo);
        }
    }
}
