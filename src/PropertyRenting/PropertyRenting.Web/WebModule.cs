using Autofac;
using PropertyRenting.Web.Models.Account;

namespace PropertyRenting.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ConfirmEmailModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}