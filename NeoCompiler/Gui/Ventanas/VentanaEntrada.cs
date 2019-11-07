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
    public partial class VentanaEntrada : Form
    {
        private string entrada;

        public VentanaEntrada()
        {
            InitializeComponent();

            buttonIngresar.Click += (e, s) =>
            {
                entrada = textBoxEntrada.Text;
            };
        }

        public string LeerEntrada()
        {
            return entrada;
        }
    }
}
