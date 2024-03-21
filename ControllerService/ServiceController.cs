using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ControllerService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class ServiceController : IServiceController
    {
        SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        public string ReadPort() 
        {
            port.Open();
            string line = port.ReadLine();
            port.Close();
            return line;
        }

    }
}
