using GenerarDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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
            CargarCursos();
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

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdInscripcion",
                HeaderText = "IdInscripcion",
                DataPropertyName = "IdInscripcion",
                Visible = false
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Alumno",
                HeaderText = "Alumno",
                DataPropertyName = "Alumno",
                ReadOnly = true
            });

            dgvAsistencia.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Asistio",
                HeaderText = "Asistió",
                DataPropertyName = "Asistio"
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraEntrada",
                HeaderText = "Hora Entrada",
                DataPropertyName = "HoraEntrada"
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraSalida",
                HeaderText = "Hora Salida",
                DataPropertyName = "HoraSalida"
            });

            dgvAsistencia.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Observaciones",
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones"
            });
        }

        private void CargarCursos()
        {
            string query = @"
                SELECT IdCurso, NombreCurso
                FROM Curso
                WHERE Activo = 1
                ORDER BY NombreCurso";

            DataTable dt = consultas.Consultar(query, new Dictionary<string, object>());

            cmbSesion.DataSource = dt;
            cmbSesion.DisplayMember = "NombreCurso";
            cmbSesion.ValueMember = "IdCurso";
            cmbSesion.SelectedIndex = -1;
        }

        private void CargarAlumnosCurso()
        {
            if (cmbSesion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            int idCurso = Convert.ToInt32(cmbSesion.SelectedValue);

            string query = @"
                SELECT
                    i.IdInscripcion,
                    a.NombreCompleto AS Alumno,
                    CAST(
                        CASE 
                            WHEN COUNT(s.IdSesion) > 0
                             AND SUM(CASE WHEN ISNULL(asi.Asistio, 0) = 1 THEN 1 ELSE 0 END) = COUNT(s.IdSesion)
                            THEN 1 ELSE 0 
                        END AS BIT
                    ) AS Asistio,
                    ISNULL(CONVERT(VARCHAR(5), MAX(asi.HoraEntrada), 108), '16:00') AS HoraEntrada,
                    ISNULL(CONVERT(VARCHAR(5), MAX(asi.HoraSalida), 108), '18:00') AS HoraSalida,
                    ISNULL(MAX(asi.Observaciones), '') AS Observaciones
                FROM InscripcionCurso i
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                LEFT JOIN SesionCurso s ON s.IdCurso = i.IdCurso
                LEFT JOIN AsistenciaSesion asi 
                    ON asi.IdSesion = s.IdSesion
                   AND asi.IdInscripcion = i.IdInscripcion
                WHERE i.IdCurso = @IdCurso
                GROUP BY i.IdInscripcion, a.NombreCompleto
                ORDER BY a.NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvAsistencia.DataSource = dt;
        }

        private bool ValidarGrid()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cmbSesion.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbSesion, "Seleccione un curso.");
                valido = false;
            }

            if (dgvAsistencia.Rows.Count == 0)
            {
                MessageBox.Show("No hay alumnos cargados.");
                valido = false;
            }

            return valido;
        }

        private DataTable ObtenerSesionesCurso(int idCurso)
        {
            string query = @"
                SELECT IdSesion
                FROM SesionCurso
                WHERE IdCurso = @IdCurso
                ORDER BY NumeroSesion";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso }
            };

            return consultas.Consultar(query, parametros);
        }

        private void GuardarAsistencia()
        {
            if (!ValidarGrid())
                return;

            int idCurso = Convert.ToInt32(cmbSesion.SelectedValue);
            DataTable sesiones = ObtenerSesionesCurso(idCurso);

            if (sesiones.Rows.Count == 0)
            {
                MessageBox.Show("Este curso no tiene sesiones creadas.");
                return;
            }

            foreach (DataGridViewRow row in dgvAsistencia.Rows)
            {
                if (row.IsNewRow) continue;

                int idInscripcion = Convert.ToInt32(row.Cells["IdInscripcion"].Value);

                bool asistio = row.Cells["Asistio"].Value != null &&
                               row.Cells["Asistio"].Value != DBNull.Value &&
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

                foreach (DataRow sesion in sesiones.Rows)
                {
                    int idSesion = Convert.ToInt32(sesion["IdSesion"]);

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
                            (IdSesion, IdInscripcion, Asistio, HoraEntrada, HoraSalida, Observaciones)
                            VALUES
                            (@IdSesion, @IdInscripcion, @Asistio, @HoraEntrada, @HoraSalida, @Observaciones)";

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
            }

            MessageBox.Show("Asistencia guardada correctamente para todas las sesiones del curso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarAlumnosCurso();
        }

        private void btnCargarAlumnos_Click(object sender, EventArgs e)
        {
            CargarAlumnosCurso();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarAsistencia();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}