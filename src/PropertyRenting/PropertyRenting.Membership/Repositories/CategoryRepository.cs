using Microsoft.EntityFrameworkCore;
using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Contexts;
using PropertyRenting.Membership.Entities;

namespace PropertyRenting.Membership.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IMembershipDbContext context)
            : base((DbContext)context)
        {
        }
    }
}