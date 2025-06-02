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
using Microsoft.Reporting.WinForms;

namespace app
{
    public partial class Form1: Form
    {
        public ReportViewer reportViewer1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {
            Connect connect = new Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM evidenta_telFix", connect.openConnection());
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);



            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer2.LocalReport.ReportPath = "D:\\Cozma Vasile\\practica_3\\app\\app\\Report1.rdlc";

            reportViewer2.LocalReport.DataSources.Add(rds);

            reportViewer2.RefreshReport();
        }
    }
}
