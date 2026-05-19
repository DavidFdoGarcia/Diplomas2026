namespace GenerarDiplomas
{
    partial class FrrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTema = new Button();
            btnSede = new Button();
            btnPonente = new Button();
            btnAlumno = new Button();
            btnCurso = new Button();
            button1 = new Button();
            btnInscripcionCurso = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btnAltaCursos = new Button();
            btnReconocimiento = new Button();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Margin = new Padding(2);
            btnSalir.Size = new Size(106, 27);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnTema
            // 
            btnTema.Location = new Point(548, 260);
            btnTema.Margin = new Padding(2);
            btnTema.Name = "btnTema";
            btnTema.Size = new Size(77, 23);
            btnTema.TabIndex = 1;
            btnTema.Text = "Tema";
            btnTema.UseVisualStyleBackColor = true;
            btnTema.Click += btnTema_Click;
            // 
            // btnSede
            // 
            btnSede.Location = new Point(650, 260);
            btnSede.Margin = new Padding(2);
            btnSede.Name = "btnSede";
            btnSede.Size = new Size(77, 23);
            btnSede.TabIndex = 2;
            btnSede.Text = "Sede";
            btnSede.UseVisualStyleBackColor = true;
            btnSede.Click += btnSede_Click;
            // 
            // btnPonente
            // 
            btnPonente.Location = new Point(751, 260);
            btnPonente.Margin = new Padding(2);
            btnPonente.Name = "btnPonente";
            btnPonente.Size = new Size(77, 23);
            btnPonente.TabIndex = 3;
            btnPonente.Text = "Ponente";
            btnPonente.UseVisualStyleBackColor = true;
            btnPonente.Click += btnPonente_Click;
            // 
            // btnAlumno
            // 
            btnAlumno.Location = new Point(259, 42);
            btnAlumno.Margin = new Padding(2);
            btnAlumno.Name = "btnAlumno";
            btnAlumno.Size = new Size(77, 23);
            btnAlumno.TabIndex = 4;
            btnAlumno.Text = "Alumno";
            btnAlumno.UseVisualStyleBackColor = true;
            btnAlumno.Click += btnAlumno_Click;
            // 
            // btnCurso
            // 
            btnCurso.Location = new Point(650, 305);
            btnCurso.Margin = new Padding(2);
            btnCurso.Name = "btnCurso";
            btnCurso.Size = new Size(77, 23);
            btnCurso.TabIndex = 5;
            btnCurso.Text = "Curso";
            btnCurso.UseVisualStyleBackColor = true;
            btnCurso.Click += btnCurso_Click;
            // 
            // button1
            // 
            button1.Location = new Point(751, 305);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 6;
            button1.Text = "Curso Ponente";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnInscripcionCurso
            // 
            btnInscripcionCurso.Location = new Point(236, 99);
            btnInscripcionCurso.Margin = new Padding(2);
            btnInscripcionCurso.Name = "btnInscripcionCurso";
            btnInscripcionCurso.Size = new Size(143, 23);
            btnInscripcionCurso.TabIndex = 7;
            btnInscripcionCurso.Text = "Inscripcion Curso";
            btnInscripcionCurso.UseVisualStyleBackColor = true;
            btnInscripcionCurso.Click += btnInscripcionCurso_Click;
            // 
            // button2
            // 
            button2.Location = new Point(576, 353);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(143, 23);
            button2.TabIndex = 8;
            button2.Text = "secion Curso";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(236, 146);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(143, 23);
            button3.TabIndex = 9;
            button3.Text = "secion Curso";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(236, 193);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(143, 23);
            button4.TabIndex = 10;
            button4.Text = "Generar Diploma";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(25, 25);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(150, 57);
            button5.TabIndex = 11;
            button5.Text = "Reconocimiento Ponente";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnAltaCursos
            // 
            btnAltaCursos.Location = new Point(25, 99);
            btnAltaCursos.Margin = new Padding(2);
            btnAltaCursos.Name = "btnAltaCursos";
            btnAltaCursos.Size = new Size(96, 58);
            btnAltaCursos.TabIndex = 12;
            btnAltaCursos.Text = "Alta Cursos";
            btnAltaCursos.UseVisualStyleBackColor = true;
            btnAltaCursos.Click += btnAltaCursos_Click;
            // 
            // btnReconocimiento
            // 
            btnReconocimiento.Location = new Point(32, 204);
            btnReconocimiento.Margin = new Padding(2);
            btnReconocimiento.Name = "btnReconocimiento";
            btnReconocimiento.Size = new Size(167, 59);
            btnReconocimiento.TabIndex = 13;
            btnReconocimiento.Text = "Reconocimiennto Ponente";
            btnReconocimiento.UseVisualStyleBackColor = true;
            btnReconocimiento.Click += btnReconocimiento_Click;
            // 
            // FrrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 405);
            Controls.Add(btnReconocimiento);
            Controls.Add(btnAltaCursos);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnInscripcionCurso);
            Controls.Add(button1);
            Controls.Add(btnCurso);
            Controls.Add(btnAlumno);
            Controls.Add(btnPonente);
            Controls.Add(btnSede);
            Controls.Add(btnTema);
            Margin = new Padding(5, 2, 5, 2);
            Name = "FrrmPrincipal";
            Text = "FrrmPrincipal";
            Load += FrrmPrincipal_Load;
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(btnTema, 0);
            Controls.SetChildIndex(btnSede, 0);
            Controls.SetChildIndex(btnPonente, 0);
            Controls.SetChildIndex(btnAlumno, 0);
            Controls.SetChildIndex(btnCurso, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(btnInscripcionCurso, 0);
            Controls.SetChildIndex(button2, 0);
            Controls.SetChildIndex(button3, 0);
            Controls.SetChildIndex(button4, 0);
            Controls.SetChildIndex(button5, 0);
            Controls.SetChildIndex(btnAltaCursos, 0);
            Controls.SetChildIndex(btnReconocimiento, 0);
            ResumeLayout(false);
        }

        #endregion

        private Button btnTema;
        private Button btnSede;
        private Button btnPonente;
        private Button btnAlumno;
        private Button btnCurso;
        private Button button1;
        private Button btnInscripcionCurso;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btnAltaCursos;
        private Button btnReconocimiento;
    }
}