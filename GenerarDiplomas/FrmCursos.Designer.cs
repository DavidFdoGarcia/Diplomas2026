namespace GenerarDiplomas
{
    partial class FrmCursos
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
            txtID = new TextBox();
            txtNombreCurso = new TextBox();
            txtBuscar = new TextBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            dgvCursos = new DataGridView();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(827, 714);
            btnSalir.Margin = new Padding(4, 2, 4, 2);
            btnSalir.Size = new Size(106, 42);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // txtID
            // 
            txtID.Location = new Point(112, 28);
            txtID.Margin = new Padding(4);
            txtID.Name = "txtID";
            txtID.Size = new Size(127, 26);
            txtID.TabIndex = 0;
            // 
            // txtNombreCurso
            // 
            txtNombreCurso.Location = new Point(112, 62);
            txtNombreCurso.Margin = new Padding(4);
            txtNombreCurso.Name = "txtNombreCurso";
            txtNombreCurso.Size = new Size(127, 26);
            txtNombreCurso.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(127, 148);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(127, 26);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(405, 62);
            dtpFechaInicio.Margin = new Padding(4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(256, 26);
            dtpFechaInicio.TabIndex = 4;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(426, 121);
            dtpFechaFin.Margin = new Padding(4);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(256, 26);
            dtpFechaFin.TabIndex = 5;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(843, 41);
            rbActivo.Margin = new Padding(4);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(69, 22);
            rbActivo.TabIndex = 6;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(855, 101);
            rbInactivo.Margin = new Padding(4);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(78, 22);
            rbInactivo.TabIndex = 7;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(70, 224);
            dgvCursos.Margin = new Padding(4);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(1520, 427);
            dgvCursos.TabIndex = 8;
            dgvCursos.CellDoubleClick += dgvCursos_CellDoubleClick_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(405, 728);
            btnEditar.Margin = new Padding(4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(96, 28);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(226, 728);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 28);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(93, 728);
            btnNuevo.Margin = new Padding(4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(96, 28);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextAlign = ContentAlignment.TopCenter;
            btnNuevo.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(586, 728);
            btnCancelar.Margin = new Padding(4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 28);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 151);
            label1.Name = "label1";
            label1.Size = new Size(57, 18);
            label1.TabIndex = 13;
            label1.Text = "Buscar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 70);
            label2.Name = "label2";
            label2.Size = new Size(50, 18);
            label2.TabIndex = 14;
            label2.Text = "Curso";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 36);
            label3.Name = "label3";
            label3.Size = new Size(23, 18);
            label3.TabIndex = 15;
            label3.Text = "ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(338, 129);
            label4.Name = "label4";
            label4.Size = new Size(30, 18);
            label4.TabIndex = 16;
            label4.Text = "Fin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 62);
            label5.Name = "label5";
            label5.Size = new Size(44, 18);
            label5.TabIndex = 17;
            label5.Text = "Inicio";
            // 
            // FrmCursos
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1750, 803);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(dgvCursos);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(txtBuscar);
            Controls.Add(txtNombreCurso);
            Controls.Add(txtID);
            Margin = new Padding(4, 2, 4, 2);
            Name = "FrmCursos";
            Text = "FrmCursos";
            Load += FrmCursos_Load;
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(txtNombreCurso, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(dtpFechaInicio, 0);
            Controls.SetChildIndex(dtpFechaFin, 0);
            Controls.SetChildIndex(rbActivo, 0);
            Controls.SetChildIndex(rbInactivo, 0);
            Controls.SetChildIndex(dgvCursos, 0);
            Controls.SetChildIndex(btnEditar, 0);
            Controls.SetChildIndex(btnGuardar, 0);
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtID;
        private TextBox txtNombreCurso;
        private TextBox txtBuscar;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private DataGridView dgvCursos;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}