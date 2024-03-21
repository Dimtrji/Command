using System;
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
        public DataTable GetTable(out string message)
        {
            // Запросить таблицу
            message = "";
            SqliteWork selectSql = new SqliteWork();
            DataTable dt = selectSql.SendRequest("select * from person", out message);
            //DataTablePersonRow[] dtT = new DataTablePersonRow[dt.Rows.Count];
            return dt;
        }

        public string SetTable(DataTablePersonRow tableTransfer, out string message)
        {
            //upsert update and insert sqlite
            SqliteWork selectSql = new SqliteWork();
            string query = "INSERT INTO person (id, name, id_card) VALUES(" + tableTransfer.Id + ", '" + tableTransfer.Name + "', " + tableTransfer.Id_card
                + " ) ON CONFLICT (id) DO UPDATE SET name = '" +
                tableTransfer.Name + "', id_card=" + tableTransfer.Id_card + " WHERE id=" + tableTransfer.Id; 
            //string query = "insert into person( id, name, id_card ) VALUES( " + tableTransfer.Id.ToString() + ", " + tableTransfer.Name.ToString() + ", " + tableTransfer.Id_card.ToString() + " )";
            message = "";


            selectSql.SendRequest(message, out message);
            message += query;
            return message;
        }
        
        // Случайная строка....
        public DataTable GetRandomRow()
        {
            SqliteWork selectSql = new SqliteWork();

            DataTable dt = selectSql.SendRequest("SELECT * FROM person ORDER BY RANDOM() LIMIT 1", out string message); 
            //DataTablePersonRow dataTablePersonRow = DataTableToPersonTable(dt, 0);

            return dt;
        }

        public void Delete(string dataSet)
        {
            //SqliteWork selectSql = new SqliteWork();
        }

        private DataTablePersonRow DataTableToPersonTable(DataTable dt, int rowN)
        {
            DataTablePersonRow dataTablePerson = new DataTablePersonRow();

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (dt.Rows[rowN][j] is string)
                {                }
                else rowN++;

                if (dt.Columns[j].ColumnName == "id")
                {
                    dataTablePerson.Id = (int)dt.Rows[rowN][j];
                }
                if (dt.Columns[j].ColumnName == "name")
                {
                    dataTablePerson.Name = dt.Rows[rowN][j].ToString();
                }
                if (dt.Columns[j].ColumnName == "id_card")
                {
                    dataTablePerson.Id_card = (int)dt.Rows[rowN][j];
                }

            }
            return dataTablePerson;
        }








    }
}
