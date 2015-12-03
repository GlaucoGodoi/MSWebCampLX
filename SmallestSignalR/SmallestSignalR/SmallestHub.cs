using Microsoft.AspNet.SignalR;

namespace SmallestSignalR
{

    public class SmallestHub : Hub
    {
        #region Public Methods

        public void SendMessage(string message)
        {

            Clients.All.ShowMessage(message);
        }

        #endregion Public Methods
    }
}