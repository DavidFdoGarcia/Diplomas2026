namespace GenerarDiplomas
{
    partial class FrmAlumno
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
            btnGuardar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnNuevo = new Button();
            dgvAlumnos = new DataGridView();
            txtID = new TextBox();
            txtNombre = new TextBox();
            txtApellidoPaterno = new TextBox();
            txtApellidoMaterno = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtEmpresa = new TextBox();
            txtPuesto = new TextBox();
            txtBuscar = new TextBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            ID = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
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
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(dgvAlumnos);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(txtApellidoPaterno);
            panel1.Controls.Add(txtApellidoMaterno);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(txtCorreo);
            panel1.Controls.Add(txtEmpresa);
            panel1.Controls.Add(txtPuesto);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(rbInactivo);
            panel1.Controls.Add(rbActivo);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(ID);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1127, 637);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(316, 582);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 26;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(429, 582);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 25;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(541, 582);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(203, 582);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 23;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Location = new Point(15, 224);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersWidth = 51;
            dgvAlumnos.Size = new Size(1041, 348);
            dgvAlumnos.TabIndex = 22;
            dgvAlumnos.CellDoubleClick += dgvAlumnos_CellDoubleClick;
            // 
            // txtID
            // 
            txtID.Location = new Point(68, 11);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 21;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(109, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(249, 30);
            txtNombre.TabIndex = 20;
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Location = new Point(186, 121);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(224, 30);
            txtApellidoPaterno.TabIndex = 19;
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Location = new Point(637, 22);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(224, 30);
            txtApellidoMaterno.TabIndex = 18;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(556, 69);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(175, 30);
            txtTelefono.TabIndex = 17;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(556, 124);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(198, 30);
            txtCorreo.TabIndex = 16;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(935, 96);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(144, 30);
            txtEmpresa.TabIndex = 15;
            // 
            // txtPuesto
            // 
            txtPuesto.Location = new Point(966, 29);
            txtPuesto.Name = "txtPuesto";
            txtPuesto.Size = new Size(125, 30);
            txtPuesto.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(122, 188);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(632, 30);
            txtBuscar.TabIndex = 13;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(911, 140);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(98, 27);
            rbInactivo.TabIndex = 12;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(801, 140);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 27);
            rbActivo.TabIndex = 11;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 60);
            label10.Name = "label10";
            label10.Size = new Size(79, 23);
            label10.TabIndex = 10;
            label10.Text = "Nombre";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 121);
            label9.Name = "label9";
            label9.Size = new Size(154, 23);
            label9.TabIndex = 9;
            label9.Text = "Apellido Paterno";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(452, 25);
            label8.Name = "label8";
            label8.Size = new Size(158, 23);
            label8.TabIndex = 8;
            label8.Text = "Apellido Materno";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(452, 124);
            label7.Name = "label7";
            label7.Size = new Size(71, 23);
            label7.TabIndex = 7;
            label7.Text = "Correo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(450, 72);
            label6.Name = "label6";
            label6.Size = new Size(86, 23);
            label6.TabIndex = 6;
            label6.Text = "Télefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(830, 87);
            label5.Name = "label5";
            label5.Size = new Size(89, 23);
            label5.TabIndex = 5;
            label5.Text = "Empresa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(880, 29);
            label4.Name = "label4";
            label4.Size = new Size(71, 23);
            label4.TabIndex = 4;
            label4.Text = "Puesto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 191);
            label3.Name = "label3";
            label3.Size = new Size(71, 23);
            label3.TabIndex = 3;
            label3.Text = "Buscar";
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(16, 14);
            ID.Name = "ID";
            ID.Size = new Size(30, 23);
            ID.TabIndex = 0;
            ID.Text = "ID";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmAlumno
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 661);
            Controls.Add(panel1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmAlumno";
            Text = "FrmAlumno";
            Load += FrmAlumno_Load;
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(panel1, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label ID;
        private TextBox txtID;
        private TextBox txtNombre;
        private TextBox txtApellidoPaterno;
        private TextBox txtApellidoMaterno;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtEmpresa;
        private TextBox txtPuesto;
        private TextBox txtBuscar;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private DataGridView dgvAlumnos;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}