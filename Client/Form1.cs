using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client
{
    public partial class Form1 : Form
    {
        private string message = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            Random r = new Random(); 
            dataGridViewTable.Columns.Clear();
            var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");
            DataTable dT = null;
            try
            {
                dT = client.SendRequest("select * from person", out message);
                dataGridViewTable.DataSource = client.SendRequest("select * from person where id=" + r.Next(1, dT.Rows.Count), out message); 
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }            
            textBox1.Text = message;
            client.Close();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string[] s = new string[dataGridViewTable.Rows.Count-1];
            for (int i = 0; i < dataGridViewTable.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridViewTable.Columns.Count; j++)
                {
                    if (dataGridViewTable[j, i].Value is string)
                    {
                        s[i] += "\"" + dataGridViewTable[j, i].Value.ToString() + "\"";
                    }
                    else 
                        s[i] +=  dataGridViewTable[j,i].Value.ToString();
                    if (j+1!= dataGridViewTable.Columns.Count)
                    {
                        s[i] += ", ";
                    }
                }
                textBox1.Text+= s[i];
            }
            try
            {              
                for (int i = 0; i < s.Length; i++)
                {
                    var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");
                    client.SendRequest("insert into person values (" + s[i] +")", out message);
                    client.Close();
                    textBox1.Text += message + Environment.NewLine;    
                }             
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {         
            dataGridViewTable.Columns.Clear();
            var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");
            try
            {
                dataGridViewTable.DataSource = client.SendRequest("select * from person", out message); //
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }
            textBox1.Text = message;
            client.Close();
        }
    }
}
