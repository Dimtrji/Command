using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerHost
{
    internal class Server
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Command.Commands)))
            {
                host.Open();
                Console.WriteLine("Server started...");
                Console.ReadLine();
            }
        }
    }
}
