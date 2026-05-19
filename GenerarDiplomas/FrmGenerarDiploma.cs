using GenerarDiplomas.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;

namespace GenerarDiplomas
{
    public partial class FrmGenerarDiploma : FrmBase
    {
        public FrmGenerarDiploma()
        {
            InitializeComponent();
        }

        private void FrmGenerarDiploma_Load(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            EstilosUI.AplicarEstiloFormulario(this);

            if (btnCargar != null) EstilosUI.EstiloBoton(btnCargar);
            if (btnGenerar != null) EstilosUI.EstiloBoton(btnGenerar);
            if (btnGenerarTodos != null) EstilosUI.EstiloBoton(btnGenerarTodos);
            if (btnSalir != null) EstilosUI.EstiloBoton(btnSalir);

            ConfigurarGrid();
            CargarCursos();
        }
        private void ConfigurarGrid()
        {
            dgvDiplomas.ReadOnly = true;
            dgvDiplomas.AllowUserToAddRows = false;
            dgvDiplomas.AllowUserToDeleteRows = false;
            dgvDiplomas.MultiSelect = false;
            dgvDiplomas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiplomas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiplomas.RowHeadersVisible = false;
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

        private void CargarDiplomasPorCurso()
        {
            if (cmbCurso.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);

            string query = @"
                SELECT
                    i.IdInscripcion,
                    a.NombreCompleto AS Alumno,
                    c.NombreCurso,
                    v.TotalSesiones,
                    v.SesionesAsistidas,
                    v.PorcentajeAsistencia,
                    c.PorcentajeMinimoDiploma,
                    CASE 
                        WHEN v.PorcentajeAsistencia >= c.PorcentajeMinimoDiploma THEN 'SI'
                        ELSE 'NO'
                    END AS CumpleDiploma
                FROM InscripcionCurso i
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                INNER JOIN Curso c ON c.IdCurso = i.IdCurso
                INNER JOIN vw_AsistenciaPorCurso v ON v.IdInscripcion = i.IdInscripcion
                WHERE i.IdCurso = @IdCurso
                ORDER BY a.NombreCompleto";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", idCurso }
            };

            DataTable dt = consultas.Consultar(query, parametros);
            dgvDiplomas.DataSource = dt;

            if (dgvDiplomas.Columns.Count > 0)
            {
                dgvDiplomas.Columns["IdInscripcion"].HeaderText = "ID";
                dgvDiplomas.Columns["Alumno"].HeaderText = "Alumno";
                dgvDiplomas.Columns["NombreCurso"].HeaderText = "Curso";
                dgvDiplomas.Columns["TotalSesiones"].HeaderText = "Total Sesiones";
                dgvDiplomas.Columns["SesionesAsistidas"].HeaderText = "Asistencias";
                dgvDiplomas.Columns["PorcentajeAsistencia"].HeaderText = "% Asistencia";
                dgvDiplomas.Columns["PorcentajeMinimoDiploma"].HeaderText = "% Mínimo";
                dgvDiplomas.Columns["CumpleDiploma"].HeaderText = "Cumple";
            }
        }

