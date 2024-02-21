﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Command
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Commands : ICommands
    {
        public TablePerson GetTablePerson(int id)
        {
            throw new NotImplementedException();
        }

        public void SetTablePerson(TablePerson t)
        {
            throw new NotImplementedException();
        }

        DataTable ICommands.SendRequest(string queryString, out string message)
        {
            const string localPath = "db/testDB.dat";
            message = "";
            int requestInfo = 0;
            DataTable dataTable = null;
            try
            {
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + localPath + ";Version=3"); //@"Data Source=C:\\ProgramData\\MDO\\ParsecNET 3\\parsec3.events.dat;Version=3;");
                connection.Open();
                
                var ds = new DataSet();
                using (SQLiteCommand c = new SQLiteCommand(queryString, connection))
                {
                    requestInfo = c.ExecuteNonQuery();
                    if (requestInfo <= 0)
                    {
                        using (var a = new SQLiteDataAdapter(c))
                            a.Fill(ds);

                        if (ds.Tables.Count > 0)
                        {
                            message += "Record: " + ds.Tables[0].Rows.Count + Environment.NewLine;
                            dataTable = ds.Tables[0];
                            
                        }
                        else
                        {
                            message = "Complete";
                        }
                    }
                    else
                    {
                        message += "Records: " + requestInfo + Environment.NewLine;                    
                    }
                }

                connection.Close();
            }
            catch (FaultException fe) 
            {
                message += "FaultException:" + fe.Message.ToString() + Environment.NewLine;               
            }
            catch (SQLiteException se)
            {
                message += "Sqlite Error:" + se.Message.ToString() + Environment.NewLine;
            }
            catch (Exception ex)
            {
                message += "Error:" + ex.Message.ToString() + Environment.NewLine;
            }
            return dataTable;

        }
    }
}