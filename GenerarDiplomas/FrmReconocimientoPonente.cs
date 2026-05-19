using GenerarDiplomas.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GenerarDiplomas
{
    public partial class FrmReconocimientoPonente : FrmBase
    {
        public FrmReconocimientoPonente()
        {
            InitializeComponent();
        }

        private void FrmReconocimientoPonente_Load(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            EstilosUI.AplicarEstiloFormulario(this);

            EstilosUI.EstiloBoton(btnGenerar);

            if (btnSalir != null)
                EstilosUI.EstiloBoton(btnSalir);

            CargarCursos();
            CargarPonentes();
        }

        private void CargarCursos()
        {
            string query = @"
                SELECT IdCurso, NombreCurso
                FROM Curso
                WHERE Activo = 1
                ORDER BY NombreCurso";

            DataTable dt = consultas.Consultar(query,
                new Dictionary<string, object>());

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

            DataTable dt = consultas.Consultar(query,
                new Dictionary<string, object>());

            cmbPonente.DataSource = dt;
            cmbPonente.DisplayMember = "NombreCompleto";
            cmbPonente.ValueMember = "IdPonente";
            cmbPonente.SelectedIndex = -1;
        }

        private void RelacionarCursoPonente(int idCurso, int idPonente)
        {
            string queryExiste = @"
                SELECT COUNT(*)
                FROM CursoPonente
                WHERE IdCurso = @IdCurso
                  AND IdPonente = @IdPonente";

            var parametrosExiste = new Dictionary<string, object>()
            {
                { "@IdCurso", idCurso },
                { "@IdPonente", idPonente }
            };

            int existe = Convert.ToInt32(
                consultas.EjecutarEscalar(queryExiste, parametrosExiste));

            if (existe > 0)
                return;

            string insert = @"
                INSERT INTO CursoPonente
                (
                    IdCurso,
                    IdPonente
                )
                VALUES
                (
                    @IdCurso,
                    @IdPonente
                )";

            consultas.Ejecutar(insert, parametrosExiste);
        }

        private void GenerarPDF(
      string nombre,
      string curso,
      string duracion,
      string fecha,
      string ruta)
        {
            string rutaPlantilla = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    @"..\..\..\PlantillasDiplomas\ReconocimientoPonente.png"
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
                        layers.PrimaryLayer()
                            .Image(rutaPlantilla)
                            .FitArea();

                        layers.Layer().Column(col =>
                        {
                            col.Spacing(0);

                            // NOMBRE
                            col.Item().Height(235);

                            col.Item().AlignCenter().Text(nombre)
                                .FontSize(32)
                                .Bold()
                                .Italic()
                                .FontColor(Colors.Black);

                            // CURSO
                            col.Item().Height(70);

                            col.Item().AlignCenter().Text($"“{curso}”")
                                .FontSize(20)
                                .Bold()
                                .Italic()
                                .FontColor(Colors.Black);

                            // DURACIÓN Y FECHA
                            col.Item().Height(12);

                            col.Item().Row(row =>
                            {
                                // Base de tu bloque
                                row.ConstantItem(360);

                                // DURACIÓN
                                row.ConstantItem(160)
                                    .TranslateX(-10)
                                    .AlignLeft()
                                    .Text($"{duracion} horas")
                                    .FontSize(14)
                                    .FontColor(Colors.Black);

                                // Separación entre duración y fecha
                                row.ConstantItem(0);

                                // FECHA
                                row.ConstantItem(140)
                                    .TranslateX(-8)
                                    .AlignLeft()
                                    .Text(fecha)
                                    .FontSize(14)
                                    .FontColor(Colors.Black);
                            });
                            // FIRMA
                            col.Item().Height(110);

                            col.Item().Row(row =>
                            {
                                row.ConstantItem(690);

                                row.ConstantItem(220).Column(firma =>
                                {
                                    firma.Item().AlignCenter()
                                        .Text("Berrones Aguilar Juventino")
                                        .FontSize(10)
                                        .FontColor(Colors.Black);

                                    firma.Item().AlignCenter()
                                        .Text("Director General")
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
        }
        private void GenerarReconocimiento()
        {
            if (cmbCurso.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            if (cmbPonente.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un ponente.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDuracion.Text))
            {
                MessageBox.Show("Ingrese la duración.");
                txtDuracion.Focus();
                return;
            }

            int idCurso = Convert.ToInt32(cmbCurso.SelectedValue);
            int idPonente = Convert.ToInt32(cmbPonente.SelectedValue);

            RelacionarCursoPonente(idCurso, idPonente);

            string curso = cmbCurso.Text;
            string nombre = cmbPonente.Text;
            string duracion = txtDuracion.Text.Trim();

            DateTime fecha = DateTime.Now;

            string fechaTexto = fecha.ToString(
                "dd 'de' MMMM 'de' yyyy",
                new CultureInfo("es-MX"));

            string carpetaReconocimientos = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Reconocimientos");

            if (!Directory.Exists(carpetaReconocimientos))
            {
                Directory.CreateDirectory(carpetaReconocimientos);
            }

            string ruta = Path.Combine(
                carpetaReconocimientos,
                $"Reconocimiento_{nombre.Replace(" ", "_")}.pdf");

            GenerarPDF(
                nombre,
                curso,
                duracion,
                fechaTexto,
                ruta);

            if (File.Exists(ruta))
            {
                MessageBox.Show("Reconocimiento generado correctamente.");

                Process.Start(new ProcessStartInfo(ruta)
                {
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("No se generó el PDF:\n" + ruta);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReconocimiento();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            GenerarReconocimiento();
        }
    }
}