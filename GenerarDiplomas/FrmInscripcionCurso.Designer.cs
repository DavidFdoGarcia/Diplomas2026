namespace GenerarDiplomas
{
    partial class FrmInscripcionCurso
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtBuscar = new TextBox();
            txtObservaciones = new TextBox();
            txtFolioInscripcion = new TextBox();
            txtID = new TextBox();
            cmbAlumno = new ComboBox();
            cmbCurso = new ComboBox();
            cmbEstatus = new ComboBox();
            dtpFechaInscripcion = new DateTimePicker();
            dgvInscripciones = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            btnNuevo = new Button();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(1266, 528);
            btnSalir.Margin = new Padding(6, 3, 6, 3);
            btnSalir.Size = new Size(177, 40);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(30, 23);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(772, 110);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 4;
            label4.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(772, 62);
            label5.Name = "label5";
            label5.Size = new Size(74, 23);
            label5.TabIndex = 5;
            label5.Text = "Alumno";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(772, 18);
            label6.Name = "label6";
            label6.Size = new Size(62, 23);
            label6.TabIndex = 6;
            label6.Text = "Curso";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 155);
            label7.Name = "label7";
            label7.Size = new Size(71, 23);
            label7.TabIndex = 7;
            label7.Text = "Buscar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 110);
            label8.Name = "label8";
            label8.Size = new Size(141, 23);
            label8.TabIndex = 8;
            label8.Text = "Observaciones";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 62);
            label9.Name = "label9";
            label9.Size = new Size(177, 23);
            label9.TabIndex = 9;
            label9.Text = "Folio de inscripcion";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(94, 148);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(880, 30);
            txtBuscar.TabIndex = 10;
            txtBuscar.TextChanged += textBox1_TextChanged;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(201, 107);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(125, 30);
            txtObservaciones.TabIndex = 11;
            // 
            // txtFolioInscripcion
            // 
            txtFolioInscripcion.Location = new Point(223, 55);
            txtFolioInscripcion.Name = "txtFolioInscripcion";
            txtFolioInscripcion.Size = new Size(125, 30);
            txtFolioInscripcion.TabIndex = 12;
            // 
            // txtID
            // 
            txtID.Location = new Point(94, 11);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 13;
            // 
            // cmbAlumno
            // 
            cmbAlumno.FormattingEnabled = true;
            cmbAlumno.Location = new Point(867, 62);
            cmbAlumno.Name = "cmbAlumno";
            cmbAlumno.Size = new Size(151, 31);
            cmbAlumno.TabIndex = 14;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(858, 11);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(151, 31);
            cmbCurso.TabIndex = 15;
            // 
            // cmbEstatus
            // 
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(867, 111);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(151, 31);
            cmbEstatus.TabIndex = 16;
            // 
            // dtpFechaInscripcion
            // 
            dtpFechaInscripcion.Location = new Point(375, 73);
            dtpFechaInscripcion.Name = "dtpFechaInscripcion";
            dtpFechaInscripcion.Size = new Size(300, 30);
            dtpFechaInscripcion.TabIndex = 17;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(12, 197);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.RowHeadersWidth = 51;
            dgvInscripciones.Size = new Size(1048, 346);
            dgvInscripciones.TabIndex = 18;
            dgvInscripciones.CellDoubleClick += dgvInscripciones_CellDoubleClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(435, 557);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(794, 557);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(676, 557);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(552, 557);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmInscripcionCurso
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 588);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvInscripciones);
            Controls.Add(dtpFechaInscripcion);
            Controls.Add(cmbEstatus);
            Controls.Add(cmbCurso);
            Controls.Add(cmbAlumno);
            Controls.Add(txtID);
            Controls.Add(txtFolioInscripcion);
            Controls.Add(txtObservaciones);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmInscripcionCurso";
            Text = "FrmInscripcionCurso";
            Load += FrmInscripcionCurso_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(label9, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(txtObservaciones, 0);
            Controls.SetChildIndex(txtFolioInscripcion, 0);
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(cmbAlumno, 0);
            Controls.SetChildIndex(cmbCurso, 0);
            Controls.SetChildIndex(cmbEstatus, 0);
            Controls.SetChildIndex(dtpFechaInscripcion, 0);
            Controls.SetChildIndex(dgvInscripciones, 0);
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnEditar, 0);
            Controls.SetChildIndex(btnGuardar, 0);
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtBuscar;
        private TextBox txtObservaciones;
        private TextBox txtFolioInscripcion;
        private TextBox txtID;
        private ComboBox cmbAlumno;
        private ComboBox cmbCurso;
        private ComboBox cmbEstatus;
        private DateTimePicker dtpFechaInscripcion;
        private DataGridView dgvInscripciones;
        private ErrorProvider errorProvider1;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnNuevo;
    }
}