        private void GenerarPDF(string nombre, string curso, string dia, string mes, string anio, string ruta, string nombrePonente)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                string rutaPlantilla = Path.GetFullPath(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        @"..\..\..\PlantillasDiplomas\CONTABILIDAD.png"
                    )
                );

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla:\n" + rutaPlantilla);
                    return;
                }

                QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(0);

                        page.Content().Layers(layers =>
                        {
                            // PLANTILLA DE FONDO
                            layers.PrimaryLayer()
                                .Image(rutaPlantilla)
                                .FitArea();

                            // TEXTOS ENCIMA
                            layers.Layer().Column(col =>
                            {
                                col.Spacing(0);
                                // =========================
                                // NOMBRE
                                // =========================
                                col.Item().Height(225);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(320); // 👈 AJUSTA ESTE NÚMERO

                                    row.RelativeItem().AlignLeft().Text(nombre)
                                        .FontSize(27)
                                        .Bold()
                                        .Italic()
                                        .FontColor(Colors.Black);
                                });

                                // =========================
                                // CURSO
                                // =========================
                                col.Item().Height(65);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(300);

                                    row.ConstantItem(500).AlignLeft().Text(curso)
                                        .FontSize(18)
                                        .FontColor(Colors.Black);
                                });

                                // =========================
                                // FECHA (UNA SOLA LÍNEA)
                                // =========================
                                col.Item().Height(25);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(330); // mueve izquierda/derecha

                                    row.ConstantItem(400).AlignLeft().Text($"{dia} de {mes} de {anio}")
                                        .FontSize(18)
                                        .FontColor(Colors.Black);
                                });

                                // =========================
                                // PONENTE / FIRMA
                                // =========================
                                col.Item().Height(118);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(690);

                                    row.ConstantItem(220).Column(firma =>
                                    {
                                        firma.Item().AlignCenter().Text(nombrePonente)
                                            .FontSize(10)
                                            .FontColor(Colors.Black);

                                        firma.Item().AlignCenter().Text("Director General")
                                            .FontSize(12)
                                            .Bold()
                                            .FontColor(Colors.Black);
                                    });
                                });
                            });
                        });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show("PDF generado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF:\n\n" + ex.Message);
            }
        }
        private bool GenerarDiplomaDesdeBD(int idInscripcion, bool mostrarMensajes = true)
        {
            string query = @"
        SELECT TOP 1
            a.NombreCompleto,
            c.NombreCurso,
            c.FechaFin AS FechaCurso,
            v.PorcentajeAsistencia,
            c.PorcentajeMinimoDiploma,
            ISNULL(p.NombreCompleto, 'Berrones Aguilar Juventino') AS NombrePonente
        FROM InscripcionCurso i
        INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
        INNER JOIN Curso c ON c.IdCurso = i.IdCurso
        INNER JOIN vw_AsistenciaPorCurso v ON v.IdInscripcion = i.IdInscripcion
        LEFT JOIN CursoPonente cp 
            ON cp.IdCurso = c.IdCurso
        LEFT JOIN Ponente p 
            ON p.IdPonente = cp.IdPonente
        WHERE i.IdInscripcion = @id
        ORDER BY p.NombreCompleto";

            var parametros = new Dictionary<string, object>()
    {
        { "@id", idInscripcion }
    };

            DataTable dt = consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
            {
                if (mostrarMensajes)
                    MessageBox.Show("No se encontró información.");
                return false;
            }

            DataRow row = dt.Rows[0];

            string nombre = row["NombreCompleto"]?.ToString() ?? "";
            string curso = row["NombreCurso"]?.ToString() ?? "";
            string nombrePonente = row["NombrePonente"]?.ToString() ?? "Berrones Aguilar Juventino";

            decimal porcentaje = Convert.ToDecimal(row["PorcentajeAsistencia"]);
            decimal minimo = Convert.ToDecimal(row["PorcentajeMinimoDiploma"]);

            if (porcentaje < minimo)
            {
                if (mostrarMensajes)
                    MessageBox.Show($"No cumple asistencia ({porcentaje}%).");
                return false;
            }

            DateTime fechaCurso = Convert.ToDateTime(row["FechaCurso"]);

            string dia = fechaCurso.Day.ToString();
            string mes = fechaCurso.ToString("MMMM", new CultureInfo("es-MX"));
            string anio = fechaCurso.Year.ToString();

            mes = char.ToUpper(mes[0]) + mes.Substring(1);

            string ruta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Diploma_{nombre.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            );

            GenerarPDF(nombre, curso, dia, mes, anio, ruta, nombrePonente);

            if (mostrarMensajes)
            {
                MessageBox.Show("Diploma generado correctamente.");
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }

            return true;
        }
        /*  private void GenerarPDF(string nombre, string curso, string fecha, string ruta, string nombrePonente)
          {
              QuestPDF.Settings.License = LicenseType.Community;

              string rutaPlantilla = @"C:\Users\David\Desktop\GenerarDiplomas\PlantillasDiplomas\DiplomadecertificaciónPCSolución.png";

              if (!File.Exists(rutaPlantilla))
              {
                  MessageBox.Show("No se encontró la plantilla:\n" + rutaPlantilla);
                  return;
              }

              QuestPDF.Fluent.Document.Create(container =>
              {
                  container.Page(page =>
                  {
                      page.Size(PageSizes.A4.Landscape());
                      page.Margin(0);

                      page.Content().Layers(layers =>
                      {
                          layers.PrimaryLayer().Image(rutaPlantilla);

                          layers.Layer().Column(col =>
                          {
                              col.Spacing(0);

                              // NOMBRE
                              col.Item().Height(245);
                              col.Item().AlignCenter().Text(nombre)
                                  .FontSize(27)
                                  .Bold()
                                  .Italic()
                                  .FontColor(Colors.Black);

                              col.Item().AlignCenter().Width(520).LineHorizontal(1);

                              // CURSO en la línea de "curso de"
                              col.Item().Height(74);
                              col.Item().Row(row =>
                              {
                                  row.ConstantItem(255);

                                  row.ConstantItem(300).AlignLeft().Text(curso)
                                      .FontSize(10)
                                      .FontColor(Colors.Black);
                              });

                              // FECHA en el siguiente renglón
                              col.Item().Height(22);
                              col.Item().Row(row =>
                              {
                                  row.ConstantItem(610);

                                  row.ConstantItem(220).AlignLeft().Text(fecha)
                                      .FontSize(10)
                                      .FontColor(Colors.Black);
                              });

                              // PONENTE
                              col.Item().Height(125);
                              col.Item().Row(row =>
                              {
                                  row.ConstantItem(650);

                                  row.ConstantItem(250).Column(firma =>
                                  {
                                      firma.Item().AlignCenter().Text(nombrePonente)
                                          .FontSize(11)
                                          .FontColor(Colors.Black);

                                      firma.Item().AlignCenter().Text("Director General")
                                          .FontSize(13)
                                          .Bold()
                                          .FontColor(Colors.Black);
                                  });
                              });
                          });
                      });
                  });
              })
              .GeneratePdf(ruta);
          }

          private void GenerarDiplomaDesdeBD(int idInscripcion)
          {
              string query = @"
                  SELECT 
                      a.NombreCompleto,
                      c.NombreCurso,
                      c.FechaFin AS FechaCurso,
                      v.PorcentajeAsistencia,
                      c.PorcentajeMinimoDiploma,
                      ISNULL(p.NombreCompleto, 'Berrones Aguilar Juventino') AS NombrePonente
                  FROM InscripcionCurso i
                  INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                  INNER JOIN Curso c ON c.IdCurso = i.IdCurso
                  INNER JOIN vw_AsistenciaPorCurso v ON v.IdInscripcion = i.IdInscripcion
                  LEFT JOIN CursoPonente cp 
                      ON cp.IdCurso = c.IdCurso
                     AND ISNULL(cp.OrdenFirma, 1) = 1
                  LEFT JOIN Ponente p 
                      ON p.IdPonente = cp.IdPonente
                  WHERE i.IdInscripcion = @id";

              var parametros = new Dictionary<string, object>()
              {
                  { "@id", idInscripcion }
              };

              var dt = consultas.Consultar(query, parametros);

              if (dt.Rows.Count == 0)
              {
                  MessageBox.Show("No se encontró información");
                  return;
              }

              var row = dt.Rows[0];

              string nombre = row["NombreCompleto"]?.ToString() ?? "";
              string curso = row["NombreCurso"]?.ToString() ?? "";
              string nombrePonente = row["NombrePonente"]?.ToString() ?? "Berrones Aguilar Juventino";

              decimal porcentaje = Convert.ToDecimal(row["PorcentajeAsistencia"]);
              decimal minimo = Convert.ToDecimal(row["PorcentajeMinimoDiploma"]);

              if (porcentaje < minimo)
              {
                  MessageBox.Show($"No cumple asistencia ({porcentaje}%)");
                  return;
              }

              DateTime fechaCurso = Convert.ToDateTime(row["FechaCurso"]);
              string fecha = fechaCurso.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-MX"));

              string ruta = Path.Combine(
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                  $"Diploma_{nombre.Replace(" ", "_")}.pdf"
              );

              GenerarPDF(nombre, curso, fecha, ruta, nombrePonente);

              MessageBox.Show("Diploma generado correctamente");

              Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
          } */

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (dgvDiplomas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro del grid.");
                return;
            }

            int idInscripcion = Convert.ToInt32(dgvDiplomas.CurrentRow.Cells["IdInscripcion"].Value);
            GenerarDiplomaDesdeBD(idInscripcion, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecciona la plantilla";
            ofd.Filter = "Imágenes PNG|*.png|Todas las imágenes|*.png;*.jpg;*.jpeg|Todos los archivos|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);

                string rutaPlantilla = ofd.FileName;

                if (File.Exists(rutaPlantilla))
                    MessageBox.Show("Sí existe");
                else
                    MessageBox.Show("No existe");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDiplomasPorCurso();
        }

        private void btnGenerarTodos_Click(object sender, EventArgs e)
        {
            if (dgvDiplomas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros cargados.");
                return;
            }

            int generados = 0;

            foreach (DataGridViewRow row in dgvDiplomas.Rows)
            {
                if (row.Cells["CumpleDiploma"].Value != null &&
                    row.Cells["CumpleDiploma"].Value.ToString() == "SI")
                {
                    int idInscripcion = Convert.ToInt32(row.Cells["IdInscripcion"].Value);

                    if (GenerarDiplomaDesdeBD(idInscripcion, false))
                        generados++;
                }
            }

            MessageBox.Show($"Se generaron {generados} diplomas correctamente.");
        }
    }
}
