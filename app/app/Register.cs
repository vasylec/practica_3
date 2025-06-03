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
    public partial class Register: Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string idnp = textBox3.Text;
            string email = textBox4.Text;
            string adresa = textBox5.Text;
            string username = textBox6.Text;
            string parola = textBox7.Text;

            string functie = comboBox2.SelectedItem?.ToString() ?? string.Empty;
            string localitate = comboBox1.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(prenume) ||
                string.IsNullOrWhiteSpace(idnp) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(adresa) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(parola) || string.IsNullOrWhiteSpace(functie) || string.IsNullOrWhiteSpace(localitate)
                )
            {
                MessageBox.Show("Toate campurile sunt obligatorii!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string querry = $"EXEC register '{nume}', '{prenume}', '{idnp}', '{email}', '{adresa}' , '{functie}', '{username}', '{parola}', '{localitate}'";

            Connect con = new Connect();
            using (SqlCommand cmd = new SqlCommand(querry, con.openConnection()))
            {
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inregistrare reusita!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Inregistrarea a esuat. Va rugam incercati din nou.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"A aparut o eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
