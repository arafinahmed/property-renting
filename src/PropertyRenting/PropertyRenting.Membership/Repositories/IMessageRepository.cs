using PropertyRenting.DataAccessLayer.Repositories;
using PropertyRenting.Membership.Entities;

namespace PropertyRenting.Membership.Repositories
{
    public interface IMessageRepository : IRepository<Message, Guid>
    {
    }
}