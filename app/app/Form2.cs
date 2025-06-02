using Microsoft.Reporting.WinForms;
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
    public partial class Form2: Form
    {
        private int luna;
        private int an;

        public Form2(int luna, int an)
        {
            InitializeComponent();
            this.luna = luna;
            this.an = an;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            Connect connect = new Connect();
            SqlCommand command = new SqlCommand($"EXEC select_Clienti_By_Luna_report {luna}, {an}", connect.openConnection());
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);


            //reportViewer2.ProcessingMode = ProcessingMode.Local;

            //reportViewer2.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer1.LocalReport.ReportPath = "D:\\Cozma Vasile\\practica_3\\app\\app\\Report2.rdlc";

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
