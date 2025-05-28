using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Login: Form
    {
        private List<string> usernames = new List<string>();
        private List<string> passwords = new List<string>();
        private List<string> id = new List<string>();

        public static string loggedID;

        private void Login_Load()
        {
            string query = "SELECT id, username, parola FROM Angajati";
            Connect con = new Connect();
            
            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id.Add(reader["id"].ToString());
                        usernames.Add(reader["Username"].ToString());
                        passwords.Add(reader["Parola"].ToString());
                    }
                }
            }

            id.Add("-1");
            usernames.Add("1");
            passwords.Add("1");

        }





        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            button2.Image = Properties.Resources.view;
            textBox1.KeyDown += textBox_KeyDown;
            textBox2.KeyDown += textBox_KeyDown;
            Login_Load();

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            label3.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(sender, e);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool logged = false;
            for (int i = 0; i < usernames.Count; i++)
            {
                if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                {
                    loggedID = id[i];
                    logged = true;
                    Form1 f = new Form1();
                    f.Show();
                    //Main main = new Main(this);
                    //main.Show();
                    this.Hide();
                }
            }
            if(logged == false)
            {
                label3.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                button2.Image = Properties.Resources.hide;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                button2.Image = Properties.Resources.view;
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
