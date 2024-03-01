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
            dataGridViewTable.Columns.Clear();
            var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");

            try
            {
                var personRow = client.GetRandomRow();
                dataGridViewTable.DataSource = personRow;
                // dataRowInGridView(personRow);                          
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }
            client.Close();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            //DataTable dt = ToDataTable(dataGridViewTable, "person");
            try
            {
                var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");
                ServiceReference1.DataTablePersonRow dtT = new ServiceReference1.DataTablePersonRow();
                dtT.Id = System.Convert.ToInt32(dataGridViewTable.Rows[0].Cells[0].Value.ToString());
                dtT.Name = dataGridViewTable.Rows[0].Cells[1].Value.ToString();
                dtT.Id_card = System.Convert.ToInt32(dataGridViewTable.Rows[0].Cells[2].Value.ToString());
                //textBox1.Text += dtT.Id;
                client.SetTable(dtT, out message);
                client.Close();
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }
            textBox1.Text += message;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            dataGridViewTable.Columns.Clear();

            DataTable dt = new DataTable();
            var client = new ServiceReference1.CommandsClient("NetTcpBinding_ICommands");
            try
            {
                dt = client.GetTable(out message); 
                dataGridViewTable.DataSource = dt;
            }
            catch (Exception ex)
            {
                message += ex.Message;
            }
            textBox1.Text += message;
            client.Close();
        }

        public static DataTable ToDataTable(DataGridView dataGridView, string tableName)
        {

            DataGridView dgv = dataGridView;
            DataTable table = new DataTable(tableName);

            for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
            {
                table.Columns.Add(dgv.Columns[iCol].Name);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {

                DataRow datarw = table.NewRow();

                for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
                {
                    datarw[iCol] = row.Cells[iCol].Value;
                }

                table.Rows.Add(datarw);
            }

            return table;
        }
        
        /*
        void DataRowInGridView(string personRow) 
        {
            for (int i = 0; i < dataGridViewTable.Columns.Count; i++)
            {
                if (dataGridViewTable.Columns[i].Name == "id")
                {
                    dataGridViewTable.Rows[1].Cells[i].Value = personRow.Id;
                    textBox1.Text = personRow.Name.ToString();
                }
                if (dataGridViewTable.Columns[i].Name == "name")
                {
                    dataGridViewTable.Rows[1].Cells[i].Value = personRow.Name;
                }
                if (dataGridViewTable.Columns[i].Name == "id_card")
                {
                    dataGridViewTable.Rows[1].Cells[i].Value = personRow.Id_card;
                }
            }
        }
        */
    }
}
