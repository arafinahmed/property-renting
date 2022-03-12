using Autofac;
using PropertyRenting.Web.Models.Account;
using PropertyRenting.Web.Models.Home;
using PropertyRenting.Web.Models.Moderator;

namespace PropertyRenting.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ConfirmEmailModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ContactModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CategoryListModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CreateCategoryModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CreateProductModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<HomeModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}