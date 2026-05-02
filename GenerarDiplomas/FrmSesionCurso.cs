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
    public partial class FrmSesionCurso : FrmBase
    {
        private bool esEdicion = false;
        public FrmSesionCurso()
        {
            InitializeComponent();
        }

        private void FrmSesionCurso_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvSesiones);

            txtID.Enabled = false;
            txtTemaSesion.Multiline = true;
            txtObservaciones.Multiline = true;

            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.ShowUpDown = true;

            ConfigurarGrid();
            CargarCursos();
            CargarSesiones();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvSesiones.ReadOnly = true;
            dgvSesiones.AllowUserToAddRows = false;
            dgvSesiones.AllowUserToDeleteRows = false;
            dgvSesiones.MultiSelect = false;
            dgvSesiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSesiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSesiones.RowHeadersVisible = false;
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

        private void CargarSesiones(string filtro = "")
        {
            string query = @"
                SELECT
                    s.IdSesion,
                    c.NombreCurso,
                    s.NumeroSesion,
                    s.FechaSesion,
                    s.HoraInicio,
                    s.HoraFin,
                    s.TemaSesion,
                    s.Observaciones
                FROM SesionCurso s
                INNER JOIN Curso c ON c.IdCurso = s.IdCurso
                WHERE c.NombreCurso LIKE @filtro
                   OR ISNULL(s.TemaSesion, '') LIKE @filtro
                ORDER BY c.NombreCurso, s.NumeroSesion";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvSesiones.DataSource = dt;

            if (dgvSesiones.Columns.Count > 0)
            {
                dgvSesiones.Columns["IdSesion"].HeaderText = "ID";
                dgvSesiones.Columns["NombreCurso"].HeaderText = "Curso";
                dgvSesiones.Columns["NumeroSesion"].HeaderText = "Sesión";
                dgvSesiones.Columns["FechaSesion"].HeaderText = "FechaSesion";
                dgvSesiones.Columns["HoraInicio"].HeaderText = "Hora Inicio";
                dgvSesiones.Columns["HoraFin"].HeaderText = "Hora Fin";
                dgvSesiones.Columns["TemaSesion"].HeaderText = "Tema";
                dgvSesiones.Columns["Observaciones"].HeaderText = "Observaciones";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNumeroSesion.Clear();
            txtTemaSesion.Clear();
            txtObservaciones.Clear();
            txtBuscar.Clear();

            cmbCurso.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Today;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(10);

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

            if (string.IsNullOrWhiteSpace(txtNumeroSesion.Text) ||
                !int.TryParse(txtNumeroSesion.Text.Trim(), out int numero) || numero <= 0)
            {
                errorProvider1.SetError(txtNumeroSesion, "Ingrese un número de sesión válido.");
                valido = false;
            }

            if (dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay)
            {
                errorProvider1.SetError(dtpHoraFin, "La hora fin debe ser mayor.");
                valido = false;
            }

            if (txtTemaSesion.Text.Trim().Length > 300)
            {
                errorProvider1.SetError(txtTemaSesion, "El tema no debe exceder 300 caracteres.");
                valido = false;
            }

            if (txtObservaciones.Text.Trim().Length > 500)
            {
                errorProvider1.SetError(txtObservaciones, "Las observaciones no deben exceder 500 caracteres.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteSesion(int idCurso, int numeroSesion, int idSesion = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM SesionCurso
                WHERE IdCurso = @IdCurso
                  AND NumeroSesion = @NumeroSesion
                  AND (@IdSesion = 0 OR IdSesion <> @IdSesion)";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@NumeroSesion", numeroSesion },
                { "@IdSesion", idSesion }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarSesion()
        {
            if (!ValidarCampos())
                return;

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int numeroSesion = Convert.ToInt32(txtNumeroSesion.Text.Trim());
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;
            string tema = txtTemaSesion.Text.Trim();
            string observaciones = txtObservaciones.Text.Trim();

            int idSesion = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idSesion = Convert.ToInt32(txtID.Text);

            if (ExisteSesion(idCurso, numeroSesion, idSesion))
            {
                MessageBox.Show("Ya existe esa sesión para ese curso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@NumeroSesion", numeroSesion },
                { "@Fecha", fecha },
                { "@HoraInicio", horaInicio },
                { "@HoraFin", horaFin },
                { "@TemaSesion", string.IsNullOrWhiteSpace(tema) ? DBNull.Value : tema },
                { "@Observaciones", string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : observaciones }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO SesionCurso
                    (IdCurso, NumeroSesion, FechaSesion, HoraInicio, HoraFin, TemaSesion, Observaciones)
                    VALUES
                    (@IdCurso, @NumeroSesion, @Fecha, @HoraInicio, @HoraFin, @TemaSesion, @Observaciones)";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Sesión guardada.", "Éxito");
            }
            else
            {
                parametros.Add("@IdSesion", idSesion);

                string update = @"
                    UPDATE SesionCurso
                    SET IdCurso = @IdCurso,
                        NumeroSesion = @NumeroSesion,
                        FechaSesion = @Fecha,
                        HoraInicio = @HoraInicio,
                        HoraFin = @HoraFin,
                        TemaSesion = @TemaSesion,
                        Observaciones = @Observaciones
                    WHERE IdSesion = @IdSesion";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Sesión actualizada.", "Éxito");
            }

            CargarSesiones();
            LimpiarCampos();
        }

        private void CargarSesionSeleccionada()
        {
            if (dgvSesiones.CurrentRow == null)
                return;

            int idSesion = Convert.ToInt32(dgvSesiones.CurrentRow.Cells["IdSesion"].Value);

            string query = @"
                SELECT *
                FROM SesionCurso
                WHERE IdSesion = @IdSesion";

            var parametros = new Dictionary<string, object>
            {
                { "@IdSesion", idSesion }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdSesion"].ToString();
            cmbCurso.SelectedValue = Convert.ToInt32(row["IdCurso"]);
            txtNumeroSesion.Text = row["NumeroSesion"].ToString();
            dtpFecha.Value = Convert.ToDateTime(row["Fecha"]);
            dtpHoraInicio.Value = DateTime.Today.Add((TimeSpan)row["HoraInicio"]);
            dtpHoraFin.Value = DateTime.Today.Add((TimeSpan)row["HoraFin"]);
            txtTemaSesion.Text = row["TemaSesion"] == DBNull.Value ? "" : row["TemaSesion"].ToString();
            txtObservaciones.Text = row["Observaciones"] == DBNull.Value ? "" : row["Observaciones"].ToString();

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarSesion();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            GuardarSesion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarSesionSeleccionada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CargarSesiones(txtBuscar.Text.Trim());
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarSesionSeleccionada();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
