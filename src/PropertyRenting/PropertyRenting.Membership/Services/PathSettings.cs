using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Services
{
    public class PathSettings
    {
        public string ProfileImagePath { get; set; }
        public string CompanyLogoPath { get; set; }
        public string DefaultFileStoragePath { get; set; }
        public string DefaultProfileImagePath { get; set; }
        public string DefaultCompanyLogoPath { get; set; }
        public string TempFolder { get; set; }
    }
}
