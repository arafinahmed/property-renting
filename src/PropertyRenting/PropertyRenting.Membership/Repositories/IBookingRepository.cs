using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Entities;

namespace PropertyRenting.Membership.Repositories
{
    public interface IBookingRepository : IRepository<Booking, Guid>
    {
    }
}