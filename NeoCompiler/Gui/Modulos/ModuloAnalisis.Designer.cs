namespace NeoCompiler.Gui.Modulos
{
    partial class ModuloAnalisis
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabControlAnalizadores = new System.Windows.Forms.TabControl();
            this.tabPageTablaSimbolos = new System.Windows.Forms.TabPage();
            this.dataGridViewSimbolos = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageTriplos = new System.Windows.Forms.TabPage();
            this.dataGridViewTriplos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COperador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COperando1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COperando2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCodigoIntermedio = new System.Windows.Forms.TabPage();
            this.dataGridViewCodigoIntermedio = new System.Windows.Forms.DataGridView();
            this.CLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageTablaResulta = new System.Windows.Forms.TabPage();
            this.dataGridViewTablaResuelta = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTitle.SuspendLayout();
            this.tabControlAnalizadores.SuspendLayout();
            this.tabPageTablaSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).BeginInit();
            this.tabPageTriplos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriplos)).BeginInit();
            this.tabPageCodigoIntermedio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCodigoIntermedio)).BeginInit();
            this.tabPageTablaResulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaResuelta)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(375, 28);
            this.panelTitle.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(2, 6);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(56, 17);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Analisis";
            // 
            // tabControlAnalizadores
            // 
            this.tabControlAnalizadores.Controls.Add(this.tabPageTablaSimbolos);
            this.tabControlAnalizadores.Controls.Add(this.tabPageTriplos);
            this.tabControlAnalizadores.Controls.Add(this.tabPageCodigoIntermedio);
            this.tabControlAnalizadores.Controls.Add(this.tabPageTablaResulta);
            this.tabControlAnalizadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAnalizadores.Location = new System.Drawing.Point(4, 5);
            this.tabControlAnalizadores.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlAnalizadores.Name = "tabControlAnalizadores";
            this.tabControlAnalizadores.SelectedIndex = 0;
            this.tabControlAnalizadores.Size = new System.Drawing.Size(367, 450);
            this.tabControlAnalizadores.TabIndex = 5;
            // 
            // tabPageTablaSimbolos
            // 
            this.tabPageTablaSimbolos.Controls.Add(this.dataGridViewSimbolos);
            this.tabPageTablaSimbolos.Location = new System.Drawing.Point(4, 22);
            this.tabPageTablaSimbolos.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTablaSimbolos.Name = "tabPageTablaSimbolos";
            this.tabPageTablaSimbolos.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageTablaSimbolos.Size = new System.Drawing.Size(359, 424);
            this.tabPageTablaSimbolos.TabIndex = 2;
            this.tabPageTablaSimbolos.Text = "Tabla de simbolos";
            this.tabPageTablaSimbolos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSimbolos
            // 
            this.dataGridViewSimbolos.AllowUserToAddRows = false;
            this.dataGridViewSimbolos.AllowUserToDeleteRows = false;
            this.dataGridViewSimbolos.AllowUserToResizeColumns = false;
            this.dataGridViewSimbolos.AllowUserToResizeRows = false;
            this.dataGridViewSimbolos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Identificador,
            this.Valor});
            this.dataGridViewSimbolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSimbolos.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewSimbolos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSimbolos.Name = "dataGridViewSimbolos";
            this.dataGridViewSimbolos.RowTemplate.Height = 24;
            this.dataGridViewSimbolos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSimbolos.Size = new System.Drawing.Size(355, 420);
            this.dataGridViewSimbolos.TabIndex = 0;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Identificador
            // 
            this.Identificador.HeaderText = "Identificador";
            this.Identificador.Name = "Identificador";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // tabPageTriplos
            // 
            this.tabPageTriplos.Controls.Add(this.dataGridViewTriplos);
            this.tabPageTriplos.Location = new System.Drawing.Point(4, 22);
            this.tabPageTriplos.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTriplos.Name = "tabPageTriplos";
            this.tabPageTriplos.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageTriplos.Size = new System.Drawing.Size(359, 424);
            this.tabPageTriplos.TabIndex = 3;
            this.tabPageTriplos.Text = "Triplos";
            this.tabPageTriplos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTriplos
            // 
            this.dataGridViewTriplos.AllowUserToAddRows = false;
            this.dataGridViewTriplos.AllowUserToDeleteRows = false;
            this.dataGridViewTriplos.AllowUserToResizeColumns = false;
            this.dataGridViewTriplos.AllowUserToResizeRows = false;
            this.dataGridViewTriplos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTriplos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTriplos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.COperador,
            this.COperando1,
            this.COperando2});
            this.dataGridViewTriplos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTriplos.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewTriplos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTriplos.Name = "dataGridViewTriplos";
            this.dataGridViewTriplos.RowTemplate.Height = 24;
            this.dataGridViewTriplos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTriplos.Size = new System.Drawing.Size(355, 420);
            this.dataGridViewTriplos.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // COperador
            // 
            this.COperador.HeaderText = "Operador";
            this.COperador.Name = "COperador";
            // 
            // COperando1
            // 
            this.COperando1.HeaderText = "Op. 1";
            this.COperando1.Name = "COperando1";
            // 
            // COperando2
            // 
            this.COperando2.HeaderText = "Op. 2";
            this.COperando2.Name = "COperando2";
            // 
            // tabPageCodigoIntermedio
            // 
            this.tabPageCodigoIntermedio.Controls.Add(this.dataGridViewCodigoIntermedio);
            this.tabPageCodigoIntermedio.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodigoIntermedio.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCodigoIntermedio.Name = "tabPageCodigoIntermedio";
            this.tabPageCodigoIntermedio.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageCodigoIntermedio.Size = new System.Drawing.Size(359, 424);
            this.tabPageCodigoIntermedio.TabIndex = 4;
            this.tabPageCodigoIntermedio.Text = "Codigo intermedio";
            this.tabPageCodigoIntermedio.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCodigoIntermedio
            // 
            this.dataGridViewCodigoIntermedio.AllowUserToAddRows = false;
            this.dataGridViewCodigoIntermedio.AllowUserToDeleteRows = false;
            this.dataGridViewCodigoIntermedio.AllowUserToResizeColumns = false;
            this.dataGridViewCodigoIntermedio.AllowUserToResizeRows = false;
            this.dataGridViewCodigoIntermedio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCodigoIntermedio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCodigoIntermedio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLinea});
            this.dataGridViewCodigoIntermedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCodigoIntermedio.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewCodigoIntermedio.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewCodigoIntermedio.Name = "dataGridViewCodigoIntermedio";
            this.dataGridViewCodigoIntermedio.RowTemplate.Height = 24;
            this.dataGridViewCodigoIntermedio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCodigoIntermedio.Size = new System.Drawing.Size(355, 420);
            this.dataGridViewCodigoIntermedio.TabIndex = 1;
            // 
            // CLinea
            // 
            this.CLinea.HeaderText = "Linea";
            this.CLinea.Name = "CLinea";
            // 
            // tabPageTablaResulta
            // 
            this.tabPageTablaResulta.Controls.Add(this.dataGridViewTablaResuelta);
            this.tabPageTablaResulta.Location = new System.Drawing.Point(4, 22);
            this.tabPageTablaResulta.Name = "tabPageTablaResulta";
            this.tabPageTablaResulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTablaResulta.Size = new System.Drawing.Size(359, 424);
            this.tabPageTablaResulta.TabIndex = 5;
            this.tabPageTablaResulta.Text = "Tabla resulta";
            this.tabPageTablaResulta.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTablaResuelta
            // 
            this.dataGridViewTablaResuelta.AllowUserToAddRows = false;
            this.dataGridViewTablaResuelta.AllowUserToDeleteRows = false;
            this.dataGridViewTablaResuelta.AllowUserToResizeColumns = false;
            this.dataGridViewTablaResuelta.AllowUserToResizeRows = false;
            this.dataGridViewTablaResuelta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTablaResuelta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTablaResuelta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewTablaResuelta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTablaResuelta.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTablaResuelta.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTablaResuelta.Name = "dataGridViewTablaResuelta";
            this.dataGridViewTablaResuelta.RowTemplate.Height = 24;
            this.dataGridViewTablaResuelta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTablaResuelta.Size = new System.Drawing.Size(353, 418);
            this.dataGridViewTablaResuelta.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Identificador";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tabControlAnalizadores);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 28);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContainer.Size = new System.Drawing.Size(375, 460);
            this.panelContainer.TabIndex = 6;
            // 
            // ModuloAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModuloAnalisis";
            this.Size = new System.Drawing.Size(375, 488);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tabControlAnalizadores.ResumeLayout(false);
            this.tabPageTablaSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).EndInit();
            this.tabPageTriplos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriplos)).EndInit();
            this.tabPageCodigoIntermedio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCodigoIntermedio)).EndInit();
            this.tabPageTablaResulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaResuelta)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControlAnalizadores;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabPage tabPageTablaSimbolos;
        private System.Windows.Forms.DataGridView dataGridViewSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.TabPage tabPageTriplos;
        private System.Windows.Forms.DataGridView dataGridViewTriplos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COperador;
        private System.Windows.Forms.DataGridViewTextBoxColumn COperando1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COperando2;
        private System.Windows.Forms.TabPage tabPageCodigoIntermedio;
        private System.Windows.Forms.DataGridView dataGridViewCodigoIntermedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLinea;
        private System.Windows.Forms.TabPage tabPageTablaResulta;
        private System.Windows.Forms.DataGridView dataGridViewTablaResuelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
