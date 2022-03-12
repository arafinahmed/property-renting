using Autofac;
using PropertyRenting.Membership.BusinessObject;
using PropertyRenting.Membership.Services;

namespace PropertyRenting.Web.Models.Home
{
    public class ContactModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }
        public string? Success { get; set; }

        private ILifetimeScope _scope;
        private IMessageService _messageService;
        private IMailSenderService _mailSenderService;

        public ContactModel(IMessageService messageService, IMailSenderService mailSenderService)
        {
            _messageService = messageService;
            _mailSenderService = mailSenderService;
        }

        public ContactModel() { }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _messageService = _scope.Resolve<IMessageService>();
            _mailSenderService = _scope.Resolve<IMailSenderService>();
        }

        public async Task StoreMessage()
        {

            await _messageService.StoreMessage(new Message { Name = Name, Description = Description, Email = Email, Subject = Subject});
            await _mailSenderService.UserMessageToAdminAsync(Name, Email, Subject, Description);
            Success = "Your message is sent successfully. We concern about your opinion.";

        }
    }
}
