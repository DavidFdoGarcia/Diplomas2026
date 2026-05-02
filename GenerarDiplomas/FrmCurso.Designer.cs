namespace GenerarDiplomas
{
    partial class FrmCurso
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtBuscar = new TextBox();
            txtOrdenTema = new TextBox();
            cmbCurso = new ComboBox();
            cmbTema = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            dgvCursoTema = new DataGridView();
            btnNuevo = new Button();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCursoTema).BeginInit();
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
            label1.Location = new Point(25, 77);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 23);
            label1.TabIndex = 0;
            label1.Text = "Orden de Tema";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(30, 23);
            label2.TabIndex = 1;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 141);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 23);
            label3.TabIndex = 2;
            label3.Text = "Buscar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(437, 97);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 3;
            label4.Text = "Tema";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(437, 39);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 23);
            label5.TabIndex = 4;
            label5.Text = "Curso";
            // 
            // txtID
            // 
            txtID.Location = new Point(83, 20);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 5;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(144, 138);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(770, 30);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // txtOrdenTema
            // 
            txtOrdenTema.Location = new Point(204, 70);
            txtOrdenTema.Name = "txtOrdenTema";
            txtOrdenTema.Size = new Size(125, 30);
            txtOrdenTema.TabIndex = 7;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(525, 36);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(151, 31);
            cmbCurso.TabIndex = 8;
            // 
            // cmbTema
            // 
            cmbTema.FormattingEnabled = true;
            cmbTema.Location = new Point(525, 94);
            cmbTema.Name = "cmbTema";
            cmbTema.Size = new Size(151, 31);
            cmbTema.TabIndex = 9;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // dgvCursoTema
            // 
            dgvCursoTema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursoTema.Location = new Point(12, 189);
            dgvCursoTema.Name = "dgvCursoTema";
            dgvCursoTema.RowHeadersWidth = 51;
            dgvCursoTema.Size = new Size(1143, 362);
            dgvCursoTema.TabIndex = 10;
            dgvCursoTema.CellDoubleClick += dgvCursoTema_CellDoubleClick;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(483, 553);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(861, 557);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(725, 557);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(598, 553);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmCurso
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 598);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvCursoTema);
            Controls.Add(cmbTema);
            Controls.Add(cmbCurso);
            Controls.Add(txtOrdenTema);
            Controls.Add(txtBuscar);
            Controls.Add(txtID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmCurso";
            Text = "l";
            Load += FrmCurso_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(txtOrdenTema, 0);
            Controls.SetChildIndex(cmbCurso, 0);
            Controls.SetChildIndex(cmbTema, 0);
            Controls.SetChildIndex(dgvCursoTema, 0);
            Controls.SetChildIndex(btnNuevo, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(btnEditar, 0);
            Controls.SetChildIndex(btnGuardar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCursoTema).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private TextBox txtBuscar;
        private TextBox txtOrdenTema;
        private ComboBox cmbCurso;
        private ComboBox cmbTema;
        private ErrorProvider errorProvider1;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnNuevo;
        private DataGridView dgvCursoTema;
    }
}