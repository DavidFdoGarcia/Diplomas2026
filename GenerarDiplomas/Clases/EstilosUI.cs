using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GenerarDiplomas.Clases
{
    internal class EstilosUI
    {
        // COLORES PRINCIPALES
        public static Color ColorFondo = Color.FromArgb(245, 245, 245);
        public static Color ColorPrimario = Color.FromArgb(30, 144, 255);
        public static Color ColorSecundario = Color.FromArgb(255, 140, 0);
        public static Color ColorTexto = Color.Black;

        // =========================
        // FORMULARIO
        // =========================
        public static void AplicarEstiloFormulario(Form form)
        {
            form.BackColor = ColorFondo;
            form.Font = new Font("Segoe UI", 10);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        // =========================
        // BOTONES
        // =========================
        public static void EstiloBoton(Button btn)
        {
            btn.BackColor = ColorPrimario;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 35;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ColorSecundario;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = ColorPrimario;
            };
        }

        // =========================
        // TEXTBOX
        // =========================
        public static void EstiloTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10);
        }

        // =========================
        // COMBOBOX
        // =========================
        public static void EstiloComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 10);
        }

        // =========================
        // DATAGRIDVIEW
        // =========================
        public static void EstiloGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================
        // GROUPBOX
        // =========================
        public static void EstiloGroupBox(GroupBox gb)
        {
            gb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gb.ForeColor = ColorPrimario;
        }
    }
}
