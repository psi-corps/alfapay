using Autofac;


namespace AlfaPay.Web.Frontoffice.Api
{
    public class IocModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(ThisAssembly)
				.InNamespace(nameof(Controllers))
				.InstancePerLifetimeScope()
				.AsSelf();

			base.Load(builder);
		}
	}
}
