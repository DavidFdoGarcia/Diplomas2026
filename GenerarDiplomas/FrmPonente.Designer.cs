namespace GenerarDiplomas
{
    partial class FrmPonente
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
            btnCancelar = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            dgvPonente = new DataGridView();
            txtApellidoMaterno = new TextBox();
            label12 = new Label();
            txtNombre = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtApellidoPaterno = new TextBox();
            label9 = new Label();
            txtProfesion = new TextBox();
            txtTelefono = new TextBox();
            label7 = new Label();
            txtEspecialidades = new TextBox();
            label6 = new Label();
            txtCorreo = new TextBox();
            label5 = new Label();
            txtInstitucion = new TextBox();
            label4 = new Label();
            txtFirma = new TextBox();
            label3 = new Label();
            txtBuscar = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPonente).BeginInit();
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
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(rbInactivo);
            panel1.Controls.Add(rbActivo);
            panel1.Controls.Add(dgvPonente);
            panel1.Controls.Add(txtApellidoMaterno);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtApellidoPaterno);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtProfesion);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtEspecialidades);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtCorreo);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtInstitucion);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtFirma);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(16, 14);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1664, 623);
            panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(1287, 422);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1287, 294);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(1287, 362);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 24;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(1293, 221);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 23;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(1062, 187);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(98, 27);
            rbInactivo.TabIndex = 22;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(1062, 139);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 27);
            rbActivo.TabIndex = 21;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // dgvPonente
            // 
            dgvPonente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPonente.Location = new Point(24, 244);
            dgvPonente.Name = "dgvPonente";
            dgvPonente.RowHeadersWidth = 51;
            dgvPonente.Size = new Size(1199, 347);
            dgvPonente.TabIndex = 20;
            dgvPonente.CellDoubleClick += dgvPonente_CellDoubleClick;
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Location = new Point(498, 73);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(125, 30);
            txtApellidoMaterno.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(311, 76);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(158, 23);
            label12.TabIndex = 18;
            label12.Text = "Apellido Materno";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 69);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 30);
            txtNombre.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(24, 73);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(79, 23);
            label10.TabIndex = 18;
            label10.Text = "Nombre";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(316, 24);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(154, 23);
            label11.TabIndex = 16;
            label11.Text = "Apellido Paterno";
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Location = new Point(498, 17);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(125, 30);
            txtApellidoPaterno.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(960, 69);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(93, 23);
            label9.TabIndex = 16;
            label9.Text = "Profesión";
            // 
            // txtProfesion
            // 
            txtProfesion.Location = new Point(1127, 66);
            txtProfesion.Name = "txtProfesion";
            txtProfesion.Size = new Size(125, 30);
            txtProfesion.TabIndex = 15;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(760, 17);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 30);
            txtTelefono.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(667, 17);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(86, 23);
            label7.TabIndex = 12;
            label7.Text = "Télefono";
            // 
            // txtEspecialidades
            // 
            txtEspecialidades.Location = new Point(1098, 17);
            txtEspecialidades.Name = "txtEspecialidades";
            txtEspecialidades.Size = new Size(125, 30);
            txtEspecialidades.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(944, 20);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(121, 23);
            label6.TabIndex = 10;
            label6.Text = "Especialidad";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(746, 76);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(125, 30);
            txtCorreo.TabIndex = 9;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(669, 82);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(71, 23);
            label5.TabIndex = 8;
            label5.Text = "Correo";
            // 
            // txtInstitucion
            // 
            txtInstitucion.Location = new Point(157, 129);
            txtInstitucion.Name = "txtInstitucion";
            txtInstitucion.Size = new Size(125, 30);
            txtInstitucion.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 129);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(97, 23);
            label4.TabIndex = 6;
            label4.Text = "Institución";
            // 
            // txtFirma
            // 
            txtFirma.Location = new Point(498, 136);
            txtFirma.Name = "txtFirma";
            txtFirma.Size = new Size(125, 30);
            txtFirma.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 136);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 23);
            label3.TabIndex = 4;
            label3.Text = "Firma Ruta";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(144, 187);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(854, 30);
            txtBuscar.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 194);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 23);
            label2.TabIndex = 2;
            label2.Text = "Buscar";
            label2.Click += label2_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(81, 20);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 23);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmPonente
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1697, 639);
            Controls.Add(panel1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmPonente";
            Text = "FrmPonente";
            Load += FrmPonente_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPonente).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtApellidoMaterno;
        private Label label12;
        private TextBox txtNombre;
        private Label label10;
        private Label label11;
        private TextBox txtApellidoPaterno;
        private Label label9;
        private TextBox txtProfesion;
        private TextBox txtTelefono;
        private Label label7;
        private TextBox txtEspecialidades;
        private Label label6;
        private TextBox txtCorreo;
        private Label label5;
        private TextBox txtInstitucion;
        private Label label4;
        private TextBox txtFirma;
        private Label label3;
        private TextBox txtBuscar;
        private Label label2;
        private TextBox txtID;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private DataGridView dgvPonente;
        private Button btnCancelar;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnNuevo;
        private ErrorProvider errorProvider1;
    }
}