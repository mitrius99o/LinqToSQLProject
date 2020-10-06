using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWinForms
{
    public partial class LastCalls : Form
    {
        SqlConnection conn;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        string connStr = @"Data Source=DESKTOP-IL0K9BD\SQLEXPRESS;Initial Catalog=phonesdb;User ID=sa;Password=sa";
        public LastCalls()
        {
            InitializeComponent();
            conn = new SqlConnection(connStr);
            conn.Open();
            sqlCommand = new SqlCommand("INSERT INTO [Last_calls] (DateTime, UserId)VALUES(@DateTime, @UserId)", conn);
            sqlCommand.Parameters.AddWithValue("DateTime", DateTime.Now);
            int selItem = Program.f.listBox1.SelectedIndex;
            sqlCommand.Parameters.AddWithValue("UserId", selItem);
        }

        private async Task LastCalls_Load(object sender, EventArgs e)
        {
            sqlCommand = new SqlCommand("SELECT * FROM [Last_calls]", conn);
            sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                listBox1.Items.Add(sqlDataReader["DateTime"] + "  " + Convert.ToString(sqlDataReader["UserId"]));
            }
            if (sqlDataReader != null)
                sqlDataReader.Close();
        }
    }
}
