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
        private bool parolaVizibila = false;
        private List<string> usernames = new List<string>();
        private List<string> passwords = new List<string>();

        private void Login_Load()
        {
            string query = "SELECT username, parola FROM Angajati";
            Connect con = new Connect();


            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usernames.Add(reader["Username"].ToString());
                        passwords.Add(reader["Parola"].ToString());
                    }
                }
            }
        }





        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            button2.Image = Properties.Resources.view;
            Login_Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool logged = false;
            for (int i = 0; i < usernames.Count; i++)
            {
                if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                {
                    logged = true;
                    MessageBox.Show("Login successful!");
                }
            }
            if(logged == false)
            {
                MessageBox.Show("Login failed! Please check your username and password.");
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
