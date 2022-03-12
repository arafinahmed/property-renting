using Autofac;
using PropertyRenting.Web.Models.Account;
using PropertyRenting.Web.Models.Home;

namespace PropertyRenting.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ConfirmEmailModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ContactModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}