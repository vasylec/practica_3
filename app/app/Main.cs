using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            panel1.Left = -200;
        }

      




    
        private void label2_Click(object sender, EventArgs e)
        {

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
            panel1.Hide();
            pictureBox6.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Show();
            pictureBox6.Hide();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
