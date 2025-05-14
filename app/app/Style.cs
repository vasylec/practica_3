using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace app
{
    class Style
    {
        public void StilizeazaControale(Control.ControlCollection controls, Form form)
        {
            form.BackColor = Color.FromArgb(25, 25, 35);
            foreach (Control c in controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(0, 102, 204); // albastru telecom
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.FlatAppearance.BorderSize = 0;
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = Color.Gainsboro;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(40, 40, 50);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 10);
                }
                else if (c is ComboBox combo)
                {
                    combo.BackColor = Color.FromArgb(40, 40, 50);
                    combo.ForeColor = Color.White;
                    combo.FlatStyle = FlatStyle.Flat;
                    combo.Font = new Font("Segoe UI", 10);
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.FromArgb(30, 30, 40);
                    dgv.ForeColor = Color.White;
                    dgv.GridColor = Color.Gray;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }

                // Recursiv pentru controalele container (Panel, GroupBox, etc.)
                //if (c.HasChildren)
                //    StilizeazaControale(c.Controls);
            }
        }
        //private void StilizeazaPaginaAdmin()
        //{
        //    this.BackColor = Color.FromArgb(25, 25, 35);
        //    StilizeazaControale(this.Controls);
        //}


        //private void RotunjesteButonul(Button btn, int raza)
        //{
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddArc(0, 0, raza, raza, 180, 90);
        //    path.AddArc(btn.Width - raza, 0, raza, raza, 270, 90);
        //    path.AddArc(btn.Width - raza, btn.Height - raza, raza, raza, 0, 90);
        //    path.AddArc(0, btn.Height - raza, raza, raza, 90, 90);
        //    path.CloseFigure();

        //    btn.Region = new Region(path);
        //}
    }
}
