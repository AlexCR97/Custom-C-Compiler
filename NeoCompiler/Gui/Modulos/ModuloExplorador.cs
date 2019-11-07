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
