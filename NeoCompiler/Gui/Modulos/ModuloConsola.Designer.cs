namespace NeoCompiler.Gui.Modulos
{
    partial class ModuloConsola
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
            this.consola = new ConsoleControl.ConsoleControl();
            this.panelTitle.SuspendLayout();
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
            this.panelTitle.Size = new System.Drawing.Size(600, 28);
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
            this.labelTitle.Size = new System.Drawing.Size(47, 17);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Salida";
            // 
            // consola
            // 
            this.consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consola.ForeColor = System.Drawing.Color.White;
            this.consola.IsInputEnabled = true;
            this.consola.Location = new System.Drawing.Point(0, 28);
            this.consola.Name = "consola";
            this.consola.SendKeyboardCommandsToProcess = false;
            this.consola.ShowDiagnostics = false;
            this.consola.Size = new System.Drawing.Size(600, 175);
            this.consola.TabIndex = 4;
            // 
            // ModuloConsola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.consola);
            this.Controls.Add(this.panelTitle);
            this.Name = "ModuloConsola";
            this.Size = new System.Drawing.Size(600, 203);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private ConsoleControl.ConsoleControl consola;
    }
}
