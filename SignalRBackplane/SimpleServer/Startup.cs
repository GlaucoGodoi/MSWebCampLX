using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(SimpleServer.Startup))]

namespace SimpleServer
{
    public class Startup
    {
        #region Public Methods

        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var connectionString = ConfigurationManager.ConnectionStrings["backplaneConnection"].ConnectionString;

            var config = new SqlScaleoutConfiguration(connectionString)
            {
               
            };
            
            GlobalHost.DependencyResolver.UseSqlServer(config);

            //var temp = new System.Data.SqlClient.SqlConnection(connectionString);

            //temp.Open();

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            
        }

        #endregion Public Methods
    }
}