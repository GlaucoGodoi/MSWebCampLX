using System.Web.Http;

namespace DataCollector
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        #region Protected Methods

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        #endregion Protected Methods
    }
}