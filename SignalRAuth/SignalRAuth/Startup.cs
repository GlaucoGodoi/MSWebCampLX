using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(SignalRAuth.Startup))]

namespace SignalRAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.Map(
                "/login", p =>
                {
                    p.Run(async ctx =>
                    {
                        var username = ctx.Request.Query["username"] ?? "anonimous";

                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);

                        identity.AddClaim(new Claim(ClaimTypes.Name, username));

                        if (username == "Pipoca")
                        {
                            identity.AddClaim(new Claim(ClaimTypes.Role, "SecureUser"));
                        }

                        ctx.Authentication.SignIn(identity);
                    });
                });


            app.MapSignalR(new HubConfiguration
            {
                EnableDetailedErrors = true
            });
        }
    }
}
