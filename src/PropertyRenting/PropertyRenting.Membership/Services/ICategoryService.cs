using PropertyRenting.Membership.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(Category category, Guid modId);
        IList<Category> GetAllCategorys();
        IList<Category> GetAll();
    }
}