namespace GenerarDiplomas
{
    partial class FrmSede
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
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            dgvSedes = new DataGridView();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            txtBuscar = new TextBox();
            label8 = new Label();
            txtReferencia = new TextBox();
            label7 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            txtCiudad = new TextBox();
            label4 = new Label();
            txtEstado = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            txtNombreSede = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSedes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(1235, 644);
            btnSalir.Margin = new Padding(6, 3, 6, 3);
            btnSalir.Size = new Size(177, 40);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(dgvSedes);
            panel1.Controls.Add(rbInactivo);
            panel1.Controls.Add(rbActivo);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtReferencia);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtDireccion);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtCiudad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtEstado);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNombreSede);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 23);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1469, 687);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(1012, 632);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(838, 621);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(669, 632);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(516, 631);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvSedes
            // 
            dgvSedes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSedes.Location = new Point(25, 268);
            dgvSedes.Name = "dgvSedes";
            dgvSedes.RowHeadersWidth = 51;
            dgvSedes.Size = new Size(1406, 332);
            dgvSedes.TabIndex = 18;
            dgvSedes.CellDoubleClick += dgvSedes_CellDoubleClick;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(1085, 82);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(98, 27);
            rbInactivo.TabIndex = 17;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(1022, 35);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 27);
            rbActivo.TabIndex = 16;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(987, 217);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(182, 30);
            txtBuscar.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(876, 217);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(71, 23);
            label8.TabIndex = 14;
            label8.Text = "Buscar";
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(630, 179);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(182, 30);
            txtReferencia.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(519, 179);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(105, 23);
            label7.TabIndex = 12;
            label7.Text = "Referencia";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(669, 86);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(182, 30);
            txtTelefono.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(558, 86);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(84, 23);
            label6.TabIndex = 10;
            label6.Text = "Telefono";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(208, 160);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(182, 30);
            txtDireccion.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 163);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 23);
            label5.TabIndex = 8;
            label5.Text = "Direccion";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(141, 224);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(182, 30);
            txtCiudad.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 224);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 23);
            label4.TabIndex = 6;
            label4.Text = "Ciudad";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(669, 25);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(182, 30);
            txtEstado.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(558, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 4;
            label3.Text = "Estado";
            // 
            // txtNombreSede
            // 
            txtNombreSede.Location = new Point(286, 83);
            txtNombreSede.Name = "txtNombreSede";
            txtNombreSede.Size = new Size(182, 30);
            txtNombreSede.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 89);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(180, 23);
            label2.TabIndex = 2;
            label2.Text = "Nombre de la Sede";
            // 
            // txtID
            // 
            txtID.Location = new Point(123, 18);
            txtID.Name = "txtID";
            txtID.Size = new Size(182, 30);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 25);
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
            // FrmSede
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1623, 709);
            Controls.Add(panel1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmSede";
            Text = "FrmSede";
            Load += FrmSede_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSedes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ErrorProvider errorProvider1;
        private TextBox txtNombreSede;
        private Label label2;
        private TextBox txtID;
        private TextBox txtDireccion;
        private Label label5;
        private TextBox txtCiudad;
        private Label label4;
        private TextBox txtEstado;
        private Label label3;
        private TextBox txtBuscar;
        private Label label8;
        private TextBox txtReferencia;
        private Label label7;
        private TextBox txtTelefono;
        private Label label6;
        private DataGridView dgvSedes;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnCancelar;
        private Button btnEditar;
    }
}