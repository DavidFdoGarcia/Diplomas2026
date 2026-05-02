using GenerarDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
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
            EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvPonente);
            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvPonente);

            txtID.Enabled = false;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            ConfigurarGrid();
            CargarPonentes();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvPonente.ReadOnly = true;
            dgvPonente.AllowUserToAddRows = false;
            dgvPonente.AllowUserToDeleteRows = false;
            dgvPonente.MultiSelect = false;
            dgvPonente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPonente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPonente.RowHeadersVisible = false;
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
                    Profesion,
                    Especialidad,
                    Telefono,
                    Correo,
                    Institucion,
                    FirmaRuta,
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
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvPonente.DataSource = dt;

            if (dgvPonente.Columns.Count > 0)
            {
                dgvPonente.Columns["IdPonente"].HeaderText = "ID";
                dgvPonente.Columns["ApellidoPaterno"].HeaderText = "Apellido Paterno";
                dgvPonente.Columns["ApellidoMaterno"].HeaderText = "Apellido Materno";
                dgvPonente.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                dgvPonente.Columns["Profesion"].HeaderText = "Profesión";
                dgvPonente.Columns["Especialidad"].HeaderText = "Especialidad";
                dgvPonente.Columns["Telefono"].HeaderText = "Teléfono";
                dgvPonente.Columns["Correo"].HeaderText = "Correo";
                dgvPonente.Columns["Institucion"].HeaderText = "Institución";
                dgvPonente.Columns["FirmaRuta"].HeaderText = "Ruta Firma";
                dgvPonente.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtProfesion.Clear();
            txtEspecialidades.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtInstitucion.Clear();
            txtFirma.Clear();
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
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del ponente.");
                valido = false;
            }
            else if (txtNombre.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtNombre, "El nombre no debe exceder 100 caracteres.");
                valido = false;
            }

            if (txtApellidoPaterno.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtApellidoPaterno, "El apellido paterno no debe exceder 100 caracteres.");
                valido = false;
            }

            if (txtApellidoMaterno.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtApellidoMaterno, "El apellido materno no debe exceder 100 caracteres.");
                valido = false;
            }

            if (txtProfesion.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtProfesion, "La profesión no debe exceder 150 caracteres.");
                valido = false;
            }

            if (txtEspecialidades.Text.Trim().Length > 200)
            {
                errorProvider1.SetError(txtEspecialidades, "La especialidad no debe exceder 200 caracteres.");
                valido = false;
            }

            if (txtTelefono.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(txtTelefono, "El teléfono no debe exceder 20 caracteres.");
                valido = false;
            }

            if (txtCorreo.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtCorreo, "El correo no debe exceder 150 caracteres.");
                valido = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !EsCorreoValido(txtCorreo.Text.Trim()))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido.");
                valido = false;
            }

            if (txtInstitucion.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtInstitucion, "La institución no debe exceder 150 caracteres.");
                valido = false;
            }

            if (txtFirma.Text.Trim().Length > 300)
            {
                errorProvider1.SetError(txtFirma, "La ruta de firma no debe exceder 300 caracteres.");
                valido = false;
            }

            return valido;
        }

        private bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        private bool ExistePonente(string nombre, string apellidoPaterno, string apellidoMaterno, int idPonente = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Ponente
                WHERE Nombre = @Nombre
                  AND ISNULL(ApellidoPaterno, '') = ISNULL(@ApellidoPaterno, '')
                  AND ISNULL(ApellidoMaterno, '') = ISNULL(@ApellidoMaterno, '')
                  AND (@IdPonente = 0 OR IdPonente <> @IdPonente)";

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre.Trim() },
                { "@ApellidoPaterno", string.IsNullOrWhiteSpace(apellidoPaterno) ? DBNull.Value : apellidoPaterno.Trim() },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno.Trim() },
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
            string profesion = txtProfesion.Text.Trim();
            string especialidad = txtEspecialidades.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string institucion = txtInstitucion.Text.Trim();
            string firmaRuta = txtFirma.Text.Trim();
            bool activo = rbActivo.Checked;

            int idPonente = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idPonente = Convert.ToInt32(txtID.Text);

            if (ExistePonente(nombre, apellidoPaterno, apellidoMaterno, idPonente))
            {
                MessageBox.Show("Ya existe un ponente con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre },
                { "@ApellidoPaterno", string.IsNullOrWhiteSpace(apellidoPaterno) ? DBNull.Value : apellidoPaterno },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno },
                { "@Profesion", string.IsNullOrWhiteSpace(profesion) ? DBNull.Value : profesion },
                { "@Especialidad", string.IsNullOrWhiteSpace(especialidad) ? DBNull.Value : especialidad },
                { "@Telefono", string.IsNullOrWhiteSpace(telefono) ? DBNull.Value : telefono },
                { "@Correo", string.IsNullOrWhiteSpace(correo) ? DBNull.Value : correo },
                { "@Institucion", string.IsNullOrWhiteSpace(institucion) ? DBNull.Value : institucion },
                { "@FirmaRuta", string.IsNullOrWhiteSpace(firmaRuta) ? DBNull.Value : firmaRuta },
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
                        Profesion,
                        Especialidad,
                        Telefono,
                        Correo,
                        Institucion,
                        FirmaRuta,
                        Activo
                    )
                    VALUES
                    (
                        @Nombre,
                        @ApellidoPaterno,
                        @ApellidoMaterno,
                        @Profesion,
                        @Especialidad,
                        @Telefono,
                        @Correo,
                        @Institucion,
                        @FirmaRuta,
                        @Activo
                    )";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Ponente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdPonente", idPonente);

                string update = @"
                    UPDATE Ponente
                    SET Nombre = @Nombre,
                        ApellidoPaterno = @ApellidoPaterno,
                        ApellidoMaterno = @ApellidoMaterno,
                        Profesion = @Profesion,
                        Especialidad = @Especialidad,
                        Telefono = @Telefono,
                        Correo = @Correo,
                        Institucion = @Institucion,
                        FirmaRuta = @FirmaRuta,
                        Activo = @Activo
                    WHERE IdPonente = @IdPonente";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Ponente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarPonentes();
            LimpiarCampos();
        }

        private void CargarPonenteSeleccionado()
        {
            if (dgvPonente.CurrentRow == null)
                return;

            int idPonente = Convert.ToInt32(dgvPonente.CurrentRow.Cells["IdPonente"].Value);

            string query = @"
                SELECT
                    IdPonente,
                    Nombre,
                    ApellidoPaterno,
                    ApellidoMaterno,
                    Profesion,
                    Especialidad,
                    Telefono,
                    Correo,
                    Institucion,
                    FirmaRuta,
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
            txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
            txtApellidoPaterno.Text = row["ApellidoPaterno"] == DBNull.Value ? "" : row["ApellidoPaterno"].ToString();
            txtApellidoMaterno.Text = row["ApellidoMaterno"] == DBNull.Value ? "" : row["ApellidoMaterno"].ToString();
            txtProfesion.Text = row["Profesion"] == DBNull.Value ? "" : row["Profesion"].ToString();
            txtEspecialidades.Text = row["Especialidad"] == DBNull.Value ? "" : row["Especialidad"].ToString();
            txtTelefono.Text = row["Telefono"] == DBNull.Value ? "" : row["Telefono"].ToString();
            txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
            txtInstitucion.Text = row["Institucion"] == DBNull.Value ? "" : row["Institucion"].ToString();
            txtFirma.Text = row["FirmaRuta"] == DBNull.Value ? "" : row["FirmaRuta"].ToString();

            bool activo = Convert.ToBoolean(row["Activo"]);
            rbActivo.Checked = activo;
            rbInactivo.Checked = !activo;

            esEdicion = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {

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

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            CargarPonentes(txtBuscar.Text.Trim());
        }

        private void dgvPonente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarPonenteSeleccionado();
        }
    }
}
