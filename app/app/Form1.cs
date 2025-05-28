using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        ReportViewer reportViewer1;

        public Form1()
        {
            InitializeComponent();
            reportViewer1 = new ReportViewer();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);

            reportViewer1.LocalReport.ReportPath = "D:\\Cozma Vasile\\practica_3\\app\\app\\Report1.rdlc";
            reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
