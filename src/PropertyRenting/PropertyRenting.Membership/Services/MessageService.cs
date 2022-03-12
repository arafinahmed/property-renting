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
    public class MessageService : IMessageService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;
        private readonly IProfileService _profileService;

        public MessageService(IMembershipUnitOfWork unitOfWork, IProfileService profileService)
        {
            _unitOfWork = unitOfWork;
            _profileService = profileService;
        }
        public async Task StoreMessage(Message message)
        {
            await _unitOfWork.Message.AddAsync(new EO.Message {Name = message.Name, Email = message.Email, Subject = message.Subject, Description = message.Description});
            _unitOfWork.Save();
        }
    }
}