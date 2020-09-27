using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToSqlProject;

namespace ViewWinForms
{
    public partial class Form1 : Form
    {
        IQueryable<User> users;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            IQueryable<User> selectedGroup;
            if (radioButton1.Checked)
                selectedGroup = users.Where(x => x.Name == textBox1.Text);
            else
                selectedGroup = users.Where(x => x.Telephone == textBox1.Text);

            foreach (User user in selectedGroup)
                listBox2.Items.Add($"{user.Name} {user.Telephone}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Подключение к базе данных
            DataContext db = new DataContext(@"Data Source=DESKTOP-IL0K9BD\SQLEXPRESS;Initial Catalog=phonesdb;User ID=sa;Password=sa");

            //Получить таблицу из бд
            users = db.GetTable<User>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                foreach (User user in users)
                    listBox1.Items.Add($"{user.Id} {user.Name} {user.Telephone}");
            }
        }
    }
}
