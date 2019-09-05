using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloExplorador : UserControl
    {
        private VentanaPrincipal app;
        public VentanaPrincipal App
        {
            get { return app; }
            set { app = value; }
        }

        public ModuloExplorador()
        {
            InitializeComponent();
        }
    }
}
