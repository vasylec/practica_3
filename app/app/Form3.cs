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
    public partial class Form3: Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_telecomDataSet11.Servicii' table. You can move, or remove it, as needed.
            this.serviciiTableAdapter.Fill(this.db_telecomDataSet11.Servicii);
            // TODO: This line of code loads data into the 'db_telecomDataSet10.Abonamente' table. You can move, or remove it, as needed.
            this.abonamenteTableAdapter.Fill(this.db_telecomDataSet10.Abonamente);
            // TODO: This line of code loads data into the 'db_telecomDataSet9.NumereTelefoane' table. You can move, or remove it, as needed.
            this.numereTelefoaneTableAdapter.Fill(this.db_telecomDataSet9.NumereTelefoane);
            // TODO: This line of code loads data into the 'db_telecomDataSet8.Angajati' table. You can move, or remove it, as needed.
            this.angajatiTableAdapter.Fill(this.db_telecomDataSet8.Angajati);
            // TODO: This line of code loads data into the 'db_telecomDataSet7.Apeluri' table. You can move, or remove it, as needed.
            this.apeluriTableAdapter.Fill(this.db_telecomDataSet7.Apeluri);
            // TODO: This line of code loads data into the 'db_telecomDataSet6.Clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.db_telecomDataSet6.Clienti);

        }
    }
}
