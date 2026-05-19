namespace GenerarDiplomas
{
    partial class FrmTema
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
            txtIdtema = new TextBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtNombreTema = new TextBox();
            label3 = new Label();
            Status = new Label();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            btnNuevo = new Button();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            txtBuscar = new TextBox();
            label5 = new Label();
            dgvTemas = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTemas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(954, 455);
            btnSalir.Margin = new Padding(2, 2, 2, 2);
            btnSalir.Size = new Size(106, 27);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 18);
            label1.Name = "label1";
            label1.Size = new Size(23, 18);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // txtIdtema
            // 
            txtIdtema.Location = new Point(56, 16);
            txtIdtema.Margin = new Padding(2, 2, 2, 2);
            txtIdtema.Name = "txtIdtema";
            txtIdtema.Size = new Size(103, 26);
            txtIdtema.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(371, 4);
            txtDescripcion.Margin = new Padding(2, 2, 2, 2);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(385, 101);
            txtDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 7);
            label2.Name = "label2";
            label2.Size = new Size(87, 18);
            label2.TabIndex = 2;
            label2.Text = "Descipción";
            // 
            // txtNombreTema
            // 
            txtNombreTema.Location = new Point(87, 49);
            txtNombreTema.Margin = new Padding(2, 2, 2, 2);
            txtNombreTema.Name = "txtNombreTema";
            txtNombreTema.Size = new Size(103, 26);
            txtNombreTema.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 55);
            label3.Name = "label3";
            label3.Size = new Size(46, 18);
            label3.TabIndex = 4;
            label3.Text = "Tema";
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.Location = new Point(773, 16);
            Status.Name = "Status";
            Status.Size = new Size(52, 18);
            Status.TabIndex = 6;
            Status.Text = "Status";
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(885, 49);
            rbActivo.Margin = new Padding(2, 2, 2, 2);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(69, 22);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(773, 49);
            rbInactivo.Margin = new Padding(2, 2, 2, 2);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(78, 22);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            rbInactivo.CheckedChanged += rbInactivo_CheckedChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(857, 456);
            btnNuevo.Margin = new Padding(2, 2, 2, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(77, 23);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(577, 456);
            btnCancelar.Margin = new Padding(2, 2, 2, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(77, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(668, 458);
            btnEditar.Margin = new Padding(2, 2, 2, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(77, 23);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(760, 456);
            btnGuardar.Margin = new Padding(2, 2, 2, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(77, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(87, 109);
            txtBuscar.Margin = new Padding(2, 2, 2, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(952, 26);
            txtBuscar.TabIndex = 16;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 109);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 15;
            label5.Text = "Buscar";
            // 
            // dgvTemas
            // 
            dgvTemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemas.Location = new Point(11, 137);
            dgvTemas.Margin = new Padding(2, 2, 2, 2);
            dgvTemas.Name = "dgvTemas";
            dgvTemas.RowHeadersWidth = 51;
            dgvTemas.Size = new Size(1036, 315);
            dgvTemas.TabIndex = 17;
            dgvTemas.CellDoubleClick += dgvTemas_CellDoubleClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(1078, 112);
            btnBuscar.Margin = new Padding(2, 2, 2, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(77, 20);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // FrmTema
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 490);
            Controls.Add(btnBuscar);
            Controls.Add(dgvTemas);
            Controls.Add(txtBuscar);
            Controls.Add(label5);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNuevo);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(Status);
            Controls.Add(txtNombreTema);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtIdtema);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FrmTema";
            Text = "FrmTema";
            Load += FrmTema_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtIdtema, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(txtDescripcion, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(txtNombreTema, 0);
            Controls.SetChildIndex(Status, 0);
            Controls.SetChildIndex(rbActivo, 0);
            Controls.SetChildIndex(rbInactivo, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnEditar, 0);
            Controls.SetChildIndex(btnGuardar, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(dgvTemas, 0);
            Controls.SetChildIndex(btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)dgvTemas).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdtema;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtNombreTema;
        private Label label3;
        private Label Status;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private Button btnNuevo;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnGuardar;
        private TextBox txtBuscar;
        private Label label5;
        private DataGridView dgvTemas;
        private ErrorProvider errorProvider1;
        private Button btnBuscar;
    }
}