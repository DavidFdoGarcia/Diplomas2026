namespace GenerarDiplomas
{
    partial class FrmAsistenciaSesion
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
            cmbSesion = new ComboBox();
            btnCargarAlumnos = new Button();
            dgvAsistencia = new DataGridView();
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            chkAsistioTodas = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(591, 540);
            btnSalir.Margin = new Padding(6, 3, 6, 3);
            btnSalir.Size = new Size(177, 40);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 19);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 0;
            label1.Text = "Sesion";
            // 
            // cmbSesion
            // 
            cmbSesion.FormattingEnabled = true;
            cmbSesion.Location = new Point(119, 23);
            cmbSesion.Name = "cmbSesion";
            cmbSesion.Size = new Size(151, 31);
            cmbSesion.TabIndex = 1;
            // 
            // btnCargarAlumnos
            // 
            btnCargarAlumnos.Location = new Point(345, 19);
            btnCargarAlumnos.Name = "btnCargarAlumnos";
            btnCargarAlumnos.Size = new Size(97, 54);
            btnCargarAlumnos.TabIndex = 2;
            btnCargarAlumnos.Text = "Cargar Alumnos";
            btnCargarAlumnos.UseVisualStyleBackColor = true;
            btnCargarAlumnos.Click += btnCargarAlumnos_Click;
            // 
            // dgvAsistencia
            // 
            dgvAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencia.Location = new Point(10, 77);
            dgvAsistencia.Name = "dgvAsistencia";
            dgvAsistencia.RowHeadersWidth = 51;
            dgvAsistencia.Size = new Size(1110, 442);
            dgvAsistencia.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(392, 540);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // chkAsistioTodas
            // 
            chkAsistioTodas.AutoSize = true;
            chkAsistioTodas.Location = new Point(530, 34);
            chkAsistioTodas.Name = "chkAsistioTodas";
            chkAsistioTodas.Size = new Size(202, 27);
            chkAsistioTodas.TabIndex = 5;
            chkAsistioTodas.Text = "ASISTIÓ A TODAS";
            chkAsistioTodas.UseVisualStyleBackColor = true;
            // 
            // FrmAsistenciaSesion
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 590);
            Controls.Add(chkAsistioTodas);
            Controls.Add(btnGuardar);
            Controls.Add(dgvAsistencia);
            Controls.Add(btnCargarAlumnos);
            Controls.Add(cmbSesion);
            Controls.Add(label1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmAsistenciaSesion";
            Text = "FrmAsistenciaSesion";
            Load += FrmAsistenciaSesion_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(cmbSesion, 0);
            Controls.SetChildIndex(btnCargarAlumnos, 0);
            Controls.SetChildIndex(dgvAsistencia, 0);
            Controls.SetChildIndex(btnGuardar, 0);
            Controls.SetChildIndex(chkAsistioTodas, 0);
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbSesion;
        private Button btnCargarAlumnos;
        private DataGridView dgvAsistencia;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
        private CheckBox chkAsistioTodas;
    }
}