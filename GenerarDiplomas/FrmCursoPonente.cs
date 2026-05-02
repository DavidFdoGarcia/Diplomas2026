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
    public partial class FrmCursoPonente : FrmBase
    {
        private bool esEdicion = false;
        public FrmCursoPonente()
        {
            InitializeComponent();
        }

        private void FrmCursoPonente_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnNuevo);
            EstilosUI.EstiloBoton(btnGuardar);
            EstilosUI.EstiloBoton(btnEditar);
            EstilosUI.EstiloBoton(btnCancelar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            EstilosUI.EstiloGrid(dgvCursoPonente);

            txtID.Enabled = false;

            ConfigurarGrid();
            CargarCursos();
            CargarPonentes();
            CargarCursoPonentes();
            LimpiarCampos();
        }
        private void ConfigurarGrid()
        {
            dgvCursoPonente.ReadOnly = true;
            dgvCursoPonente.AllowUserToAddRows = false;
            dgvCursoPonente.AllowUserToDeleteRows = false;
            dgvCursoPonente.MultiSelect = false;
            dgvCursoPonente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursoPonente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursoPonente.RowHeadersVisible = false;
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

        private void CargarPonentes()
        {
            string query = @"
                SELECT IdPonente, NombreCompleto
                FROM Ponente
                WHERE Activo = 1
                ORDER BY NombreCompleto";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbPonente.DataSource = dt;
            cmbPonente.DisplayMember = "NombreCompleto";
            cmbPonente.ValueMember = "IdPonente";
            cmbPonente.SelectedIndex = -1;
        }

        private void CargarCursoPonentes(string filtro = "")
        {
            string query = @"
                SELECT
                    cp.IdCursoPonente,
                    c.NombreCurso,
                    p.NombreCompleto,
                    cp.RolPonente,
                    cp.OrdenFirma
                FROM CursoPonente cp
                INNER JOIN Curso c ON c.IdCurso = cp.IdCurso
                INNER JOIN Ponente p ON p.IdPonente = cp.IdPonente
                WHERE c.NombreCurso LIKE @filtro
                   OR p.NombreCompleto LIKE @filtro
                   OR ISNULL(cp.RolPonente, '') LIKE @filtro
                ORDER BY c.NombreCurso, cp.OrdenFirma, p.NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@filtro", "%" + filtro + "%" }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvCursoPonente.DataSource = dt;

            if (dgvCursoPonente.Columns.Count > 0)
            {
                dgvCursoPonente.Columns["IdCursoPonente"].HeaderText = "ID";
                dgvCursoPonente.Columns["NombreCurso"].HeaderText = "Curso";
                dgvCursoPonente.Columns["NombreCompleto"].HeaderText = "Ponente";
                dgvCursoPonente.Columns["RolPonente"].HeaderText = "Rol";
                dgvCursoPonente.Columns["OrdenFirma"].HeaderText = "Orden Firma";
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtRolPonente.Clear();
            txtOrdenFirma.Clear();
            txtBuscar.Clear();

            cmbCurso.SelectedIndex = -1;
            cmbPonente.SelectedIndex = -1;

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

            if (cmbPonente.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbPonente, "Seleccione un ponente.");
                valido = false;
            }

            if (txtRolPonente.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtRolPonente, "El rol no debe exceder 100 caracteres.");
                valido = false;
            }

            if (!string.IsNullOrWhiteSpace(txtOrdenFirma.Text) &&
                !int.TryParse(txtOrdenFirma.Text.Trim(), out _))
            {
                errorProvider1.SetError(txtOrdenFirma, "Ingrese un número entero válido.");
                valido = false;
            }

            return valido;
        }

        private bool ExisteCursoPonente(int idCurso, int idPonente, int idCursoPonente = 0)
        {
            string query = @"
                SELECT COUNT(*)
                FROM CursoPonente
                WHERE IdCurso = @IdCurso
                  AND IdPonente = @IdPonente
                  AND (@IdCursoPonente = 0 OR IdCursoPonente <> @IdCursoPonente)";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdPonente", idPonente },
                { "@IdCursoPonente", idCursoPonente }
            };

            object resultado = consultas.EjecutarEscalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        private void GuardarCursoPonente()
        {
            if (!ValidarCampos())
                return;

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int idPonente = Convert.ToInt32(cmbPonente.SelectedValue);
            string rolPonente = txtRolPonente.Text.Trim();
            int? ordenFirma = string.IsNullOrWhiteSpace(txtOrdenFirma.Text) ? null : Convert.ToInt32(txtOrdenFirma.Text.Trim());

            int idCursoPonente = 0;
            if (!string.IsNullOrWhiteSpace(txtID.Text))
                idCursoPonente = Convert.ToInt32(txtID.Text);

            if (ExisteCursoPonente(idCurso, idPonente, idCursoPonente))
            {
                MessageBox.Show("Ese ponente ya está asignado a ese curso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPonente.Focus();
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso },
                { "@IdPonente", idPonente },
                { "@RolPonente", string.IsNullOrWhiteSpace(rolPonente) ? DBNull.Value : rolPonente },
                { "@OrdenFirma", ordenFirma.HasValue ? ordenFirma.Value : DBNull.Value }
            };

            if (!esEdicion)
            {
                string insert = @"
                    INSERT INTO CursoPonente (IdCurso, IdPonente, RolPonente, OrdenFirma)
                    VALUES (@IdCurso, @IdPonente, @RolPonente, @OrdenFirma)";

                consultas.Ejecutar(insert, parametros);
                MessageBox.Show("Ponente asignado al curso correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                parametros.Add("@IdCursoPonente", idCursoPonente);

                string update = @"
                    UPDATE CursoPonente
                    SET IdCurso = @IdCurso,
                        IdPonente = @IdPonente,
                        RolPonente = @RolPonente,
                        OrdenFirma = @OrdenFirma
                    WHERE IdCursoPonente = @IdCursoPonente";

                consultas.Ejecutar(update, parametros);
                MessageBox.Show("Asignación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarCursoPonentes();
            LimpiarCampos();
        }

        private void CargarCursoPonenteSeleccionado()
        {
            if (dgvCursoPonente.CurrentRow == null)
                return;

            int idCursoPonente = Convert.ToInt32(dgvCursoPonente.CurrentRow.Cells["IdCursoPonente"].Value);

            string query = @"
                SELECT IdCursoPonente, IdCurso, IdPonente, RolPonente, OrdenFirma
                FROM CursoPonente
                WHERE IdCursoPonente = @IdCursoPonente";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCursoPonente", idCursoPonente }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtID.Text = row["IdCursoPonente"].ToString();
            cmbCurso.SelectedValue = Convert.ToInt32(row["IdCurso"]);
            cmbPonente.SelectedValue = Convert.ToInt32(row["IdPonente"]);
            txtRolPonente.Text = row["RolPonente"] == DBNull.Value ? "" : row["RolPonente"].ToString();
            txtOrdenFirma.Text = row["OrdenFirma"] == DBNull.Value ? "" : row["OrdenFirma"].ToString();

            esEdicion = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GuardarCursoPonente();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarCursoPonenteSeleccionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCursoPonentes(txtBuscar.Text.Trim());

        }

        private void dgvCursoPonente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CargarCursoPonenteSeleccionado();
        }
    }
}
