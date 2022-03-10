using Autofac;
using PropertyRenting.Membership.Contexts;
using PropertyRenting.Membership.Services;

namespace PropertyRenting.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<UrlService>().As<IUrlService>().InstancePerLifetimeScope();
            builder.RegisterType<MailSenderService>().As<IMailSenderService>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileService>().As<IProfileService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}