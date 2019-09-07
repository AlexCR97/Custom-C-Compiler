using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCompiler.Analizador;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloAnalisis : UserControl
    {
        private VentanaPrincipal app;
        public VentanaPrincipal App
        {
            get { return app; }
            set { app = value; }
        }

        public ModuloAnalisis()
        {
            InitializeComponent();
        }

        public void LlenarTablaSimbolos(TablaSimbolos tabla)
        {
            dataGridViewSimbolos.Rows.Clear();

            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                dataGridViewSimbolos.Rows.Add(simbolo.Tipo, simbolo.Identificador, simbolo.Valor);
            }
        }
    }
}
