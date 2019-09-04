namespace NeoCompiler.Gui.Controls
{
    partial class SourceCodeControl
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
            this.textBoxLines = new System.Windows.Forms.TextBox();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxLines
            // 
            this.textBoxLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLines.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxLines.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxLines.Location = new System.Drawing.Point(0, 0);
            this.textBoxLines.Multiline = true;
            this.textBoxLines.Name = "textBoxLines";
            this.textBoxLines.Size = new System.Drawing.Size(40, 400);
            this.textBoxLines.TabIndex = 1;
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.BackColor = System.Drawing.Color.LightGray;
            this.richTextBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCode.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCode.Location = new System.Drawing.Point(40, 0);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(360, 400);
            this.richTextBoxCode.TabIndex = 3;
            this.richTextBoxCode.Text = "";
            // 
            // SourceCodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxCode);
            this.Controls.Add(this.textBoxLines);
            this.Name = "SourceCodeControl";
            this.Size = new System.Drawing.Size(400, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLines;
        private System.Windows.Forms.RichTextBox richTextBoxCode;
    }
}
