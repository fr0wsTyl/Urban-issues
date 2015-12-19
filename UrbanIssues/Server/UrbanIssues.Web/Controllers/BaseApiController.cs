namespace UrbanIssues.Web.Controllers
{
    using System.Web.Http;

    using UrbanIssues.Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IUrbanIssuesData data)
        {
            this.Data = data;
        }

        protected IUrbanIssuesData Data { get; private set; }
    }
}