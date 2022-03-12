using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}