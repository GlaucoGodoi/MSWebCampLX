using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;

namespace SimpleServer
{
    public class SimpleHub : Hub
    {
        #region Public Methods

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
            this.Clients.All.AddNewMessage(message);
        }

        #endregion Public Methods
    }

    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            var port = args.Length == 0 ? "8888" : args[0];
            var url = $"http://localhost:{port}";
            using (WebApp.Start(url))
            {
                Console.WriteLine($"The server is running on: {url}");
                Console.ReadLine();
            }
        }

        #endregion Private Methods
    }
}