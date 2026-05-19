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
            dgvPonentes = new DataGridView();
            txtApellidoMaterno = new TextBox();
            label12 = new Label();
            txtNombre = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtApellidoPaterno = new TextBox();
            txtBuscar = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPonentes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(1036, 413);
            btnSalir.Margin = new Padding(5, 2, 5, 2);
            btnSalir.Size = new Size(145, 31);
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
            panel1.Controls.Add(dgvPonentes);
            panel1.Controls.Add(txtApellidoMaterno);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtApellidoPaterno);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 11);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1361, 488);
            panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(1053, 330);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(77, 23);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1053, 230);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(77, 23);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(1053, 283);
            btnEditar.Margin = new Padding(2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(77, 23);
            btnEditar.TabIndex = 24;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(1058, 173);
            btnNuevo.Margin = new Padding(2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(77, 23);
            btnNuevo.TabIndex = 23;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(869, 146);
            rbInactivo.Margin = new Padding(2);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(78, 22);
            rbInactivo.TabIndex = 22;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(869, 109);
            rbActivo.Margin = new Padding(2);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(69, 22);
            rbActivo.TabIndex = 21;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // dgvPonentes
            // 
            dgvPonentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPonentes.Location = new Point(20, 191);
            dgvPonentes.Margin = new Padding(2);
            dgvPonentes.Name = "dgvPonentes";
            dgvPonentes.RowHeadersWidth = 51;
            dgvPonentes.Size = new Size(981, 272);
            dgvPonentes.TabIndex = 20;
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Location = new Point(407, 57);
            txtApellidoMaterno.Margin = new Padding(2);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(103, 26);
            txtApellidoMaterno.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(254, 59);
            label12.Name = "label12";
            label12.Size = new Size(126, 18);
            label12.TabIndex = 18;
            label12.Text = "Apellido Materno";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(98, 54);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(103, 26);
            txtNombre.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(20, 57);
            label10.Name = "label10";
            label10.Size = new Size(64, 18);
            label10.TabIndex = 18;
            label10.Text = "Nombre";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(259, 19);
            label11.Name = "label11";
            label11.Size = new Size(124, 18);
            label11.TabIndex = 16;
            label11.Text = "Apellido Paterno";
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Location = new Point(407, 13);
            txtApellidoPaterno.Margin = new Padding(2);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(103, 26);
            txtApellidoPaterno.TabIndex = 17;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(118, 146);
            txtBuscar.Margin = new Padding(2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(699, 26);
            txtBuscar.TabIndex = 3;
            // 
            // label2
            
            // 
            // txtID
            // 
            txtID.Location = new Point(66, 16);
            txtID.Margin = new Padding(2);
            txtID.Name = "txtID";
            txtID.Size = new Size(103, 26);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 16);
            label1.Name = "label1";
            label1.Size = new Size(23, 18);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmPonente
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 500);
            Controls.Add(panel1);
            Margin = new Padding(5, 2, 5, 2);
            Name = "FrmPonente";
            Text = "FrmPonente";
            Load += FrmPonente_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPonentes).EndInit();
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
        private TextBox txtBuscar;
        private Label label2;
        private TextBox txtID;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private DataGridView dgvPonentes;
        private Button btnCancelar;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnNuevo;
        private ErrorProvider errorProvider1;
    }
}