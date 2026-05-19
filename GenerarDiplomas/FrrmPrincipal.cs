using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenerarDiplomas
{
    public partial class FrrmPrincipal : FrmBase
    {
        public FrrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            FrmTema frmt = new FrmTema();
            frmt.Show();
        }

        private void btnSede_Click(object sender, EventArgs e)
        {
            FrmSede frms = new FrmSede();
            frms.Show();
        }

        private void btnPonente_Click(object sender, EventArgs e)
        {
            FrmPonente frmp = new FrmPonente();
            frmp.Show();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            FrmAlumno frma = new FrmAlumno();
            frma.Show();
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            FrmCurso frmc = new FrmCurso();
            frmc.Show();
        }

        private void btnCursoPonente_Click(object sender, EventArgs e)
        {
            FrmCursoPonente frmcp = new FrmCursoPonente();
            frmcp.Show();
        }

        private void btnInscripcionCurso_Click(object sender, EventArgs e)
        {
            FrmInscripcionCurso frmic = new FrmInscripcionCurso();
            frmic.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSesionCurso frmsc = new FrmSesionCurso();
            frmsc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmAsistenciaSesion fac = new FrmAsistenciaSesion();
            fac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmGenerarDiploma fgd = new FrmGenerarDiploma();
            fgd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmReconocimientoPonente frmp = new FrmReconocimientoPonente();
            frmp.Show();
        }

        private void btnAltaCursos_Click(object sender, EventArgs e)
        {
            FrmCursos frmmcu = new FrmCursos();
            frmmcu.Show();
        }

        private void btnReconocimiento_Click(object sender, EventArgs e)
        {
            FrmReconocimientoPonente frmrp = new FrmReconocimientoPonente();
            frmrp.Show();

        }
    }
}
