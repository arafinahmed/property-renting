using Autofac;
using PropertyRenting.Membership.BusinessObject;
using PropertyRenting.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace PropertyRenting.Web.Models.Moderator
{
    public class CreateCategoryModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Category Name cannot exceed 255 characters.")]
        public string CategoryName { get; set; }
        private ILifetimeScope _scope;
        private ICategoryService _categoryService;
        private IProfileService _profileService;

        public CreateCategoryModel() { }

        public CreateCategoryModel(ICategoryService categoryService, IProfileService profileService)
        {
            _categoryService = categoryService;
            _profileService = profileService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
            _profileService = _scope.Resolve<IProfileService>();
        }

        public async Task CreateCategory(string userEmail)
        {
            if (string.IsNullOrWhiteSpace(userEmail))
                throw new InvalidOperationException("User Email Must Be Provided For creating a Category");

            var user = await _profileService.GetUserAsync(userEmail);

            if (user == null)
                throw new FileNotFoundException("User not found with the email id");

            var claims = await _profileService.GetClaimAsync(user);
            if (claims == null)
                throw new NullReferenceException("Claim is required for creating a Category");

            var claim = claims.FirstOrDefault();

            if (claim.Type != "Moderator")
            {
                throw new InvalidOperationException("You are not permited to create a Category");
            }

            //await _categoryService.CreateCategory(new Category { CategoryName = CategoryName }, user.Id);
        }
    }
}
