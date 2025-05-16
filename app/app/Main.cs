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

        Timer timer = new Timer();
        int duration = 150; // 1 secundă
        int interval = 10;
        int elapsed = 0;
        int startWidth = 0;
        int targetWidth = 250;

        private async Task AnimatePanelWidthAsync(int from, int to, int durationMs)
        {
            int steps = 30; // număr de pași (frame-uri)
            int delay = durationMs / steps;
            double delta = (double)(to - from) / steps;

            for (int i = 0; i <= steps; i++)
            {
                int newWidth = (int)(from + delta * i);
                panel1.Width = newWidth;
                await Task.Delay(delay); 
            }

            panel1.Width = to;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {


            AnimatePanel(250, 0);
            // ... animare ...

            //panel1.SuspendLayout();
            //await AnimatePanelWidthAsync(250, 0, 2);
            //panel1.ResumeLayout();



            pictureBox6.Show();
            panel1.Hide();
        }


        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            
            
            panel1.Show();

            AnimatePanel(0, 250);

            // ... animare ...

            //panel1.SuspendLayout();
            //await AnimatePanelWidthAsync(0,250, 2);
            //panel1.ResumeLayout();


            pictureBox6.Hide();
        }




        private void AnimatePanel(int fromWidth, int toWidth)
        {
            // Setăm valorile de început și final
            startWidth = fromWidth;
            targetWidth = toWidth;
            elapsed = 0;

            // Evităm adăugări multiple
            timer.Stop();
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick;
            timer.Interval = interval;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsed += interval;
            double progress = (double)elapsed / duration;
            if (progress > 1) progress = 1;

            int newWidth = (int)(startWidth + (targetWidth - startWidth) * progress);
            panel1.Width = newWidth;

            if (progress >= 1)
            {
                panel1.Width = targetWidth;
                timer.Stop();
            }
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
