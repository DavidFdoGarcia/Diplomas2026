namespace GenerarDiplomas
{
    partial class FrmGenerarDiploma
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCurso = new ComboBox();
            btnGenerar = new Button();
            label1 = new Label();
            btnCargar = new Button();
            dgvDiplomas = new DataGridView();
            btnGenerarTodos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDiplomas).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(30, 144, 255);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(867, 583);
            btnSalir.Margin = new Padding(6, 3, 6, 3);
            btnSalir.Size = new Size(177, 40);
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(220, 20);
            cmbCurso.Margin = new Padding(4, 5, 4, 5);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(276, 31);
            cmbCurso.TabIndex = 0;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(641, -12);
            btnGenerar.Margin = new Padding(4, 5, 4, 5);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(93, 63);
            btnGenerar.TabIndex = 1;
            btnGenerar.Text = "Generar Diploma";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 23);
            label1.TabIndex = 3;
            label1.Text = "Nombre del Curso";
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(796, -12);
            btnCargar.Margin = new Padding(4, 5, 4, 5);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(93, 63);
            btnCargar.TabIndex = 4;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // dgvDiplomas
            // 
            dgvDiplomas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiplomas.Location = new Point(21, 73);
            dgvDiplomas.Name = "dgvDiplomas";
            dgvDiplomas.RowHeadersWidth = 51;
            dgvDiplomas.Size = new Size(1110, 485);
            dgvDiplomas.TabIndex = 5;
            // 
            // btnGenerarTodos
            // 
            btnGenerarTodos.Location = new Point(942, 2);
            btnGenerarTodos.Margin = new Padding(4, 5, 4, 5);
            btnGenerarTodos.Name = "btnGenerarTodos";
            btnGenerarTodos.Size = new Size(93, 63);
            btnGenerarTodos.TabIndex = 6;
            btnGenerarTodos.Text = "Generar Todos";
            btnGenerarTodos.UseVisualStyleBackColor = true;
            btnGenerarTodos.Click += btnGenerarTodos_Click;
            // 
            // FrmGenerarDiploma
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 659);
            Controls.Add(btnGenerarTodos);
            Controls.Add(dgvDiplomas);
            Controls.Add(btnCargar);
            Controls.Add(label1);
            Controls.Add(btnGenerar);
            Controls.Add(cmbCurso);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmGenerarDiploma";
            Text = "Form1";
            Load += FrmGenerarDiploma_Load;
            Controls.SetChildIndex(cmbCurso, 0);
            Controls.SetChildIndex(btnGenerar, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnSalir, 0);
            Controls.SetChildIndex(btnCargar, 0);
            Controls.SetChildIndex(dgvDiplomas, 0);
            Controls.SetChildIndex(btnGenerarTodos, 0);
            ((System.ComponentModel.ISupportInitialize)dgvDiplomas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCurso;
        private Button btnGenerar;
        private Label label1;
        private Button btnCargar;
        private DataGridView dgvDiplomas;
        private Button btnGenerarTodos;
    }
}
