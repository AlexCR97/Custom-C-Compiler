using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCompiler.Gui.Controls;

namespace NeoCompiler.Gui.Modules
{
    public partial class SourceCodeModule : UserControl
    {
        private MainForm app;
        public MainForm App
        {
            get { return app; }
            set { app = value; }
        }

        public SourceCodeModule()
        {
            InitializeComponent();
        }

        public void AddTab(string tabName)
        {
            var sourceCodeControl = new SourceCodeControl()
            {
                Dock = DockStyle.Fill,
            };

            var newPage = new TabPage(tabName);
            newPage.Controls.Add(sourceCodeControl);

            tabControl.TabPages.Add(newPage);
            tabControl.SelectedIndex = tabControl.TabCount - 1;
        }

        public void AddTab(string tabName, string content)
        {
            var sourceCodeControl = new SourceCodeControl()
            {
                Dock = DockStyle.Fill,
                SourceCode = content,
            };

            var newPage = new TabPage(tabName);
            newPage.Controls.Add(sourceCodeControl);

            tabControl.TabPages.Add(newPage);
            tabControl.SelectedIndex = tabControl.TabCount - 1;
        }

        public string SelectedTabName()
        {
            if (tabControl.TabCount == 0)
                return null;

            return tabControl.SelectedTab.Text;
        }

        public SourceCodeControl SelectedSourceCodeControl()
        {
            TabPage selectedTab = tabControl.SelectedTab;
            var selectedSourceCode = selectedTab.Controls[0] as SourceCodeControl;
            return selectedSourceCode;
        }

        public string SelectedSourceCodeContent()
        {
            SourceCodeControl selectedSourceCode = SelectedSourceCodeControl();
            return selectedSourceCode.SourceCode;
        }
    }
}
