namespace NeoCompiler.Gui.Ventanas
{
    partial class VentanaCarga
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCargando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::NeoCompiler.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(492, 307);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelCargando
            // 
            this.labelCargando.AutoSize = true;
            this.labelCargando.BackColor = System.Drawing.Color.Transparent;
            this.labelCargando.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCargando.Location = new System.Drawing.Point(12, 320);
            this.labelCargando.Name = "labelCargando";
            this.labelCargando.Size = new System.Drawing.Size(104, 21);
            this.labelCargando.TabIndex = 1;
            this.labelCargando.Text = "Cargando...";
            this.labelCargando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VentanaCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = global::NeoCompiler.Properties.Resources.background_load;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.labelCargando);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VentanaCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentanaCarga";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCargando;
    }
}