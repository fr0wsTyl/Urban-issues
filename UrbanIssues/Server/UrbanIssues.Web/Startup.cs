using Microsoft.Owin;

using System.Web.Http;

using Owin;

[assembly: OwinStartup(typeof(UrbanIssues.Web.Startup))]

namespace UrbanIssues.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);

			GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
		}
	}
}
