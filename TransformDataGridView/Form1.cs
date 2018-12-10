using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformDataGridView
{
    public partial class Form1 : Form
    {
        private static DataTable Table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            DataTable table = Table;
            table.Columns.Add("c1");
            table.Columns.Add("c2");
            table.Columns.Add("c3");


            for (int i = 0; i < 5; i++)
            {
                var row = table.NewRow();
                row["c1"] = "v1";
                row["c2"] = "v2";
                row["c3"] = "v3";
                table.Rows.Add(row);
            }


            dataGridView1.DataSource = table;

            dataGridView1.Columns.Add("myname", "headertext");

            foreach (DataRow row in table.Rows)
            {
                row["myname"] = row["c1"].ToString().Split()
                    .Select(c => (int)c.First())
                    .Aggregate((curr, next) => curr + next);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(
                    Table.Columns.Cast<DataColumn>()
                        .Select(col => col.ColumnName)
                        .Aggregate((current, next) => $"{current}, {next}")
                );
        }
    }
}
