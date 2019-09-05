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
            this.tabPageLexico = new System.Windows.Forms.TabPage();
            this.tabPageSintactico = new System.Windows.Forms.TabPage();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tabPageSemantico = new System.Windows.Forms.TabPage();
            this.panelTitle.SuspendLayout();
            this.tabControlAnalizadores.SuspendLayout();
            this.panelContainer.SuspendLayout();
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
            this.tabControlAnalizadores.Controls.Add(this.tabPageLexico);
            this.tabControlAnalizadores.Controls.Add(this.tabPageSintactico);
            this.tabControlAnalizadores.Controls.Add(this.tabPageSemantico);
            this.tabControlAnalizadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAnalizadores.Location = new System.Drawing.Point(6, 6);
            this.tabControlAnalizadores.Name = "tabControlAnalizadores";
            this.tabControlAnalizadores.SelectedIndex = 0;
            this.tabControlAnalizadores.Size = new System.Drawing.Size(488, 553);
            this.tabControlAnalizadores.TabIndex = 5;
            // 
            // tabPageLexico
            // 
            this.tabPageLexico.Location = new System.Drawing.Point(4, 25);
            this.tabPageLexico.Name = "tabPageLexico";
            this.tabPageLexico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLexico.Size = new System.Drawing.Size(480, 524);
            this.tabPageLexico.TabIndex = 0;
            this.tabPageLexico.Text = "Lexico";
            this.tabPageLexico.UseVisualStyleBackColor = true;
            // 
            // tabPageSintactico
            // 
            this.tabPageSintactico.Location = new System.Drawing.Point(4, 25);
            this.tabPageSintactico.Name = "tabPageSintactico";
            this.tabPageSintactico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSintactico.Size = new System.Drawing.Size(480, 524);
            this.tabPageSintactico.TabIndex = 1;
            this.tabPageSintactico.Text = "Sintactico";
            this.tabPageSintactico.UseVisualStyleBackColor = true;
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
            // tabPageSemantico
            // 
            this.tabPageSemantico.Location = new System.Drawing.Point(4, 25);
            this.tabPageSemantico.Name = "tabPageSemantico";
            this.tabPageSemantico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSemantico.Size = new System.Drawing.Size(480, 524);
            this.tabPageSemantico.TabIndex = 2;
            this.tabPageSemantico.Text = "Semantico";
            this.tabPageSemantico.UseVisualStyleBackColor = true;
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
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControlAnalizadores;
        private System.Windows.Forms.TabPage tabPageLexico;
        private System.Windows.Forms.TabPage tabPageSintactico;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabPage tabPageSemantico;
    }
}
