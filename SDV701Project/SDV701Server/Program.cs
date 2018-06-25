using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SDV701Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration details
            Uri address = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(address);
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });

            // Server creation
            HttpSelfHostServer server = new HttpSelfHostServer(config);

            // Listener
            server.OpenAsync().Wait();
            Console.WriteLine("Inventory controller hosted on " + address);
            Console.WriteLine("Type exit to end the service.");
            while (true)
            {
                var userInput = Console.ReadLine();
                if(userInput.ToLower() == "exit")
                    break;
            }
            server.CloseAsync().Wait();
        }
    }
}
