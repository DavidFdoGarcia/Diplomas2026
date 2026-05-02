using GenerarDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenerarDiplomas
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            // 🔥 ESTO EVITA QUE EL DISEÑADOR TRUENE
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            base.OnLoad(e);
        }
        private void FrmBase_Load(object sender, EventArgs e)
        {
            EstilosUI.EstiloBoton(btnSalir);
        }
    }
}
