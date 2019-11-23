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
    public partial class ModuloConsola : UserControl
    {
        public ModuloConsola()
        {
            InitializeComponent();

            consola.OnConsoleOutput += (s, e) => ManejarProceso();
        }

        public void IniciarProceso(string archivo)
        {
            consola.StartProcess(archivo, null);
        }

        private void ManejarProceso()
        {
            if (consola.IsProcessRunning)
                return;

            // el proceso ha terminado
            consola.WriteOutput("Programa terminado\n", Color.Green);
        }
    }
}
