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
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Size = new Size(129, 35);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnTema
            // 
            btnTema.Location = new Point(525, 206);
            btnTema.Name = "btnTema";
            btnTema.Size = new Size(94, 29);
            btnTema.TabIndex = 1;
            btnTema.Text = "Tema";
            btnTema.UseVisualStyleBackColor = true;
            btnTema.Click += btnTema_Click;
            // 
            // btnSede
            // 
            btnSede.Location = new Point(650, 206);
            btnSede.Name = "btnSede";
            btnSede.Size = new Size(94, 29);
            btnSede.TabIndex = 2;
            btnSede.Text = "Sede";
            btnSede.UseVisualStyleBackColor = true;
            btnSede.Click += btnSede_Click;
            // 
            // btnPonente
            // 
            btnPonente.Location = new Point(774, 206);
            btnPonente.Name = "btnPonente";
            btnPonente.Size = new Size(94, 29);
            btnPonente.TabIndex = 3;
            btnPonente.Text = "Ponente";
            btnPonente.UseVisualStyleBackColor = true;
            btnPonente.Click += btnPonente_Click;
            // 
            // btnAlumno
            // 
            btnAlumno.Location = new Point(525, 263);
            btnAlumno.Name = "btnAlumno";
            btnAlumno.Size = new Size(94, 29);
            btnAlumno.TabIndex = 4;
            btnAlumno.Text = "Alumno";
            btnAlumno.UseVisualStyleBackColor = true;
            btnAlumno.Click += btnAlumno_Click;
            // 
            // btnCurso
            // 
            btnCurso.Location = new Point(650, 263);
            btnCurso.Name = "btnCurso";
            btnCurso.Size = new Size(94, 29);
            btnCurso.TabIndex = 5;
            btnCurso.Text = "Curso";
            btnCurso.UseVisualStyleBackColor = true;
            btnCurso.Click += btnCurso_Click;
            // 
            // button1
            // 
            button1.Location = new Point(774, 263);
            button1.Name = "button1";
            button1.Size = new Size(175, 29);
            button1.TabIndex = 6;
            button1.Text = "Curso Ponente";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnInscripcionCurso
            // 
            btnInscripcionCurso.Location = new Point(774, 324);
            btnInscripcionCurso.Name = "btnInscripcionCurso";
            btnInscripcionCurso.Size = new Size(175, 29);
            btnInscripcionCurso.TabIndex = 7;
            btnInscripcionCurso.Text = "Inscripcion Curso";
            btnInscripcionCurso.UseVisualStyleBackColor = true;
            btnInscripcionCurso.Click += btnInscripcionCurso_Click;
            // 
            // button2
            // 
            button2.Location = new Point(560, 324);
            button2.Name = "button2";
            button2.Size = new Size(175, 29);
            button2.TabIndex = 8;
            button2.Text = "secion Curso";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(345, 324);
            button3.Name = "button3";
            button3.Size = new Size(175, 29);
            button3.TabIndex = 9;
            button3.Text = "secion Curso";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(290, 206);
            button4.Name = "button4";
            button4.Size = new Size(175, 29);
            button4.TabIndex = 10;
            button4.Text = "Generar Diploma";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FrrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 518);
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
            Margin = new Padding(6, 3, 6, 3);
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
    }
}