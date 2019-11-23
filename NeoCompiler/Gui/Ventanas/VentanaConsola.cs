using NeoCompiler.Analizador.Ejecutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Ventanas
{
    public partial class VentanaConsola : Form
    {
        public VentanaConsola()
        {
            InitializeComponent();

            
        }

        public void IniciarProceso(string archivo)
        {
            ShowDialog();
            consola.StartProcess(archivo, "");
        }
    }
}
