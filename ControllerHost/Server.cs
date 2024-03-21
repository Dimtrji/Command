using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ControllerHost
{
    internal class Server
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ControllerService.ServiceController)))
            {
                host.Open();               
                Console.WriteLine("Server started...");

                var client = new ServiceReference.ServiceControllerClient("NetTcpBinding_IServiceController");
                while (true)
                {
                    try
                    {
                        Console.WriteLine(client.ReadPort());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                }              
                Console.ReadLine();
            }
        }
    }
}
