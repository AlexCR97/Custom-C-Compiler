namespace NeoCompiler
{
    partial class VentanaPrincipal
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanelDock = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.moduloSalida = new NeoCompiler.Gui.Modulos.ModuloSalida();
            this.moduloConsola1 = new NeoCompiler.Gui.Modulos.ModuloConsola();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.moduloExplorador = new NeoCompiler.Gui.Modulos.ModuloExplorador();
            this.moduloCodigo = new NeoCompiler.Gui.Modulos.ModuloCodigo();
            this.moduloAnalisis = new NeoCompiler.Gui.Modulos.ModuloAnalisis();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCloseFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCompile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompileAndRun = new System.Windows.Forms.ToolStripButton();
            this.panelContainer.SuspendLayout();
            this.tableLayoutPanelDock.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.tableLayoutPanelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tableLayoutPanelDock);
            this.panelContainer.Controls.Add(this.toolStrip1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1184, 761);
            this.panelContainer.TabIndex = 1;
            // 
            // tableLayoutPanelDock
            // 
            this.tableLayoutPanelDock.ColumnCount = 1;
            this.tableLayoutPanelDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDock.Controls.Add(this.tableLayoutPanelBottom, 0, 1);
            this.tableLayoutPanelDock.Controls.Add(this.tableLayoutPanelTop, 0, 0);
            this.tableLayoutPanelDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDock.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanelDock.Name = "tableLayoutPanelDock";
            this.tableLayoutPanelDock.RowCount = 2;
            this.tableLayoutPanelDock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanelDock.Size = new System.Drawing.Size(1184, 734);
            this.tableLayoutPanelDock.TabIndex = 7;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.ColumnCount = 2;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.Controls.Add(this.moduloSalida, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.moduloConsola1, 1, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 459);
            this.tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(1184, 275);
            this.tableLayoutPanelBottom.TabIndex = 6;
            // 
            // moduloSalida
            // 
            this.moduloSalida.App = null;
            this.moduloSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduloSalida.Location = new System.Drawing.Point(2, 2);
            this.moduloSalida.Margin = new System.Windows.Forms.Padding(2);
            this.moduloSalida.Name = "moduloSalida";
            this.moduloSalida.Size = new System.Drawing.Size(588, 271);
            this.moduloSalida.TabIndex = 1;
            // 
            // moduloConsola1
            // 
            this.moduloConsola1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduloConsola1.Location = new System.Drawing.Point(595, 3);
            this.moduloConsola1.Name = "moduloConsola1";
            this.moduloConsola1.Size = new System.Drawing.Size(586, 269);
            this.moduloConsola1.TabIndex = 5;
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanelTop.Controls.Add(this.moduloExplorador, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.moduloCodigo, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.moduloAnalisis, 2, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1178, 453);
            this.tableLayoutPanelTop.TabIndex = 7;
            // 
            // moduloExplorador
            // 
            this.moduloExplorador.App = null;
            this.moduloExplorador.BackColor = System.Drawing.Color.Silver;
            this.moduloExplorador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduloExplorador.Location = new System.Drawing.Point(2, 2);
            this.moduloExplorador.Margin = new System.Windows.Forms.Padding(2);
            this.moduloExplorador.Name = "moduloExplorador";
            this.moduloExplorador.Size = new System.Drawing.Size(296, 449);
            this.moduloExplorador.TabIndex = 2;
            // 
            // moduloCodigo
            // 
            this.moduloCodigo.App = null;
            this.moduloCodigo.BackColor = System.Drawing.Color.Silver;
            this.moduloCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduloCodigo.Location = new System.Drawing.Point(302, 2);
            this.moduloCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moduloCodigo.Name = "moduloCodigo";
            this.moduloCodigo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.moduloCodigo.Size = new System.Drawing.Size(474, 449);
            this.moduloCodigo.TabIndex = 4;
            // 
            // moduloAnalisis
            // 
            this.moduloAnalisis.App = null;
            this.moduloAnalisis.BackColor = System.Drawing.Color.Silver;
            this.moduloAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduloAnalisis.Location = new System.Drawing.Point(780, 2);
            this.moduloAnalisis.Margin = new System.Windows.Forms.Padding(2);
            this.moduloAnalisis.Name = "moduloAnalisis";
            this.moduloAnalisis.Size = new System.Drawing.Size(396, 449);
            this.moduloAnalisis.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewFile,
            this.toolStripButtonOpenFile,
            this.toolStripButtonSaveFile,
            this.toolStripButtonCloseFile,
            this.toolStripSeparator1,
            this.toolStripButtonCompile,
            this.toolStripButtonRun,
            this.toolStripButtonCompileAndRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNewFile
            // 
            this.toolStripButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewFile.Image = global::NeoCompiler.Properties.Resources.new_file;
            this.toolStripButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
            this.toolStripButtonNewFile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonNewFile.Text = "toolStripButton1";
            this.toolStripButtonNewFile.ToolTipText = "Nuevo archivo";
            this.toolStripButtonNewFile.Click += new System.EventHandler(this.toolStripButtonNewFile_Click);
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFile.Image = global::NeoCompiler.Properties.Resources.open_file;
            this.toolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonOpenFile.Text = "toolStripButton1";
            this.toolStripButtonOpenFile.ToolTipText = "Abrir archivo";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // toolStripButtonSaveFile
            // 
            this.toolStripButtonSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveFile.Image = global::NeoCompiler.Properties.Resources.save_all;
            this.toolStripButtonSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveFile.Name = "toolStripButtonSaveFile";
            this.toolStripButtonSaveFile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSaveFile.Text = "toolStripButton1";
            this.toolStripButtonSaveFile.ToolTipText = "Guardar archivo";
            this.toolStripButtonSaveFile.Click += new System.EventHandler(this.toolStripButtonSaveFile_Click);
            // 
            // toolStripButtonCloseFile
            // 
            this.toolStripButtonCloseFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCloseFile.Image = global::NeoCompiler.Properties.Resources.close;
            this.toolStripButtonCloseFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCloseFile.Name = "toolStripButtonCloseFile";
            this.toolStripButtonCloseFile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCloseFile.Text = "toolStripButton1";
            this.toolStripButtonCloseFile.ToolTipText = "Cerrar archivo";
            this.toolStripButtonCloseFile.Click += new System.EventHandler(this.toolStripButtonCloseFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonCompile
            // 
            this.toolStripButtonCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompile.Image = global::NeoCompiler.Properties.Resources.compile;
            this.toolStripButtonCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompile.Name = "toolStripButtonCompile";
            this.toolStripButtonCompile.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCompile.Text = "toolStripButton1";
            this.toolStripButtonCompile.ToolTipText = "Compilar";
            this.toolStripButtonCompile.Click += new System.EventHandler(this.toolStripButtonCompile_Click);
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRun.Image = global::NeoCompiler.Properties.Resources.run;
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRun.Text = "toolStripButton1";
            this.toolStripButtonRun.ToolTipText = "Ejecutar";
            this.toolStripButtonRun.Click += new System.EventHandler(this.toolStripButtonRun_Click);
            // 
            // toolStripButtonCompileAndRun
            // 
            this.toolStripButtonCompileAndRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompileAndRun.Image = global::NeoCompiler.Properties.Resources.compile_run;
            this.toolStripButtonCompileAndRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompileAndRun.Name = "toolStripButtonCompileAndRun";
            this.toolStripButtonCompileAndRun.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCompileAndRun.Text = "toolStripButton1";
            this.toolStripButtonCompileAndRun.ToolTipText = "Compilar y ejecutar";
            this.toolStripButtonCompileAndRun.Click += new System.EventHandler(this.toolStripButtonCompileAndRun_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panelContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VentanaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neo Compiler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.tableLayoutPanelDock.ResumeLayout(false);
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompile;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompileAndRun;
        private Gui.Modulos.ModuloCodigo moduloCodigo;
        private Gui.Modulos.ModuloAnalisis moduloAnalisis;
        private Gui.Modulos.ModuloExplorador moduloExplorador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private Gui.Modulos.ModuloSalida moduloSalida;
        private Gui.Modulos.ModuloConsola moduloConsola1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
    }
}

