using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Services
{
    public interface IPathService
    {
        string DefaultFileStoragePath { get; }
        string ProfileImagePath { get; }
        string CompanyLogoPath { get; }
        string DefaultMaleAvaterImagePath { get; }
        string DefaultFemaleAvaterImagePath { get; }
        string DefaultProfileImagePath { get; }
        string DefaultCompanyLogoPath { get; }
        string DefaultProfileImage { get; }
        string DefaultCompanyLogo { get; }
        string TempFolder { get; }
        string AttachPathWithProfileImage(string imageName);
        string AttachPathWithCompanyLogo(string copanyLogo);
        string AttachPathWithFile(string fileName);
        string AttachPathWithDefaultProfileImage(string defaultProfileImageName);
        string AttachPathWithDefaultCompanyLogo(string defaultCompanyLogoName);
    }
}
