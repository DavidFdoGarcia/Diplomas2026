namespace GenerarDiplomas
{
    partial class FrmSesionCurso
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
            panel1 = new Panel();
            label8 = new Label();
            dtpHoraFin = new DateTimePicker();
            label7 = new Label();
            dtpHoraInicio = new DateTimePicker();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            dgvSesiones = new DataGridView();
            dtpFecha = new DateTimePicker();
            txtBuscar = new TextBox();
            cmbCurso = new ComboBox();
            txtID = new TextBox();
            txtNumeroSesion = new TextBox();
            txtTemaSesion = new TextBox();
            txtObservaciones = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).BeginInit();
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
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(dtpHoraFin);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpHoraInicio);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(dgvSesiones);
            panel1.Controls.Add(dtpFecha);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(cmbCurso);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(txtNumeroSesion);
            panel1.Controls.Add(txtTemaSesion);
            panel1.Controls.Add(txtObservaciones);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 9);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1478, 641);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1288, 23);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(112, 23);
            label8.TabIndex = 21;
            label8.Text = "Hora de Fin";
            label8.Click += label8_Click;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Location = new Point(1244, 74);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(250, 30);
            dtpHoraFin.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1056, 26);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(153, 23);
            label7.TabIndex = 19;
            label7.Text = "Horario de Inicio";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Location = new Point(979, 77);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(250, 30);
            dtpHoraInicio.TabIndex = 18;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(179, 595);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 17;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(303, 595);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(462, 595);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 15;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(631, 595);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvSesiones
            // 
            dgvSesiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSesiones.Location = new Point(23, 179);
            dgvSesiones.Name = "dgvSesiones";
            dgvSesiones.RowHeadersWidth = 51;
            dgvSesiones.Size = new Size(1108, 380);
            dgvSesiones.TabIndex = 13;
            dgvSesiones.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dgvSesiones.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(675, 60);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 30);
            dtpFecha.TabIndex = 12;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(128, 128);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(797, 30);
            txtBuscar.TabIndex = 11;
            txtBuscar.TextChanged += textBox5_TextChanged;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(759, 23);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(151, 31);
            cmbCurso.TabIndex = 10;
            // 
            // txtID
            // 
            txtID.Location = new Point(93, 23);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 9;
            txtID.TextChanged += textBox4_TextChanged;
            // 
            // txtNumeroSesion
            // 
            txtNumeroSesion.Location = new Point(208, 80);
            txtNumeroSesion.Name = "txtNumeroSesion";
            txtNumeroSesion.Size = new Size(125, 30);
            txtNumeroSesion.TabIndex = 8;
            txtNumeroSesion.TextChanged += textBox3_TextChanged;
            // 
            // txtTemaSesion
            // 
            txtTemaSesion.Location = new Point(502, 26);
            txtTemaSesion.Name = "txtTemaSesion";
            txtTemaSesion.Size = new Size(125, 30);
            txtTemaSesion.TabIndex = 7;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(502, 80);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(125, 30);
            txtObservaciones.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 83);
            label6.Name = "label6";
            label6.Size = new Size(172, 23);
            label6.TabIndex = 5;
            label6.Text = "Número de Sesion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(328, 26);
            label5.Name = "label5";
            label5.Size = new Size(158, 23);
            label5.TabIndex = 4;
            label5.Text = "´Tema de Sesion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(348, 80);
            label4.Name = "label4";
            label4.Size = new Size(141, 23);
            label4.TabIndex = 3;
            label4.Text = "Observaciones";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 26);
            label3.Name = "label3";
            label3.Size = new Size(30, 23);
            label3.TabIndex = 2;
            label3.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 128);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 1;
            label2.Text = "Buscar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(663, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 0;
            label1.Text = "Curso";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmSesionCurso
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1508, 664);
            Controls.Add(panel1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmSesionCurso";
            Text = "FrmSesionCurso";
            Load += FrmSesionCurso_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmbCurso;
        private TextBox txtID;
        private TextBox txtNumeroSesion;
        private TextBox txtTemaSesion;
        private TextBox txtObservaciones;
        private DateTimePicker dtpFecha;
        private TextBox txtBuscar;
        private ErrorProvider errorProvider1;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private DataGridView dgvSesiones;
        private Label label8;
        private DateTimePicker dtpHoraFin;
        private Label label7;
        private DateTimePicker dtpHoraInicio;
    }
}