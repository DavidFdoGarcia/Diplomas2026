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
    public partial class FrmTema : FrmBase
    {
        private bool esEdicion = false;
        public FrmTema()
        {
            InitializeComponent();
        }

        private void FrmTema_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);



            EstilosUI.EstiloTextBox(txtNombreTema);
            EstilosUI.EstiloTextBox(txtDescripcion);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            EstilosUI.EstiloGrid(dgvTemas);

            txtIdtema.Enabled = false;
            txtDescripcion.Multiline = true;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            ConfigurarGrid();
            CargarTemas();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvTemas.ReadOnly = true;
            dgvTemas.AllowUserToAddRows = false;
            dgvTemas.AllowUserToDeleteRows = false;
            dgvTemas.MultiSelect = false;
            dgvTemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTemas.RowHeadersVisible = false;
        }
        private void CargarTemas(string filtro = "")
        {
            string query = @"
                SELECT
                    IdTema,
                    NombreTema,
                    Descripcion,
                    CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estatus,
                    FechaRegistro
                FROM Tema
                WHERE NombreTema LIKE @filtro
                ORDER BY NombreTema";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvTemas.DataSource = dt;

            if (dgvTemas.Columns.Count > 0)
            {
                dgvTemas.Columns["IdTema"].HeaderText = "ID";
                dgvTemas.Columns["NombreTema"].HeaderText = "Tema";
                dgvTemas.Columns["Descripcion"].HeaderText = "Descripción";
                dgvTemas.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            }
        }
        private void LimpiarCampos()
        {
            txtIdtema.Clear();
            txtNombreTema.Clear();
            txtDescripcion.Clear();

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            esEdicion = false;
            errorProvider1.Clear();
            txtNombreTema.Focus();
        }
        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombreTema.Text))
            {
                errorProvider1.SetError(txtNombreTema, "Ingrese el tema.");
                valido = false;
            }
            else if (txtNombreTema.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtNombreTema, "El tema no debe exceder 150 caracteres.");
                valido = false;
            }

            if (txtDescripcion.Text.Trim().Length > 500)
            {
                errorProvider1.SetError(txtDescripcion, "La descripción no debe exceder 500 caracteres.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteTema(string nombreTema, int idTema = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Tema
                WHERE NombreTema = @NombreTema
                  AND (@IdTema = 0 OR IdTema <> @IdTema)";

            var parametros = new Dictionary<string, object>
            {
                { "@NombreTema", nombreTema.Trim() },
                { "@IdTema", idTema }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarTema()
        {
            if (!ValidarCampos())
                return;

            string nombreTema = txtNombreTema.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            bool activo = rbActivo.Checked;

            int idTema = 0;
            if (!string.IsNullOrWhiteSpace(txtIdtema.Text))
                idTema = Convert.ToInt32(txtIdtema.Text);

            if (ExisteTema(nombreTema, idTema))
            {
                MessageBox.Show("Ya existe un tema con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreTema.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@NombreTema", nombreTema },
                { "@Descripcion", string.IsNullOrWhiteSpace(descripcion) ? DBNull.Value : descripcion },
                { "@Activo", activo }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO Tema (NombreTema, Descripcion, Activo)
                    VALUES (@NombreTema, @Descripcion, @Activo)";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Tema guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdTema", idTema);

                string update = @"
                    UPDATE Tema
                    SET NombreTema = @NombreTema,
                        Descripcion = @Descripcion,
                        Activo = @Activo
                    WHERE IdTema = @IdTema";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Tema actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarTemas();
            LimpiarCampos();
        }

        private void CargarTemaSeleccionado()
        {
            if (dgvTemas.CurrentRow == null)
                return;

            int idTema = Convert.ToInt32(dgvTemas.CurrentRow.Cells["IdTema"].Value);

            string query = @"
                SELECT IdTema, NombreTema, Descripcion, Activo
                FROM Tema
                WHERE IdTema = @IdTema";

            var parametros = new Dictionary<string, object>
            {
                { "@IdTema", idTema }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtIdtema.Text = row["IdTema"].ToString();
            txtNombreTema.Text = row["NombreTema"].ToString();
            txtDescripcion.Text = row["Descripcion"] == DBNull.Value ? "" : row["Descripcion"].ToString();

            bool activo = Convert.ToBoolean(row["Activo"]);
            rbActivo.Checked = activo;
            rbInactivo.Checked = !activo;

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbInactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarTema();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarTemaSeleccionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTemas(txtBuscar.Text.Trim());
        }

        private void dgvTemas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarTemaSeleccionado();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }
    }
}
