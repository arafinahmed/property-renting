using PropertyRenting.Membership.BusinessObject;
using EO = PropertyRenting.Membership.Entities;
using PropertyRenting.Membership.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;
        private readonly IProfileService _profileService;

        public CategoryService(IMembershipUnitOfWork unitOfWork, IProfileService profileService)
        {
            _unitOfWork = unitOfWork;
            _profileService = profileService;
        }
    }
}