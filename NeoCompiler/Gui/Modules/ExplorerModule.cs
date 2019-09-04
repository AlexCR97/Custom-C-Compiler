using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Modules
{
    public partial class ExplorerModule : UserControl
    {
        private MainForm app;
        public MainForm App
        {
            get { return app; }
            set { app = value; }
        }

        public ExplorerModule()
        {
            InitializeComponent();
        }
    }
}
