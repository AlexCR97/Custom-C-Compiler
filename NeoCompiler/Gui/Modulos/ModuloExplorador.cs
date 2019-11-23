using System.Windows.Forms;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloExplorador : UserControl
    {
        public VentanaPrincipal App { get; set; }

        public ModuloExplorador()
        {
            InitializeComponent();

            treeViewFiles.NodeMouseDoubleClick += (s, e) => SeleccionarPestana();
        }

        public void AgregarArchivo(string rutaArchivo)
        {
            treeViewFiles.Nodes.Add(rutaArchivo);
        }

        public void QuitarArchivo(string rutaArchivo)
        {
            int i = 0;

            foreach (TreeNode node in treeViewFiles.Nodes)
            {
                if (node.Text == rutaArchivo)
                {
                    break;
                }
                i++;
            }

            treeViewFiles.Nodes.RemoveAt(i);
        }

        private void SeleccionarPestana()
        {
            string nombrePestana = treeViewFiles.SelectedNode.Text;
            App.SeleccionarPestana(nombrePestana);
        }
    }
}
