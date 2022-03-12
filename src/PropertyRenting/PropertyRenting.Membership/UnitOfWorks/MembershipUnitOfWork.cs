using Microsoft.EntityFrameworkCore;
using PropertyRenting.DataAccessLayer.UnitOfWorks;
using PropertyRenting.Membership.Contexts;
using PropertyRenting.Membership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IMessageRepository Message { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IBookingRepository Booking { get; private set; }
        

        public MembershipUnitOfWork(IMembershipDbContext context,
            IMessageRepository message,
            ICategoryRepository category,
            IProductRepository product,
            IBookingRepository booking
            ) : base((DbContext)context)
        {
            Message = message;
            Category = category;
            Product = product;
            Booking = booking;
        }
    }
}