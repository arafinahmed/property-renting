using Microsoft.EntityFrameworkCore;
using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Contexts;
using PropertyRenting.Membership.Entities;

namespace PropertyRenting.Membership.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(IMembershipDbContext context)
            : base((DbContext)context)
        {
        }
    }
}