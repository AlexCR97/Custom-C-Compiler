namespace NeoCompiler.Gui.Controles
{
    partial class ControlCodigo
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
            this.textBoxLineas = new System.Windows.Forms.TextBox();
            this.richTextBoxCodigo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxLineas
            // 
            this.textBoxLineas.BackColor = System.Drawing.Color.SteelBlue;
            this.textBoxLineas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLineas.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxLineas.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLineas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxLineas.Location = new System.Drawing.Point(0, 0);
            this.textBoxLineas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLineas.Multiline = true;
            this.textBoxLineas.Name = "textBoxLineas";
            this.textBoxLineas.ReadOnly = true;
            this.textBoxLineas.Size = new System.Drawing.Size(30, 325);
            this.textBoxLineas.TabIndex = 1;
            this.textBoxLineas.WordWrap = false;
            // 
            // richTextBoxCodigo
            // 
            this.richTextBoxCodigo.BackColor = System.Drawing.Color.LightGray;
            this.richTextBoxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCodigo.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCodigo.Location = new System.Drawing.Point(30, 0);
            this.richTextBoxCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxCodigo.Name = "richTextBoxCodigo";
            this.richTextBoxCodigo.Size = new System.Drawing.Size(270, 325);
            this.richTextBoxCodigo.TabIndex = 3;
            this.richTextBoxCodigo.Text = "";
            this.richTextBoxCodigo.WordWrap = false;
            this.richTextBoxCodigo.TextChanged += new System.EventHandler(this.richTextBoxCodigo_TextChanged);
            // 
            // ControlCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxCodigo);
            this.Controls.Add(this.textBoxLineas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlCodigo";
            this.Size = new System.Drawing.Size(300, 325);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLineas;
        private System.Windows.Forms.RichTextBox richTextBoxCodigo;
    }
}
