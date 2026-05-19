using GenerarDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GenerarDiplomas
{
    public partial class FrmPonente : FrmBase
    {
        private bool esEdicion = false;

        public FrmPonente()
        {
            InitializeComponent();
        }

        private void FrmPonente_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvPonentes);

            txtID.Enabled = false;
            rbActivo.Checked = true;

            ConfigurarGrid();
            CargarPonentes();
            LimpiarCampos();
        }

        private void ConfigurarGrid()
        {
            dgvPonentes.ReadOnly = true;
            dgvPonentes.AllowUserToAddRows = false;
            dgvPonentes.AllowUserToDeleteRows = false;
            dgvPonentes.MultiSelect = false;
            dgvPonentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPonentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPonentes.RowHeadersVisible = false;
        }

        private void CargarPonentes(string filtro = "")
        {
            string query = @"
                SELECT
                    IdPonente,
                    Nombre,
                    ApellidoPaterno,
                    ApellidoMaterno,
                    NombreCompleto,
                    CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estatus,
                    FechaRegistro
                FROM Ponente
                WHERE NombreCompleto LIKE @filtro
                   OR Nombre LIKE @filtro
                   OR ApellidoPaterno LIKE @filtro
                   OR ApellidoMaterno LIKE @filtro
                ORDER BY NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + txtBuscar.Text.Trim() + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvPonentes.DataSource = dt;

            if (dgvPonentes.Columns.Count > 0)
            {
                dgvPonentes.Columns["IdPonente"].HeaderText = "ID";
                dgvPonentes.Columns["ApellidoPaterno"].HeaderText = "Apellido Paterno";
                dgvPonentes.Columns["ApellidoMaterno"].HeaderText = "Apellido Materno";
                dgvPonentes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                dgvPonentes.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtBuscar.Clear();

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            esEdicion = false;
            errorProvider1.Clear();
            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoPaterno.Text))
            {
                errorProvider1.SetError(txtApellidoPaterno, "Ingrese el apellido paterno.");
                valido = false;
            }

            return valido;
        }

        private bool ExistePonente(string nombre, string apellidoPaterno, string apellidoMaterno, int idPonente = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Ponente
                WHERE Nombre = @Nombre
                  AND ApellidoPaterno = @ApellidoPaterno
                  AND ISNULL(ApellidoMaterno, '') = ISNULL(@ApellidoMaterno, '')
                  AND (@IdPonente = 0 OR IdPonente <> @IdPonente)";

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre },
                { "@ApellidoPaterno", apellidoPaterno },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno },
                { "@IdPonente", idPonente }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarPonente()
        {
            if (!ValidarCampos())
                return;

            string nombre = txtNombre.Text.Trim();
            string apellidoPaterno = txtApellidoPaterno.Text.Trim();
            string apellidoMaterno = txtApellidoMaterno.Text.Trim();
            bool activo = rbActivo.Checked;

            int idPonente = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idPonente = Convert.ToInt32(txtID.Text);

            if (ExistePonente(nombre, apellidoPaterno, apellidoMaterno, idPonente))
            {
                MessageBox.Show("Ya existe un ponente con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre },
                { "@ApellidoPaterno", apellidoPaterno },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno },
                { "@Activo", activo }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO Ponente
                    (
                        Nombre,
                        ApellidoPaterno,
                        ApellidoMaterno,
                        Activo
                    )
                    VALUES
                    (
                        @Nombre,
                        @ApellidoPaterno,
                        @ApellidoMaterno,
                        @Activo
                    )";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Ponente guardado correctamente.");
            }
            else
            {
                parametros.Add("@IdPonente", idPonente);

                string update = @"
                    UPDATE Ponente
                    SET Nombre = @Nombre,
                        ApellidoPaterno = @ApellidoPaterno,
                        ApellidoMaterno = @ApellidoMaterno,
                        Activo = @Activo
                    WHERE IdPonente = @IdPonente";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Ponente actualizado correctamente.");
            }

            CargarPonentes();
            LimpiarCampos();
        }

        private void CargarPonenteSeleccionado()
        {
            if (dgvPonentes.CurrentRow == null)
                return;

            int idPonente = Convert.ToInt32(dgvPonentes.CurrentRow.Cells["IdPonente"].Value);

            string query = @"
                SELECT
                    IdPonente,
                    Nombre,
                    ApellidoPaterno,
                    ApellidoMaterno,
                    Activo
                FROM Ponente
                WHERE IdPonente = @IdPonente";

            var parametros = new Dictionary<string, object>
            {
                { "@IdPonente", idPonente }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdPonente"].ToString();
            txtNombre.Text = row["Nombre"].ToString();
            txtApellidoPaterno.Text = row["ApellidoPaterno"].ToString();
            txtApellidoMaterno.Text = row["ApellidoMaterno"] == DBNull.Value ? "" : row["ApellidoMaterno"].ToString();

            bool activo = Convert.ToBoolean(row["Activo"]);
            rbActivo.Checked = activo;
            rbInactivo.Checked = !activo;

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPonente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarPonenteSeleccionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPonentes(txtBuscar.Text.Trim());
        }

        private void dgvPonentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarPonenteSeleccionado();
        }
    }
}