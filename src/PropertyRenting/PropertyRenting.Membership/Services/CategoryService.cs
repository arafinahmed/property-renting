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

        public async Task CreateCategory(Category category, Guid modId)
        {
            if (category == null)
                throw new ArgumentNullException("Category can not be null");

            if (modId == Guid.Empty)
                throw new ArgumentNullException("Moderator id can not be empty.");

            var user = await _profileService.GetUserByIdAsync(modId);

            if (user == null)
                throw new FileNotFoundException("User not found with the modId");

            var claims = await _profileService.GetClaimAsync(user);

            if (claims == null)
                throw new NullReferenceException("Claim is required for creating a Category");

            var claim = claims.FirstOrDefault();

            if (claim.Type != "Moderator")
            {
                throw new InvalidOperationException("You are not permited to create a Category");
            }

            var Categorys = _unitOfWork.Category.Get(x => x.CategoryName == category.CategoryName, "");

            if (Categorys.Count > 0)
                throw new InvalidOperationException("Category Name Already exists.");

            await _unitOfWork.Category.AddAsync(new EO.Category { CategoryName = category.CategoryName });
            _unitOfWork.Save();
        }

        public IList<Category> GetAllCategorys()
        {
            var CategoryEntities = _unitOfWork.Category.GetAll();
            var Categoryies = new List<Category>();

            foreach (var CategoryEntity in CategoryEntities)
            {
                Categoryies.Add(new Category { CategoryName = CategoryEntity.CategoryName, Id = CategoryEntity.Id });
            }

            return Categoryies;
        }

        public IList<Category> GetAll()
        {
            var CategoryEntities = _unitOfWork.Category.GetAll("Product");
        }
    }
}