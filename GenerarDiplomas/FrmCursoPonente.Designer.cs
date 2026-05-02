namespace GenerarDiplomas
{
    partial class FrmCursoPonente
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
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            dgvCursoPonente = new DataGridView();
            cmbPonente = new ComboBox();
            cmbCurso = new ComboBox();
            txtRolPonente = new TextBox();
            txtBuscar = new TextBox();
            txtOrdenFirma = new TextBox();
            txtID = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursoPonente).BeginInit();
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
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(dgvCursoPonente);
            panel1.Controls.Add(cmbPonente);
            panel1.Controls.Add(cmbCurso);
            panel1.Controls.Add(txtRolPonente);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(txtOrdenFirma);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1518, 699);
            panel1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(203, 602);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(343, 602);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += button3_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(474, 602);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(606, 602);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvCursoPonente
            // 
            dgvCursoPonente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursoPonente.Location = new Point(3, 151);
            dgvCursoPonente.Name = "dgvCursoPonente";
            dgvCursoPonente.RowHeadersWidth = 51;
            dgvCursoPonente.Size = new Size(1183, 376);
            dgvCursoPonente.TabIndex = 15;
            dgvCursoPonente.CellDoubleClick += dgvCursoPonente_CellDoubleClick;
            // 
            // cmbPonente
            // 
            cmbPonente.FormattingEnabled = true;
            cmbPonente.Location = new Point(803, 59);
            cmbPonente.Name = "cmbPonente";
            cmbPonente.Size = new Size(151, 31);
            cmbPonente.TabIndex = 14;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(794, 6);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(151, 31);
            cmbCurso.TabIndex = 13;
            // 
            // txtRolPonente
            // 
            txtRolPonente.Location = new Point(161, 59);
            txtRolPonente.Name = "txtRolPonente";
            txtRolPonente.Size = new Size(125, 30);
            txtRolPonente.TabIndex = 12;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(128, 104);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(826, 30);
            txtBuscar.TabIndex = 11;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // txtOrdenFirma
            // 
            txtOrdenFirma.Location = new Point(521, 6);
            txtOrdenFirma.Name = "txtOrdenFirma";
            txtOrdenFirma.Size = new Size(125, 30);
            txtOrdenFirma.TabIndex = 10;
            // 
            // txtID
            // 
            txtID.Location = new Point(80, 17);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 30);
            txtID.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 59);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(117, 23);
            label7.TabIndex = 6;
            label7.Text = "Rol Ponente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(343, 9);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(149, 23);
            label6.TabIndex = 5;
            label6.Text = "Orden de Firma";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(699, 9);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 23);
            label5.TabIndex = 4;
            label5.Text = "Curso";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 104);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 23);
            label4.TabIndex = 3;
            label4.Text = "Buscar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(699, 59);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 23);
            label3.TabIndex = 2;
            label3.Text = "Ponente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 20);
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
            // FrmCursoPonente
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 704);
            Controls.Add(panel1);
            Margin = new Padding(6, 3, 6, 3);
            Name = "FrmCursoPonente";
            Text = "FrmCursoPonente";
            Load += FrmCursoPonente_Load;
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursoPonente).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvCursoPonente;
        private ComboBox cmbPonente;
        private ComboBox cmbCurso;
        private TextBox txtRolPonente;
        private TextBox txtBuscar;
        private TextBox txtOrdenFirma;
        private TextBox txtID;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}