namespace UrbanIssues.Web
{
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using UrbanIssues.Data;
    using UrbanIssues.Data.Migrations;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
