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
    public partial class FrmCurso : FrmBase
    {
        private bool esEdicion = false;
        public FrmCurso()
        {
            InitializeComponent();
        }

        private void FrmCurso_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvCursoTema);

            txtID.Enabled = false;

            ConfigurarGrid();
            CargarCursos();
            CargarTemas();
            CargarCursoTemas();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvCursoTema.ReadOnly = true;
            dgvCursoTema.AllowUserToAddRows = false;
            dgvCursoTema.AllowUserToDeleteRows = false;
            dgvCursoTema.MultiSelect = false;
            dgvCursoTema.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursoTema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursoTema.RowHeadersVisible = false;
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

        private void CargarTemas()
        {
            string query = @"
                SELECT IdTema, NombreTema
                FROM Tema
                WHERE Activo = 1
                ORDER BY NombreTema";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbTema.DataSource = dt;
            cmbTema.DisplayMember = "NombreTema";
            cmbTema.ValueMember = "IdTema";
            cmbTema.SelectedIndex = -1;
        }

        private void CargarCursoTemas(string filtro = "")
        {
            string query = @"
                SELECT
                    ct.IdCursoTema,
                    c.NombreCurso,
                    t.NombreTema,
                    ct.OrdenTema
                FROM CursoTema ct
                INNER JOIN Curso c ON c.IdCurso = ct.IdCurso
                INNER JOIN Tema t ON t.IdTema = ct.IdTema
                WHERE c.NombreCurso LIKE @filtro
                   OR t.NombreTema LIKE @filtro
                ORDER BY c.NombreCurso, ct.OrdenTema, t.NombreTema";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvCursoTema.DataSource = dt;

            if (dgvCursoTema.Columns.Count > 0)
            {
                dgvCursoTema.Columns["IdCursoTema"].HeaderText = "ID";
                dgvCursoTema.Columns["NombreCurso"].HeaderText = "Curso";
                dgvCursoTema.Columns["NombreTema"].HeaderText = "Tema";
                dgvCursoTema.Columns["OrdenTema"].HeaderText = "Orden";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtOrdenTema.Clear();
            txtBuscar.Clear();

            cmbCurso.SelectedIndex = -1;
            cmbTema.SelectedIndex = -1;

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

            if (cmbTema.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbTema, "Seleccione un tema.");
                valido = false;
            }

            if (!string.IsNullOrWhiteSpace(txtOrdenTema.Text) &&
                !int.TryParse(txtOrdenTema.Text.Trim(), out _))
            {
                errorProvider1.SetError(txtOrdenTema, "Ingrese un número entero válido.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteCursoTema(int idCurso, int idTema, int idCursoTema = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM CursoTema
                WHERE IdCurso = @IdCurso
                  AND IdTema = @IdTema
                  AND (@IdCursoTema = 0 OR IdCursoTema <> @IdCursoTema)";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdTema", idTema },
                { "@IdCursoTema", idCursoTema }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarCursoTema()
        {
            if (!ValidarCampos())
                return;

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int idTema = Convert.ToInt32(cmbTema.SelectedValue);
            int? ordenTema = string.IsNullOrWhiteSpace(txtOrdenTema.Text) ? null : Convert.ToInt32(txtOrdenTema.Text.Trim());

            int idCursoTema = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idCursoTema = Convert.ToInt32(txtID.Text);

            if (ExisteCursoTema(idCurso, idTema, idCursoTema))
            {
                MessageBox.Show("Ese tema ya está asignado a ese curso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTema.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdTema", idTema },
                { "@OrdenTema", ordenTema.HasValue ? ordenTema.Value : DBNull.Value }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO CursoTema (IdCurso, IdTema, OrdenTema)
                    VALUES (@IdCurso, @IdTema, @OrdenTema)";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Tema asignado al curso correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdCursoTema", idCursoTema);

                string update = @"
                    UPDATE CursoTema
                    SET IdCurso = @IdCurso,
                        IdTema = @IdTema,
                        OrdenTema = @OrdenTema
                    WHERE IdCursoTema = @IdCursoTema";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Asignación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarCursoTemas();
            LimpiarCampos();
        }

        private void CargarCursoTemaSeleccionado()
        {
            if (dgvCursoTema.CurrentRow == null)
                return;

            int idCursoTema = Convert.ToInt32(dgvCursoTema.CurrentRow.Cells["IdCursoTema"].Value);

            string query = @"
                SELECT IdCursoTema, IdCurso, IdTema, OrdenTema
                FROM CursoTema
                WHERE IdCursoTema = @IdCursoTema";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCursoTema", idCursoTema }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdCursoTema"].ToString();
            cmbCurso.SelectedValue = Convert.ToInt32(row["IdCurso"]);
            cmbTema.SelectedValue = Convert.ToInt32(row["IdTema"]);
            txtOrdenTema.Text = row["OrdenTema"] == DBNull.Value ? "" : row["OrdenTema"].ToString();

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCursoTema();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarCursoTemaSeleccionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCursoTemas(txtBuscar.Text.Trim());
        }

        private void dgvCursoTema_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarCursoTemaSeleccionado();
        }
    }
}
