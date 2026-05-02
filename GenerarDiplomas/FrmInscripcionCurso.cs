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
    public partial class FrmInscripcionCurso : FrmBase
    {

        private bool esEdicion = false;

        public FrmInscripcionCurso()
        {
            InitializeComponent();
        }

        private void FrmInscripcionCurso_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvInscripciones);

            txtID.Enabled = false;
            txtObservaciones.Multiline = true;

            ConfigurarGrid();
            CargarCursos();
            CargarAlumnos();
            CargarEstatus();
            CargarInscripciones();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.AllowUserToAddRows = false;
            dgvInscripciones.AllowUserToDeleteRows = false;
            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInscripciones.RowHeadersVisible = false;
        }

        private void CargarCursos()
        {
            string query = @"
                SELECT IdCurso, NombreCurso
                FROM Curso
                WHERE Activo = 1
                ORDER BY NombreCurso";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbCurso.DataSource = dt;
            cmbCurso.DisplayMember = "NombreCurso";
            cmbCurso.ValueMember = "IdCurso";
            cmbCurso.SelectedIndex = -1;
        }

        private void CargarAlumnos()
        {
            string query = @"
                SELECT IdAlumno, NombreCompleto
                FROM Alumno
                WHERE Activo = 1
                ORDER BY NombreCompleto";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbAlumno.DataSource = dt;
            cmbAlumno.DisplayMember = "NombreCompleto";
            cmbAlumno.ValueMember = "IdAlumno";
            cmbAlumno.SelectedIndex = -1;
        }

        private void CargarEstatus()
        {
            cmbEstatus.Items.Clear();
            cmbEstatus.Items.Add("INSCRITO");
            cmbEstatus.Items.Add("CANCELADO");
            cmbEstatus.Items.Add("CONCLUIDO");
            cmbEstatus.SelectedIndex = -1;
        }

        private void CargarInscripciones(string filtro = "")
        {
            string query = @"
                SELECT
                    i.IdInscripcion,
                    c.NombreCurso,
                    a.NombreCompleto,
                    i.FechaInscripcion,
                    i.FolioInscripcion,
                    i.Estatus,
                    i.Observaciones
                FROM InscripcionCurso i
                INNER JOIN Curso c ON c.IdCurso = i.IdCurso
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                WHERE c.NombreCurso LIKE @filtro
                   OR a.NombreCompleto LIKE @filtro
                   OR ISNULL(i.FolioInscripcion, '') LIKE @filtro
                   OR i.Estatus LIKE @filtro
                ORDER BY i.IdInscripcion DESC";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvInscripciones.DataSource = dt;

            if (dgvInscripciones.Columns.Count > 0)
            {
                dgvInscripciones.Columns["IdInscripcion"].HeaderText = "ID";
                dgvInscripciones.Columns["NombreCurso"].HeaderText = "Curso";
                dgvInscripciones.Columns["NombreCompleto"].HeaderText = "Alumno";
                dgvInscripciones.Columns["FechaInscripcion"].HeaderText = "Fecha Inscripción";
                dgvInscripciones.Columns["FolioInscripcion"].HeaderText = "Folio";
                dgvInscripciones.Columns["Observaciones"].HeaderText = "Observaciones";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtFolioInscripcion.Clear();
            txtObservaciones.Clear();
            txtBuscar.Clear();

            cmbCurso.SelectedIndex = -1;
            cmbAlumno.SelectedIndex = -1;
            cmbEstatus.SelectedIndex = -1;

            dtpFechaInscripcion.Value = DateTime.Today;

            esEdicion = false;
            errorProvider1.Clear();
            cmbCurso.Focus();
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cmbCurso.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbCurso, "Seleccione un curso.");
                valido = false;
            }

            if (cmbAlumno.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbAlumno, "Seleccione un alumno.");
                valido = false;
            }

            if (txtFolioInscripcion.Text.Trim().Length > 50)
            {
                errorProvider1.SetError(txtFolioInscripcion, "El folio no debe exceder 50 caracteres.");
                valido = false;
            }

            if (cmbEstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbEstatus, "Seleccione un estatus.");
                valido = false;
            }

            if (txtObservaciones.Text.Trim().Length > 500)
            {
                errorProvider1.SetError(txtObservaciones, "Las observaciones no deben exceder 500 caracteres.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteInscripcion(int idCurso, int idAlumno, int idInscripcion = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM InscripcionCurso
                WHERE IdCurso = @IdCurso
                  AND IdAlumno = @IdAlumno
                  AND (@IdInscripcion = 0 OR IdInscripcion <> @IdInscripcion)";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdAlumno", idAlumno },
                { "@IdInscripcion", idInscripcion }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarInscripcion()
        {
            if (!ValidarCampos())
                return;

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int idAlumno = Convert.ToInt32(cmbAlumno.SelectedValue);
            DateTime fechaInscripcion = dtpFechaInscripcion.Value.Date;
            string folio = txtFolioInscripcion.Text.Trim();
            string estatus = cmbEstatus.Text;
            string observaciones = txtObservaciones.Text.Trim();

            int idInscripcion = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idInscripcion = Convert.ToInt32(txtID.Text);

            if (ExisteInscripcion(idCurso, idAlumno, idInscripcion))
            {
                MessageBox.Show("Ese alumno ya está inscrito en ese curso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlumno.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdAlumno", idAlumno },
                { "@FechaInscripcion", fechaInscripcion },
                { "@FolioInscripcion", string.IsNullOrWhiteSpace(folio) ? DBNull.Value : folio },
                { "@Estatus", estatus },
                { "@Observaciones", string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : observaciones }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO InscripcionCurso
                    (
                        IdCurso,
                        IdAlumno,
                        FechaInscripcion,
                        FolioInscripcion,
                        Estatus,
                        Observaciones
                    )
                    VALUES
                    (
                        @IdCurso,
                        @IdAlumno,
                        @FechaInscripcion,
                        @FolioInscripcion,
                        @Estatus,
                        @Observaciones
                    )";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Inscripción guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdInscripcion", idInscripcion);

                string update = @"
                    UPDATE InscripcionCurso
                    SET IdCurso = @IdCurso,
                        IdAlumno = @IdAlumno,
                        FechaInscripcion = @FechaInscripcion,
                        FolioInscripcion = @FolioInscripcion,
                        Estatus = @Estatus,
                        Observaciones = @Observaciones
                    WHERE IdInscripcion = @IdInscripcion";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Inscripción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarInscripciones();
            LimpiarCampos();
        }

        private void CargarInscripcionSeleccionada()
        {
            if (dgvInscripciones.CurrentRow == null)
                return;

            int idInscripcion = Convert.ToInt32(dgvInscripciones.CurrentRow.Cells["IdInscripcion"].Value);

            string query = @"
                SELECT
                    IdInscripcion,
                    IdCurso,
                    IdAlumno,
                    FechaInscripcion,
                    FolioInscripcion,
                    Estatus,
                    Observaciones
                FROM InscripcionCurso
                WHERE IdInscripcion = @IdInscripcion";

            var parametros = new Dictionary<string, object>
            {
                { "@IdInscripcion", idInscripcion }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdInscripcion"].ToString();
            cmbCurso.SelectedValue = Convert.ToInt32(row["IdCurso"]);
            cmbAlumno.SelectedValue = Convert.ToInt32(row["IdAlumno"]);
            dtpFechaInscripcion.Value = Convert.ToDateTime(row["FechaInscripcion"]);
            txtFolioInscripcion.Text = row["FolioInscripcion"] == DBNull.Value ? "" : row["FolioInscripcion"].ToString();
            cmbEstatus.Text = row["Estatus"].ToString();
            txtObservaciones.Text = row["Observaciones"] == DBNull.Value ? "" : row["Observaciones"].ToString();

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarInscripcion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarInscripcionSeleccionada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarInscripciones(txtBuscar.Text.Trim());
        }

        private void dgvInscripciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarInscripcionSeleccionada();
        }
    }
}
