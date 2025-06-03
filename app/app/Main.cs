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
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using Azure.AI.OpenAI;
using Microsoft.Reporting;


namespace app
{
    public partial class Main: Form
    {

        Login login;
        int selectedPanel = 0;
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

            

            showSpecificPanel(0);






            textBox1.KeyDown += textBox_KeyDown;
            textBox2.KeyDown += textBox_KeyDown;
            textBox3.KeyDown += textBox_KeyDown;
            textBox4.KeyDown += textBox_KeyDown;
            textBox5.KeyDown += textBox_KeyDown;

            textBox6.KeyDown += textBox2_KeyDown;
            textBox7.KeyDown += textBox2_KeyDown;






            



        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
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
            sidePanelClick();



            showSpecificPanel(1);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            sidePanelClick();

            showSpecificPanel(2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" & textBox5.Text != "") {

                try
                {
                    string query = "EXEC add_client '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "'";
                    Connect con = new Connect();

                    using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Clientul a fost adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) {
                    MessageBox.Show("Ai întâmpinat o eroare: "+ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nu puteți lăsa câmpuri goale !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            //Add client
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add nr


            if (textBox6.Text != "" && textBox7.Text != "")
            {

                try
                {
                    int k = 0;
                    if (checkBox1.Checked)
                        k = 1;


                    string query = "EXEC add_nr '" + textBox6.Text.Trim() + "', '" + textBox7.Text + "', '" + k + "'";
                    Connect con = new Connect();

                    using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Numarul de telefon a fost adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ai întâmpinat o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nu puteți lăsa câmpuri goale !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                try
                {
                    string query = "EXEC delete_nr '" + textBox8.Text + "'";
                    Connect con = new Connect();
                    using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                    {
                        int rowsAffected =  cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Clientul a fost șters cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Numărul dat nu există în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ai întâmpinat o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    textBox8.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nu puteți lăsa câmpuri goale !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.vw_luckyNumbersTableAdapter.Fill(this.db_telecomDataSet2.vw_luckyNumbers);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            sidePanelClick();

            showSpecificPanel(3);
        }

        private void sidePanelClick()
        {
            pictureBox6.Hide();
            label5.Hide();
            label6.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel1.Hide();

            pictureBox7.Show();
        }

        private void showSpecificPanel(int n)
        {
            dataGridView2.DataSource = null;
            textBox9.Text = null;
            textBox10.Text = null;

            panel_add.Hide();
            panel_luckyNumbers.Hide();
            panel_remove.Hide();
            panel_tel.Hide();
            panel_report.Hide();
            panel5.Hide();

            switch (n)
            {
                case 0:
                    panel_luckyNumbers.Hide();
                    panel_remove.Hide();
                    panel_tel.Hide();
                    panel_add.Hide();
                    break;
                case 1:
                    panel_add.Show();
                    break;
                case 2:
                    panel_remove.Show();
                    break;
                case 3:
                    panel_luckyNumbers.Show();
                    break;
                case 4:
                    panel_tel.Show();
                    break;
                case 5:
                    panel_report.Show();
                    break;
                case 6:
                    panel5.Show();
                    break;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sidePanelClick();
            showSpecificPanel(4);

            label27.Text = "Nume";
            textBox10.Show();
            label28.Show();
            button4.Show();
            button5.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string query = "EXEC select_Tel_By_Name '" + textBox9.Text + "', '" + textBox10.Text + "'";

            Connect con = new Connect();

            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            showSpecificPanel(4);
            sidePanelClick();
            selectedPanel = 1;

            button4.Hide();
            button5.Show();
            textBox10.Hide();
            label28.Hide();
            label27.Text = "Număr de telefon";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(selectedPanel == 1)
            {
                string query = "EXEC select_NameAdress_By_Tel '" + textBox9.Text + "'";

                Connect con = new Connect();

                using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            else if(selectedPanel == 2)
            {
                string query = "SELECT * FROM NumereTelefoane\r\nWHERE YEAR(dataInregistrare) > " + textBox9.Text;

                Connect con = new Connect();

                using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            showSpecificPanel(4);
            sidePanelClick();
            selectedPanel = 2;

            button4.Hide();
            button5.Show();
            textBox10.Hide();
            label28.Hide();
            label27.Text = "Anul";


            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            label29.Show();button6.Show();
            label31.Hide();label32.Hide();textBox11.Hide();textBox12.Hide();button7.Hide();button8.Hide();
            showSpecificPanel(5);   sidePanelClick();
            string query = "SELECT * FROM Clienti";

            DataTable dt = new DataTable();
            Connect con = new Connect();


            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "export.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string query = "SELECT * FROM Clienti";
                        Connect con = new Connect();

                        using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Export");
                                wb.SaveAs(sfd.FileName);
                            }

                            MessageBox.Show("Exportul a fost realizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la export: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        

        private void label30_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            label30.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void label30_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            label30.ForeColor = Color.Black;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label29.Hide(); button6.Hide();
            label31.Show(); label32.Show(); textBox11.Show(); textBox12.Show(); button7.Show(); button8.Show();
            dataGridView3.DataSource = null;
            showSpecificPanel(5);sidePanelClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int luna = Convert.ToInt32(textBox11.Text);
                int anul = Convert.ToInt32(textBox12.Text);

                string query = "EXEC select_Clienti_By_Luna " + luna + ", " + anul;
                Connect con = new Connect();

                using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ai întâmpinat o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox11.Text = "";
                textBox12.Text = "";
            }

        }

        private void label15_Click(object sender, EventArgs e)
        {
            sidePanelClick();

            Form1 f = new Form1();
            f.Closed += (s, args) => this.Show();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text));
            f.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            sidePanelClick();
            showSpecificPanel(6);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM dbo.fn_TelefoanePeStrada('{textBox13.Text}')";

            DataTable dt = new DataTable();
            Connect con = new Connect();


            using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
                dataGridView4.DataSource = dt;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"EXEC CopiazaTelefoanePeStrada '{textBox13.Text}'";

                DataTable dt = new DataTable();
                Connect con = new Connect();


                using (SqlCommand cmd = new SqlCommand(query, con.openConnection()))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Telefoanele au fost copiate cu succes în tabela: TelefoanePeStrada !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Ai întâmpinat o eroare: " + err.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { 
                textBox13.Text = "";
                dataGridView4.DataSource = null;
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
    }   
}

//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
