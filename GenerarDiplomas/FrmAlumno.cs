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
    public partial class FrmAlumno : FrmBase
    {
        private bool esEdicion = false;
        public FrmAlumno()
        {
            InitializeComponent();
        }

        private void FrmAlumno_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvAlumnos);

            txtID.Enabled = false;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            ConfigurarGrid();
            CargarAlumnos();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvAlumnos.ReadOnly = true;
            dgvAlumnos.AllowUserToAddRows = false;
            dgvAlumnos.AllowUserToDeleteRows = false;
            dgvAlumnos.MultiSelect = false;
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlumnos.RowHeadersVisible = false;
        }

        private void CargarAlumnos(string filtro = "")
        {
            string query = @"
                SELECT
                    IdAlumno,
                    Nombre,
                    ApellidoPaterno,
                    ApellidoMaterno,
                    NombreCompleto,
                    Telefono,
                    Correo,
                    Empresa,
                    Puesto,
                    CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estatus,
                    FechaRegistro
                FROM Alumno
                WHERE NombreCompleto LIKE @filtro
                   OR Nombre LIKE @filtro
                   OR ApellidoPaterno LIKE @filtro
                   OR ApellidoMaterno LIKE @filtro
                   OR Empresa LIKE @filtro
                ORDER BY NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvAlumnos.DataSource = dt;

            if (dgvAlumnos.Columns.Count > 0)
            {
                dgvAlumnos.Columns["IdAlumno"].HeaderText = "ID";
                dgvAlumnos.Columns["ApellidoPaterno"].HeaderText = "Apellido Paterno";
                dgvAlumnos.Columns["ApellidoMaterno"].HeaderText = "Apellido Materno";
                dgvAlumnos.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                dgvAlumnos.Columns["Telefono"].HeaderText = "Teléfono";
                dgvAlumnos.Columns["Correo"].HeaderText = "Correo";
                dgvAlumnos.Columns["Empresa"].HeaderText = "Empresa";
                dgvAlumnos.Columns["Puesto"].HeaderText = "Puesto";
                dgvAlumnos.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEmpresa.Clear();
            txtPuesto.Clear();
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
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del alumno.");
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

            if (txtEmpresa.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtEmpresa, "La empresa no debe exceder 150 caracteres.");
                valido = false;
            }

            if (txtPuesto.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtPuesto, "El puesto no debe exceder 150 caracteres.");
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

        private bool ExisteAlumno(string nombre, string apellidoPaterno, string apellidoMaterno, int idAlumno = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Alumno
                WHERE Nombre = @Nombre
                  AND ISNULL(ApellidoPaterno, '') = ISNULL(@ApellidoPaterno, '')
                  AND ISNULL(ApellidoMaterno, '') = ISNULL(@ApellidoMaterno, '')
                  AND (@IdAlumno = 0 OR IdAlumno <> @IdAlumno)";

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre.Trim() },
                { "@ApellidoPaterno", string.IsNullOrWhiteSpace(apellidoPaterno) ? DBNull.Value : apellidoPaterno.Trim() },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno.Trim() },
                { "@IdAlumno", idAlumno }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarAlumno()
        {
            if (!ValidarCampos())
                return;

            string nombre = txtNombre.Text.Trim();
            string apellidoPaterno = txtApellidoPaterno.Text.Trim();
            string apellidoMaterno = txtApellidoMaterno.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string empresa = txtEmpresa.Text.Trim();
            string puesto = txtPuesto.Text.Trim();
            bool activo = rbActivo.Checked;

            int idAlumno = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idAlumno = Convert.ToInt32(txtID.Text);

            if (ExisteAlumno(nombre, apellidoPaterno, apellidoMaterno, idAlumno))
            {
                MessageBox.Show("Ya existe un alumno con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", nombre },
                { "@ApellidoPaterno", string.IsNullOrWhiteSpace(apellidoPaterno) ? DBNull.Value : apellidoPaterno },
                { "@ApellidoMaterno", string.IsNullOrWhiteSpace(apellidoMaterno) ? DBNull.Value : apellidoMaterno },
                { "@Telefono", string.IsNullOrWhiteSpace(telefono) ? DBNull.Value : telefono },
                { "@Correo", string.IsNullOrWhiteSpace(correo) ? DBNull.Value : correo },
                { "@Empresa", string.IsNullOrWhiteSpace(empresa) ? DBNull.Value : empresa },
                { "@Puesto", string.IsNullOrWhiteSpace(puesto) ? DBNull.Value : puesto },
                { "@Activo", activo }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO Alumno
                    (
                        Nombre,
                        ApellidoPaterno,
                        ApellidoMaterno,
                        Telefono,
                        Correo,
                        Empresa,
                        Puesto,
                        Activo
                    )
                    VALUES
                    (
                        @Nombre,
                        @ApellidoPaterno,
                        @ApellidoMaterno,
                        @Telefono,
                        @Correo,
                        @Empresa,
                        @Puesto,
                        @Activo
                    )";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Alumno guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdAlumno", idAlumno);

                string update = @"
                    UPDATE Alumno
                    SET Nombre = @Nombre,
                        ApellidoPaterno = @ApellidoPaterno,
                        ApellidoMaterno = @ApellidoMaterno,
                        Telefono = @Telefono,
                        Correo = @Correo,
                        Empresa = @Empresa,
                        Puesto = @Puesto,
                        Activo = @Activo
                    WHERE IdAlumno = @IdAlumno";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Alumno actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarAlumnos();
            LimpiarCampos();
        }

        private void CargarAlumnoSeleccionado()
        {
            if (dgvAlumnos.CurrentRow == null)
                return;

            int idAlumno = Convert.ToInt32(dgvAlumnos.CurrentRow.Cells["IdAlumno"].Value);

            string query = @"
                SELECT
                    IdAlumno,
                    Nombre,
                    ApellidoPaterno,
                    ApellidoMaterno,
                    Telefono,
                    Correo,
                    Empresa,
                    Puesto,
                    Activo
                FROM Alumno
                WHERE IdAlumno = @IdAlumno";

            var parametros = new Dictionary<string, object>
            {
                { "@IdAlumno", idAlumno }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdAlumno"].ToString();
            txtNombre.Text = row["Nombre"] == DBNull.Value ? "" : row["Nombre"].ToString();
            txtApellidoPaterno.Text = row["ApellidoPaterno"] == DBNull.Value ? "" : row["ApellidoPaterno"].ToString();
            txtApellidoMaterno.Text = row["ApellidoMaterno"] == DBNull.Value ? "" : row["ApellidoMaterno"].ToString();
            txtTelefono.Text = row["Telefono"] == DBNull.Value ? "" : row["Telefono"].ToString();
            txtCorreo.Text = row["Correo"] == DBNull.Value ? "" : row["Correo"].ToString();
            txtEmpresa.Text = row["Empresa"] == DBNull.Value ? "" : row["Empresa"].ToString();
            txtPuesto.Text = row["Puesto"] == DBNull.Value ? "" : row["Puesto"].ToString();

            bool activo = Convert.ToBoolean(row["Activo"]);
            rbActivo.Checked = activo;
            rbInactivo.Checked = !activo;

            esEdicion = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarAlumno();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarAlumnoSeleccionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarAlumnos(txtBuscar.Text.Trim());
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarAlumnoSeleccionado();
        }
    }
}
