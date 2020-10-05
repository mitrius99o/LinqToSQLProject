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
        DataContext db;
        IQueryable<User> users;
        IQueryable<Call> calls;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            //*---C о з д а н и е   з а п р о с о в   L I N Q---*//
            IQueryable<User> selectedGroup;
            if (radioButton1.Checked)
                selectedGroup = users.Where(x => x.Name == textBox1.Text);
            else
                selectedGroup = users.Where(x => x.Telephone == textBox1.Text);

            //*---В ы п о л н е н и е   з а п р о с о в   L I N Q---*//
            foreach (User user in selectedGroup)
                listBox2.Items.Add($"{user.Name} {user.Surname} {user.Telephone}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Подключение к базе данных
            db = new DataContext(@"Data Source=DESKTOP-IL0K9BD\SQLEXPRESS;Initial Catalog=phonesdb;User ID=sa;Password=sa");

            //Получить таблицу из бд
            users = db.GetTable<User>();
            calls = db.GetTable<Call>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                foreach (User user in users)
                    listBox1.Items.Add($"{user.Id} {user.Name} {user.Surname} {user.Telephone}");
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //добавляем выбранного объекта в listbox в таблицу Last_calls
            //вызываем новую форму, в которой будет listbox с последними звонками контактам
        }
    }
}
