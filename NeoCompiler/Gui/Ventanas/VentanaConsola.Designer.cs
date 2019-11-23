namespace NeoCompiler.Gui.Ventanas
{
    partial class VentanaConsola
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
            this.consola = new ConsoleControl.ConsoleControl();
            this.SuspendLayout();
            // 
            // consola
            // 
            this.consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consola.IsInputEnabled = true;
            this.consola.Location = new System.Drawing.Point(0, 0);
            this.consola.Name = "consola";
            this.consola.SendKeyboardCommandsToProcess = false;
            this.consola.ShowDiagnostics = false;
            this.consola.Size = new System.Drawing.Size(800, 450);
            this.consola.TabIndex = 0;
            // 
            // VentanaConsola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.consola);
            this.Name = "VentanaConsola";
            this.Text = "VentanaConsola";
            this.ResumeLayout(false);

        }

        #endregion

        private ConsoleControl.ConsoleControl consola;
    }
}