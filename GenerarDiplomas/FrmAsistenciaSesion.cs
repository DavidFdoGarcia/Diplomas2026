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
    public partial class FrmAsistenciaSesion : FrmBase
    {
        public FrmAsistenciaSesion()
        {
            InitializeComponent();
        }

        private void FrmAsistenciaSesion_Load(object sender, EventArgs e)
        {
            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnCargarAlumnos);
            EstilosUI.EstiloBoton(btnGuardar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            ConfigurarGrid();
            CargarSesiones();
        }
        private void ConfigurarGrid()
        {
            dgvAsistencia.Columns.Clear();
            dgvAsistencia.AutoGenerateColumns = false;
            dgvAsistencia.AllowUserToAddRows = false;
            dgvAsistencia.AllowUserToDeleteRows = false;
            dgvAsistencia.MultiSelect = false;
            dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencia.RowHeadersVisible = false;
            dgvAsistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn colIdInscripcion = new DataGridViewTextBoxColumn();
            colIdInscripcion.Name = "IdInscripcion";
            colIdInscripcion.HeaderText = "IdInscripcion";
            colIdInscripcion.DataPropertyName = "IdInscripcion";
            colIdInscripcion.Visible = false;

            DataGridViewTextBoxColumn colAlumno = new DataGridViewTextBoxColumn();
            colAlumno.Name = "Alumno";
            colAlumno.HeaderText = "Alumno";
            colAlumno.DataPropertyName = "Alumno";
            colAlumno.ReadOnly = true;

            DataGridViewCheckBoxColumn colAsistio = new DataGridViewCheckBoxColumn();
            colAsistio.Name = "Asistio";
            colAsistio.HeaderText = "Asistió";
            colAsistio.DataPropertyName = "Asistio";

            DataGridViewTextBoxColumn colHoraEntrada = new DataGridViewTextBoxColumn();
            colHoraEntrada.Name = "HoraEntrada";
            colHoraEntrada.HeaderText = "Hora Entrada";
            colHoraEntrada.DataPropertyName = "HoraEntrada";

            DataGridViewTextBoxColumn colHoraSalida = new DataGridViewTextBoxColumn();
            colHoraSalida.Name = "HoraSalida";
            colHoraSalida.HeaderText = "Hora Salida";
            colHoraSalida.DataPropertyName = "HoraSalida";

            DataGridViewTextBoxColumn colObservaciones = new DataGridViewTextBoxColumn();
            colObservaciones.Name = "Observaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.DataPropertyName = "Observaciones";

            dgvAsistencia.Columns.Add(colIdInscripcion);
            dgvAsistencia.Columns.Add(colAlumno);
            dgvAsistencia.Columns.Add(colAsistio);
            dgvAsistencia.Columns.Add(colHoraEntrada);
            dgvAsistencia.Columns.Add(colHoraSalida);
            dgvAsistencia.Columns.Add(colObservaciones);
        }

        private void CargarSesiones()
        {
            string query = @"
                SELECT 
                    s.IdSesion,
                    c.NombreCurso + ' - Sesión ' + CAST(s.NumeroSesion AS VARCHAR(10)) +
                    ' - ' + CONVERT(VARCHAR(10), s.FechaSesion, 103) AS Texto
                FROM SesionCurso s
                INNER JOIN Curso c ON c.IdCurso = s.IdCurso
                ORDER BY c.NombreCurso, s.NumeroSesion";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbSesion.DataSource = dt;
            cmbSesion.DisplayMember = "Texto";
            cmbSesion.ValueMember = "IdSesion";
            cmbSesion.SelectedIndex = -1;
        }

        private void CargarAlumnosSesion()
        {
            if (cmbSesion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una sesión.");
                return;
            }

            int idSesion = Convert.ToInt32(cmbSesion.SelectedValue);

            string query = @"
                SELECT
                    i.IdInscripcion,
                    a.NombreCompleto AS Alumno,
                    CAST(0 AS BIT) AS Asistio,
                    '' AS HoraEntrada,
                    '' AS HoraSalida,
                    '' AS Observaciones
                FROM SesionCurso s
                INNER JOIN InscripcionCurso i ON i.IdCurso = s.IdCurso
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                WHERE s.IdSesion = @IdSesion
                ORDER BY a.NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@IdSesion", idSesion }
            };

            DataTable dt = consultas.Consultar(query, parametros);

            string queryExistentes = @"
                SELECT
                    IdInscripcion,
                    Asistio,
                    CONVERT(VARCHAR(5), HoraEntrada, 108) AS HoraEntrada,
                    CONVERT(VARCHAR(5), HoraSalida, 108) AS HoraSalida,
                    Observaciones
                FROM AsistenciaSesion
                WHERE IdSesion = @IdSesion";

            DataTable dtExistentes = consultas.Consultar(queryExistentes, parametros);

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataRow existente in dtExistentes.Rows)
                {
                    if (Convert.ToInt32(row["IdInscripcion"]) == Convert.ToInt32(existente["IdInscripcion"]))
                    {
                        row["Asistio"] = Convert.ToBoolean(existente["Asistio"]);
                        row["HoraEntrada"] = existente["HoraEntrada"] == DBNull.Value ? "" : existente["HoraEntrada"].ToString();
                        row["HoraSalida"] = existente["HoraSalida"] == DBNull.Value ? "" : existente["HoraSalida"].ToString();
                        row["Observaciones"] = existente["Observaciones"] == DBNull.Value ? "" : existente["Observaciones"].ToString();
                        break;
                    }
                }
            }

            dgvAsistencia.DataSource = dt;
        }

        private bool ValidarGrid()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cmbSesion.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbSesion, "Seleccione una sesión.");
                valido = false;
            }

            if (dgvAsistencia.Rows.Count == 0)
            {
                MessageBox.Show("No hay alumnos cargados.");
                valido = false;
            }

            return valido;
        }

        private void GuardarAsistencia()
        {
            if (!ValidarGrid())
                return;

            int idSesion = Convert.ToInt32(cmbSesion.SelectedValue);

            foreach (DataGridViewRow row in dgvAsistencia.Rows)
            {
                int idInscripcion = Convert.ToInt32(row.Cells["IdInscripcion"].Value);
                bool asistio = row.Cells["Asistio"].Value != DBNull.Value &&
                               row.Cells["Asistio"].Value != null &&
                               Convert.ToBoolean(row.Cells["Asistio"].Value);

                string horaEntradaTexto = row.Cells["HoraEntrada"].Value == null ? "" : row.Cells["HoraEntrada"].Value.ToString().Trim();
                string horaSalidaTexto = row.Cells["HoraSalida"].Value == null ? "" : row.Cells["HoraSalida"].Value.ToString().Trim();
                string observaciones = row.Cells["Observaciones"].Value == null ? "" : row.Cells["Observaciones"].Value.ToString().Trim();

                object horaEntrada = DBNull.Value;
                object horaSalida = DBNull.Value;

                if (!string.IsNullOrWhiteSpace(horaEntradaTexto))
                    horaEntrada = TimeSpan.Parse(horaEntradaTexto);

                if (!string.IsNullOrWhiteSpace(horaSalidaTexto))
                    horaSalida = TimeSpan.Parse(horaSalidaTexto);

                string queryExiste = @"
                    SELECT COUNT(*)
                    FROM AsistenciaSesion
                    WHERE IdSesion = @IdSesion
                      AND IdInscripcion = @IdInscripcion";

                var parametrosExiste = new Dictionary<string, object>
                {
                    { "@IdSesion", idSesion },
                    { "@IdInscripcion", idInscripcion }
                };

                int existe = Convert.ToInt32(consultas.EjecutarEscalar(queryExiste, parametrosExiste));

                if (existe == 0)
                {
                    string insert = @"
                        INSERT INTO AsistenciaSesion
                        (
                            IdSesion,
                            IdInscripcion,
                            Asistio,
                            HoraEntrada,
                            HoraSalida,
                            Observaciones
                        )
                        VALUES
                        (
                            @IdSesion,
                            @IdInscripcion,
                            @Asistio,
                            @HoraEntrada,
                            @HoraSalida,
                            @Observaciones
                        )";

                    var parametrosInsert = new Dictionary<string, object>
                    {
                        { "@IdSesion", idSesion },
                        { "@IdInscripcion", idInscripcion },
                        { "@Asistio", asistio },
                        { "@HoraEntrada", horaEntrada },
                        { "@HoraSalida", horaSalida },
                        { "@Observaciones", string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : observaciones }
                    };

                    consultas.Ejecutar(insert, parametrosInsert);
                }
                else
                {
                    string update = @"
                        UPDATE AsistenciaSesion
                        SET Asistio = @Asistio,
                            HoraEntrada = @HoraEntrada,
                            HoraSalida = @HoraSalida,
                            Observaciones = @Observaciones
                        WHERE IdSesion = @IdSesion
                          AND IdInscripcion = @IdInscripcion";

                    var parametrosUpdate = new Dictionary<string, object>
                    {
                        { "@IdSesion", idSesion },
                        { "@IdInscripcion", idInscripcion },
                        { "@Asistio", asistio },
                        { "@HoraEntrada", horaEntrada },
                        { "@HoraSalida", horaSalida },
                        { "@Observaciones", string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : observaciones }
                    };

                    consultas.Ejecutar(update, parametrosUpdate);
                }
            }

            MessageBox.Show("Asistencia guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarAlumnosSesion();
        }

        private void btnCargarAlumnos_Click(object sender, EventArgs e)
        {
            CargarAlumnosSesion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarAsistencia();
        }
    }
}
