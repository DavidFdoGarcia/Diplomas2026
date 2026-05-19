namespace GenerarDiplomas
{
    partial class FrmReconocimientoPonente
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
            label1 = new Label();
            cmbCurso = new ComboBox();
            btnCargar = new Button();
            dgvPonentes = new DataGridView();
            btnGenerarTodos = new Button();
            btnGenerar = new Button();
            cmbPonente = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtDuracion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPonentes).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(1518, 724);
            btnSalir.Margin = new Padding(4, 2, 4, 2);
            btnSalir.Size = new Size(106, 42);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 18);
            label1.TabIndex = 0;
            label1.Text = "Curso";
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(107, 20);
            cmbCurso.Margin = new Padding(4);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(154, 26);
            cmbCurso.TabIndex = 2;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(107, 98);
            btnCargar.Margin = new Padding(4);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(96, 28);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // dgvPonentes
            // 
            dgvPonentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPonentes.Location = new Point(28, 162);
            dgvPonentes.Margin = new Padding(4);
            dgvPonentes.Name = "dgvPonentes";
            dgvPonentes.Size = new Size(1628, 507);
            dgvPonentes.TabIndex = 4;
            // 
            // btnGenerarTodos
            // 
            btnGenerarTodos.Location = new Point(1357, 699);
            btnGenerarTodos.Name = "btnGenerarTodos";
            btnGenerarTodos.Size = new Size(86, 58);
            btnGenerarTodos.TabIndex = 5;
            btnGenerarTodos.Text = "Generar Todos";
            btnGenerarTodos.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(1150, 699);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(143, 56);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar Reconocimiento";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click_1;
            // 
            // cmbPonente
            // 
            cmbPonente.FormattingEnabled = true;
            cmbPonente.Location = new Point(475, 20);
            cmbPonente.Margin = new Padding(4);
            cmbPonente.Name = "cmbPonente";
            cmbPonente.Size = new Size(154, 26);
            cmbPonente.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(383, 30);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 18);
            label2.TabIndex = 7;
            label2.Text = "Ponente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(718, 30);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 18);
            label3.TabIndex = 9;
            label3.Text = "Duración";
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(824, 27);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(100, 26);
            txtDuracion.TabIndex = 10;
            // 
            // FrmReconocimientoPonente
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1787, 799);
            Controls.Add(txtDuracion);
            Controls.Add(label3);
            Controls.Add(cmbPonente);
            Controls.Add(label2);
            Controls.Add(btnGenerar);
            Controls.Add(btnGenerarTodos);
            Controls.Add(dgvPonentes);
            Controls.Add(btnCargar);
            Controls.Add(cmbCurso);
            Controls.Add(label1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "FrmReconocimientoPonente";
            Text = "FrmReconocimientoPonente";
            Load += FrmReconocimientoPonente_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(cmbCurso, 0);
            Controls.SetChildIndex(btnCargar, 0);
            Controls.SetChildIndex(dgvPonentes, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(btnGenerarTodos, 0);
            Controls.SetChildIndex(btnGenerar, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(cmbPonente, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(txtDuracion, 0);
            ((System.ComponentModel.ISupportInitialize)dgvPonentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCurso;
        private Button btnCargar;
        private DataGridView dgvPonentes;
        private Button btnGenerarTodos;
        private Button btnGenerar;
        private ComboBox cmbPonente;
        private Label label2;
        private Label label3;
        private TextBox txtDuracion;
    }
}