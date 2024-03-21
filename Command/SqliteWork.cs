using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class SqliteWork
    {
        public DataTable SendRequest(string queryString, out string message)
        {
            const string localPath = "db\\testDB.sqlite3";
            message = "";
            int requestInfo = 0;
            DataTable dataTable = null;
            try
            {
                SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + localPath + ";Version=3;");
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
                            message += "Complete ";
                        }
                    }
                    else
                    {
                        message += "Records: " + requestInfo + Environment.NewLine;
                    }
                }

                connection.Close();
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
