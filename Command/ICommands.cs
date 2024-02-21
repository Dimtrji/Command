using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Command
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICommands
    {
        [OperationContract]
        DataTable SendRequest(string queryString, out string message);

        [OperationContract]
        void SetTablePerson(TablePerson t);

        [OperationContract]
        TablePerson GetTablePerson(int id);
    }
}
