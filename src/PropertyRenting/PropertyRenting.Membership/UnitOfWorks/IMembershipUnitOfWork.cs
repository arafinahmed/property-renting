using PropertyRenting.DataAccessLayer.UnitOfWorks;
using PropertyRenting.Membership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.UnitOfWorks
{
    public interface IMembershipUnitOfWork : IUnitOfWork
    {
        IMessageRepository Message { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IBookingRepository Booking { get; }
    }
}