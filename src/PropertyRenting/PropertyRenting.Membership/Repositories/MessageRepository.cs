using Microsoft.EntityFrameworkCore;
using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Contexts;
using PropertyRenting.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.Membership.Repositories
{
    public class MessageRepository : Repository<Message, Guid>, IMessageRepository
    {
        public MessageRepository(IMembershipDbContext context)
            : base((DbContext)context)
        {
        }
    }
}