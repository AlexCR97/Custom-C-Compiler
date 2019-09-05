namespace NeoCompiler.Gui.Modulos
{
    partial class ModuloCodigo
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
            this.tabControlPestanas = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabControlArchivos
            // 
            this.tabControlPestanas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPestanas.Location = new System.Drawing.Point(6, 6);
            this.tabControlPestanas.Name = "tabControlArchivos";
            this.tabControlPestanas.SelectedIndex = 0;
            this.tabControlPestanas.Size = new System.Drawing.Size(488, 588);
            this.tabControlPestanas.TabIndex = 0;
            // 
            // ModuloCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tabControlPestanas);
            this.Name = "ModuloCodigo";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlPestanas;
    }
}
