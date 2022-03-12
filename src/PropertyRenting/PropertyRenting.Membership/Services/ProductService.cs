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
    public class ProductService : IProductService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;
        private readonly IProfileService _profileService;

        public ProductService(IMembershipUnitOfWork unitOfWork, IProfileService profileService)
        {
            _unitOfWork = unitOfWork;
            _profileService = profileService;
        }

        public async Task CreateProduct(Product product, Guid modId)
        {
            if (product == null)
                throw new ArgumentNullException("Product can not be null");

            if (modId == Guid.Empty)
                throw new ArgumentNullException("Moderator id can not be empty.");

            var user = await _profileService.GetUserByIdAsync(modId);

            if (user == null)
                throw new FileNotFoundException("User not found with the modId");

            var claims = await _profileService.GetClaimAsync(user);

            if (claims == null)
                throw new NullReferenceException("Claim is required for creating a Product");

            var claim = claims.FirstOrDefault();

            if (claim.Type != "Moderator")
            {
                throw new InvalidOperationException("You are not permited to create a Product");
            }

            var Products = _unitOfWork.Product.Get(x => x.ProductName == product.ProductName, "");

            if (Products.Count > 0)
                throw new InvalidOperationException("Product Name Already exists.");

            await _unitOfWork.Product.AddAsync(new EO.Product 
            { 
                ProductName = product.ProductName, 
                CategoryId = product.CategoryId, 
                Description = product.Description, 
                ImageUrl = product.ImageUrl, 
                Price = product.Price 
            });
            _unitOfWork.Save();
        }
    }
}