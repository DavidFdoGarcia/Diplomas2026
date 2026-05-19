using GenerarDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GenerarDiplomas
{
    public partial class FrmCursos : FrmBase
    {
        private bool esEdicion = false;

        public FrmCursos()
        {
            InitializeComponent();
        }

        private void FrmCursos_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvCursos);

            txtID.Enabled = false;
            rbActivo.Checked = true;

            ConfigurarGrid();
            CargarCursos();
            LimpiarCampos();
        }

        private void ConfigurarGrid()
        {
            dgvCursos.ReadOnly = true;
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AllowUserToDeleteRows = false;
            dgvCursos.MultiSelect = false;
            dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursos.RowHeadersVisible = false;
        }

        private void CargarCursos(string filtro = "")
        {
            string query = @"
                SELECT
                    IdCurso,
                    NombreCurso,
                    FechaInicio,
                    FechaFin,
                    CASE WHEN Activo = 1
                         THEN 'Activo'
                         ELSE 'Inactivo'
                    END AS Estado
                FROM Curso
                WHERE NombreCurso LIKE @filtro
                ORDER BY NombreCurso";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + txtBuscar.Text.Trim() + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            dgvCursos.DataSource = dt;

            if (dgvCursos.Columns.Count > 0)
            {
                dgvCursos.Columns["IdCurso"].HeaderText = "ID";
                dgvCursos.Columns["NombreCurso"].HeaderText = "Curso";
                dgvCursos.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                dgvCursos.Columns["FechaFin"].HeaderText = "Fecha Fin";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombreCurso.Clear();
            txtBuscar.Clear();

            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            esEdicion = false;

            errorProvider1.Clear();

            txtNombreCurso.Focus();
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombreCurso.Text))
            {
                errorProvider1.SetError(txtNombreCurso, "Ingrese el nombre del curso.");
                valido = false;
            }

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                errorProvider1.SetError(dtpFechaFin, "La fecha final no puede ser menor.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteCurso(string nombreCurso, int idCurso = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Curso
                WHERE NombreCurso = @NombreCurso
                  AND (@IdCurso = 0 OR IdCurso <> @IdCurso)";

            var parametros = new Dictionary<string, object>
            {
                { "@NombreCurso", nombreCurso },
                { "@IdCurso", idCurso }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);

            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarCurso()
        {
            if (!ValidarCampos())
                return;

            string nombreCurso = txtNombreCurso.Text.Trim();

            int idCurso = 0;

            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idCurso = Convert.ToInt32(txtID.Text);

            if (ExisteCurso(nombreCurso, idCurso))
            {
                MessageBox.Show("Ya existe un curso con ese nombre.");
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@NombreCurso", nombreCurso },
                { "@FechaInicio", dtpFechaInicio.Value.Date },
                { "@FechaFin", dtpFechaFin.Value.Date },
                { "@Activo", rbActivo.Checked }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO Curso
                    (
                        NombreCurso,
                        FechaInicio,
                        FechaFin,
                        Activo
                    )
                    VALUES
                    (
                        @NombreCurso,
                        @FechaInicio,
                        @FechaFin,
                        @Activo
                    )";

                consultas.Ejecutar(insert, parametros);

                MessageBox.Show("Curso guardado correctamente.");
            }
            else
            {
                parametros.Add("@IdCurso", idCurso);

                string update = @"
                    UPDATE Curso
                    SET NombreCurso = @NombreCurso,
                        FechaInicio = @FechaInicio,
                        FechaFin = @FechaFin,
                        Activo = @Activo
                    WHERE IdCurso = @IdCurso";

                consultas.Ejecutar(update, parametros);

                MessageBox.Show("Curso actualizado correctamente.");
            }

            CargarCursos();
            LimpiarCampos();
        }

        private void CargarCursoSeleccionado()
        {
            if (dgvCursos.CurrentRow == null)
                return;

            int idCurso = Convert.ToInt32(
                dgvCursos.CurrentRow.Cells["IdCurso"].Value);

            string query = @"
                SELECT
                    IdCurso,
                    NombreCurso,
                    FechaInicio,
                    FechaFin,
                    Activo
                FROM Curso
                WHERE IdCurso = @IdCurso";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdCurso"].ToString();
            txtNombreCurso.Text = row["NombreCurso"].ToString();

            dtpFechaInicio.Value = Convert.ToDateTime(row["FechaInicio"]);
            dtpFechaFin.Value = Convert.ToDateTime(row["FechaFin"]);

            bool activo = Convert.ToBoolean(row["Activo"]);

            rbActivo.Checked = activo;
            rbInactivo.Checked = !activo;

            esEdicion = true;
        }


        private void dgvCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarCursoSeleccionado();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            GuardarCurso();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarCursoSeleccionado();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCursos(txtBuscar.Text.Trim());
        }

        private void dgvCursos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarCursoSeleccionado();
        }
    }
}