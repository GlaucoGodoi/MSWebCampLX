using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRAuth
{
    [Authorize]
    public class SecureHub:Hub
    {
        private static int _counter;
        public override Task OnConnected()
        {
            var user = Context.User.Identity.Name;

            var message = $"Welcome {user}";
            var message2 = $"The user {user} is now online.";

            Clients.Caller.Welcome(message);

            Clients.Others.NewUserOnline(message2);

            return base.OnConnected();
        }

        [Authorize(Roles= "SecureUser")]
        public void SecureMethod()
        {
            _counter++;
            Clients.Caller.ShowCounter(_counter);
        }
    }
}