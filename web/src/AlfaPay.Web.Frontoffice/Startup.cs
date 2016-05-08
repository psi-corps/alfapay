using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;



namespace AlfaPay.Web.Frontoffice
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
			Configuration = CreateConfig(env);
		}


		public IConfigurationRoot Configuration { get; private set; }

		#region Configuration

		private IConfigurationRoot CreateConfig(IHostingEnvironment env)
		{
			var cfg = new ConfigurationBuilder();

			InitConfig(cfg, env);

			return cfg.Build();
		}


		private void InitConfig(IConfigurationBuilder builder, IHostingEnvironment env)
		{
			builder
				.AddEnvironmentVariables()
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.${env.EnvironmentName}.json", optional: true);


			if (env.IsEnvironment("dev"))
			{
				builder.AddUserSecrets();
			}
		}

		private void RegisterServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		private void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseIISPlatformHandler()
				.UseMvcWithDefaultRoute()
				.UseDeveloperExceptionPage();
		}

		#endregion

		#region Methods

		public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			RegisterServices(services);

			var builder = new ContainerBuilder();

			builder.RegisterModule<IocModule>();
			builder.Populate(services);

			return builder.Build().Resolve<IServiceProvider>();
        }
			
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			loggerFactory.AddConsole((Configuration.GetSection("Logging")));
            loggerFactory.AddDebug();

			ConfigureApp(app, env);
        }

		public static void Main(string[] args)
		{
			WebApplication.Run<Startup>(args);
		}

		#endregion
	}
}
