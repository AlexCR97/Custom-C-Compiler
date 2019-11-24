namespace NeoCompiler.Gui.Modulos
{
    partial class ModuloExplorador
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
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(375, 28);
            this.panelTitle.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(2, 6);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(76, 17);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Explorador";
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.BackColor = System.Drawing.Color.Silver;
            this.treeViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFiles.Location = new System.Drawing.Point(0, 28);
            this.treeViewFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(375, 460);
            this.treeViewFiles.TabIndex = 3;
            // 
            // ModuloExplorador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.treeViewFiles);
            this.Controls.Add(this.panelTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModuloExplorador";
            this.Size = new System.Drawing.Size(375, 488);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TreeView treeViewFiles;
    }
}
