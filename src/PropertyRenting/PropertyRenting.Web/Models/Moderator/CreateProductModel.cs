using Autofac;
using PropertyRenting.Membership.BusinessObject;
using PropertyRenting.Membership.Services;
using PropertyRenting.Membership.Utilities.FileStoreUtilities;
using System.ComponentModel.DataAnnotations;

namespace PropertyRenting.Web.Models.Moderator
{
    public class CreateProductModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Product Name cannot exceed 255 characters.")]
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IFormFile FormFile { get; set; }
        private ILifetimeScope _scope;
        private IProductService _productService;
        private IProfileService _profileService;
        private IFileStoreUtility _fileStoreUtility;

        public CreateProductModel() { }

        public CreateProductModel(IProductService productService, IProfileService profileService, IFileStoreUtility fileStoreUtility)
        {
            _productService = productService;
            _profileService = profileService;
            _fileStoreUtility = fileStoreUtility;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productService = _scope.Resolve<IProductService>();
            _profileService = _scope.Resolve<IProfileService>();
            _fileStoreUtility = _scope.Resolve<IFileStoreUtility>();
        }

        public async Task CreateProduct(string userEmail)
        {
            if (string.IsNullOrWhiteSpace(userEmail))
                throw new InvalidOperationException("User Email Must Be Provided For creating a Product");

            var user = await _profileService.GetUserAsync(userEmail);

            if (user == null)
                throw new FileNotFoundException("User not found with the email id");

            var claims = await _profileService.GetClaimAsync(user);
            if (claims == null)
                throw new NullReferenceException("Claim is required for creating a Product");

            var claim = claims.FirstOrDefault();
            var path = _fileStoreUtility.StoreFile(FormFile).filePath;
            if (claim.Type != "Moderator")
            {
                throw new InvalidOperationException("You are not permited to create a Product");
            }
            
            await _productService.CreateProduct(new Product 
            { 
                ProductName = ProductName,
                CategoryId = CategoryId,
                Description = Description,
                ImageUrl = path,
                Price = Price
            }, user.Id);
        }
    }
}
