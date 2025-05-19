using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Main: Form
    {

        Login login;
        public Main(Login login)
        {
            InitializeComponent();
            this.login = login;
            panel1.Hide();

            load_components();
        }


        private void load_components()
        {
            string query = "SELECT nume, prenume FROM Angajati WHERE id = " + Login.loggedID;
            Connect con = new Connect();
            string nume = "", prenume = "";

            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nume = reader["nume"].ToString();
                        prenume = reader["prenume"].ToString();
                    }
                }
            }




            label6.Text = "Bun venit, " + nume + " " + prenume + " !";
            label6.Left = (this.ClientSize.Width - label6.Width) / 2;







            panel2.Hide();
            panel3.Hide();
            panel4.Hide();

            panel_add.Hide();


        }







        private void label2_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Hide();
            panel4.Show();
        }

        private void label2_MouseEnter_1(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label2.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label3.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label3.ForeColor = Color.Black;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.previous_2;
            Cursor = Cursors.Hand;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.previous;
            Cursor = Cursors.Default;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label4.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label4.ForeColor = Color.Black;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label2.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label2.ForeColor = Color.Black;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label3.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label3.ForeColor = Color.Black;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label4.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label4.ForeColor = Color.Black;
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();



            pictureBox7.Show();
            panel1.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel1.Show();
            pictureBox7.Hide();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label7_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            pictureBox6.Hide();
            label5.Hide();
            label6.Hide();



            panel2.Hide();
            panel3.Hide();
            panel4.Hide();

            panel1.Hide();

            pictureBox7.Show();




            panel_add.Show();

        }

    }
}
