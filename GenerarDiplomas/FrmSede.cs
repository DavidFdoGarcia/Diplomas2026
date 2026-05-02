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
    public partial class FrmSede : FrmBase
    {
        private bool esEdicion = false;

        public FrmSede()
        {
            InitializeComponent();
        }

        private void FrmSede_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);



            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);
            EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvSedes);

            txtID.Enabled = false;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            ConfigurarGrid();
            CargarSedes();
            LimpiarCampos();
        }



        private void ConfigurarGrid()
        {
            dgvSedes.ReadOnly = true;
            dgvSedes.AllowUserToAddRows = false;
            dgvSedes.AllowUserToDeleteRows = false;
            dgvSedes.MultiSelect = false;
            dgvSedes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSedes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSedes.RowHeadersVisible = false;
        }

        private void CargarSedes(string filtro = "")
        {
            string query = @"
                SELECT
                    IdSede,
                    NombreSede,
                    Direccion,
                    Ciudad,
                    Estado,
                    Telefono,
                    Referencia,
                    CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estatus,
                    FechaRegistro
                FROM Sede
                WHERE NombreSede LIKE @filtro
                ORDER BY NombreSede";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvSedes.DataSource = dt;

            if (dgvSedes.Columns.Count > 0)
            {
                dgvSedes.Columns["IdSede"].HeaderText = "ID";
                dgvSedes.Columns["NombreSede"].HeaderText = "Nombre";
                dgvSedes.Columns["Direccion"].HeaderText = "Dirección";
                dgvSedes.Columns["Ciudad"].HeaderText = "Ciudad";
                dgvSedes.Columns["Estado"].HeaderText = "Estado";
                dgvSedes.Columns["Telefono"].HeaderText = "Teléfono";
                dgvSedes.Columns["Referencia"].HeaderText = "Referencia";
                dgvSedes.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombreSede.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtEstado.Clear();
            txtTelefono.Clear();
            txtReferencia.Clear();

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            esEdicion = false;
            errorProvider1.Clear();
            txtNombreSede.Focus();
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombreSede.Text))
            {
                errorProvider1.SetError(txtNombreSede, "Ingrese el nombre de la sede.");
                valido = false;
            }
            else if (txtNombreSede.Text.Trim().Length > 150)
            {
                errorProvider1.SetError(txtNombreSede, "El nombre no debe exceder 150 caracteres.");
                valido = false;
            }

            if (txtDireccion.Text.Trim().Length > 250)
            {
                errorProvider1.SetError(txtDireccion, "La dirección no debe exceder 250 caracteres.");
                valido = false;
            }

            if (txtCiudad.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtCiudad, "La ciudad no debe exceder 100 caracteres.");
                valido = false;
            }

            if (txtEstado.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtEstado, "El estado no debe exceder 100 caracteres.");
                valido = false;
            }

            if (txtTelefono.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(txtTelefono, "El teléfono no debe exceder 20 caracteres.");
                valido = false;
            }

            if (txtReferencia.Text.Trim().Length > 250)
            {
                errorProvider1.SetError(txtReferencia, "La referencia no debe exceder 250 caracteres.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteSede(string nombreSede, int idSede = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM Sede
                WHERE NombreSede = @NombreSede
                  AND (@IdSede = 0 OR IdSede <> @IdSede)";

            var parametros = new Dictionary<string, object>
            {
                { "@NombreSede", nombreSede.Trim() },
                { "@IdSede", idSede }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarSede()
        {
            if (!ValidarCampos())
                return;

            string nombreSede = txtNombreSede.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string estado = txtEstado.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string referencia = txtReferencia.Text.Trim();
            bool activo = rbActivo.Checked;

            int idSede = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idSede = Convert.ToInt32(txtID.Text);

            if (ExisteSede(nombreSede, idSede))
            {
                MessageBox.Show("Ya existe una sede con ese nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreSede.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@NombreSede", nombreSede },
                { "@Direccion", string.IsNullOrWhiteSpace(direccion) ? DBNull.Value : direccion },
                { "@Ciudad", string.IsNullOrWhiteSpace(ciudad) ? DBNull.Value : ciudad },
                { "@Estado", string.IsNullOrWhiteSpace(estado) ? DBNull.Value : estado },
                { "@Telefono", string.IsNullOrWhiteSpace(telefono) ? DBNull.Value : telefono },
                { "@Referencia", string.IsNullOrWhiteSpace(referencia) ? DBNull.Value : referencia },
                { "@Activo", activo }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO Sede (NombreSede, Direccion, Ciudad, Estado, Telefono, Referencia, Activo)
                    VALUES (@NombreSede, @Direccion, @Ciudad, @Estado, @Telefono, @Referencia, @Activo)";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Sede guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdSede", idSede);

                string update = @"
                    UPDATE Sede
                    SET NombreSede = @NombreSede,
                        Direccion = @Direccion,
                        Ciudad = @Ciudad,
                        Estado = @Estado,
                        Telefono = @Telefono,
                        Referencia = @Referencia,
                        Activo = @Activo
                    WHERE IdSede = @IdSede";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Sede actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarSedes();
            LimpiarCampos();
        }

        private void CargarSedeSeleccionada()
        {
            if (dgvSedes.CurrentRow == null)
                return;

            int idSede = Convert.ToInt32(dgvSedes.CurrentRow.Cells["IdSede"].Value);

            string query = @"
                SELECT IdSede, NombreSede, Direccion, Ciudad, Estado, Telefono, Referencia, Activo
                FROM Sede
                WHERE IdSede = @IdSede";

            var parametros = new Dictionary<string, object>
            {
                { "@IdSede", idSede }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdSede"].ToString();
            txtNombreSede.Text = row["NombreSede"].ToString();
            txtDireccion.Text = row["Direccion"] == DBNull.Value ? "" : row["Direccion"].ToString();
            txtCiudad.Text = row["Ciudad"] == DBNull.Value ? "" : row["Ciudad"].ToString();
            txtEstado.Text = row["Estado"] == DBNull.Value ? "" : row["Estado"].ToString();
            txtTelefono.Text = row["Telefono"] == DBNull.Value ? "" : row["Telefono"].ToString();
            txtReferencia.Text = row["Referencia"] == DBNull.Value ? "" : row["Referencia"].ToString();

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
            GuardarSede();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GuardarSede();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvSedes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarSedeSeleccionada();
        }
    }
}
