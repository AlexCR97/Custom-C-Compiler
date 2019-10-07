﻿namespace NeoCompiler.Gui.Modulos
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tabPageCodigoIntermedio = new System.Windows.Forms.TabPage();
            this.dataGridViewCodigoIntermedio = new System.Windows.Forms.DataGridView();
            this.CLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle.SuspendLayout();
            this.tabControlAnalizadores.SuspendLayout();
            this.tabPageTablaSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).BeginInit();
            this.tabPageTriplos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriplos)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.tabPageCodigoIntermedio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCodigoIntermedio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(500, 35);
            this.panelTitle.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTitle.Location = new System.Drawing.Point(3, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(68, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Analisis";
            // 
            // tabControlAnalizadores
            // 
            this.tabControlAnalizadores.Controls.Add(this.tabPageTablaSimbolos);
            this.tabControlAnalizadores.Controls.Add(this.tabPageTriplos);
            this.tabControlAnalizadores.Controls.Add(this.tabPageCodigoIntermedio);
            this.tabControlAnalizadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAnalizadores.Location = new System.Drawing.Point(6, 6);
            this.tabControlAnalizadores.Name = "tabControlAnalizadores";
            this.tabControlAnalizadores.SelectedIndex = 0;
            this.tabControlAnalizadores.Size = new System.Drawing.Size(488, 553);
            this.tabControlAnalizadores.TabIndex = 5;
            // 
            // tabPageTablaSimbolos
            // 
            this.tabPageTablaSimbolos.Controls.Add(this.dataGridViewSimbolos);
            this.tabPageTablaSimbolos.Location = new System.Drawing.Point(4, 25);
            this.tabPageTablaSimbolos.Name = "tabPageTablaSimbolos";
            this.tabPageTablaSimbolos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTablaSimbolos.Size = new System.Drawing.Size(480, 524);
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
            this.dataGridViewSimbolos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSimbolos.Name = "dataGridViewSimbolos";
            this.dataGridViewSimbolos.RowTemplate.Height = 24;
            this.dataGridViewSimbolos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSimbolos.Size = new System.Drawing.Size(474, 518);
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
            this.tabPageTriplos.Location = new System.Drawing.Point(4, 25);
            this.tabPageTriplos.Name = "tabPageTriplos";
            this.tabPageTriplos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTriplos.Size = new System.Drawing.Size(480, 524);
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
            this.dataGridViewTriplos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTriplos.Name = "dataGridViewTriplos";
            this.dataGridViewTriplos.RowTemplate.Height = 24;
            this.dataGridViewTriplos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTriplos.Size = new System.Drawing.Size(474, 518);
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
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tabControlAnalizadores);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 35);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(6);
            this.panelContainer.Size = new System.Drawing.Size(500, 565);
            this.panelContainer.TabIndex = 6;
            // 
            // tabPageCodigoIntermedio
            // 
            this.tabPageCodigoIntermedio.Controls.Add(this.dataGridViewCodigoIntermedio);
            this.tabPageCodigoIntermedio.Location = new System.Drawing.Point(4, 25);
            this.tabPageCodigoIntermedio.Name = "tabPageCodigoIntermedio";
            this.tabPageCodigoIntermedio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCodigoIntermedio.Size = new System.Drawing.Size(480, 524);
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
            this.dataGridViewCodigoIntermedio.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCodigoIntermedio.Name = "dataGridViewCodigoIntermedio";
            this.dataGridViewCodigoIntermedio.RowTemplate.Height = 24;
            this.dataGridViewCodigoIntermedio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCodigoIntermedio.Size = new System.Drawing.Size(474, 518);
            this.dataGridViewCodigoIntermedio.TabIndex = 1;
            // 
            // CLinea
            // 
            this.CLinea.HeaderText = "Linea";
            this.CLinea.Name = "CLinea";
            // 
            // ModuloAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTitle);
            this.Name = "ModuloAnalisis";
            this.Size = new System.Drawing.Size(500, 600);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tabControlAnalizadores.ResumeLayout(false);
            this.tabPageTablaSimbolos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).EndInit();
            this.tabPageTriplos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriplos)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.tabPageCodigoIntermedio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCodigoIntermedio)).EndInit();
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
    }
}
