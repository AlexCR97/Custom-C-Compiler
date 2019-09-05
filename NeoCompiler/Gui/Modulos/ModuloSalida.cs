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
    public partial class ModuloSalida : UserControl
    {
        public const int SalidaError = 1;
        public const int SalidaNormal = 2;
        public const int SalidaExito = 3;

        private VentanaPrincipal app;
        public VentanaPrincipal App
        {
            get { return app; }
            set { app = value; }
        }

        public ModuloSalida()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            richTextBoxSalida.Clear();
        }

        public void Mostrar(string mensaje)
        {
            richTextBoxSalida.AppendText(mensaje);
        }

        public void Mostrar(string mensaje, int tipoSalida)
        {
            Color color;

            switch (tipoSalida)
            {
                case SalidaError: color = Color.Red; break;
                case SalidaNormal: color = Color.Black; break;
                case SalidaExito: color = Color.Green; break;
                default: color = Color.Black; break;
            }

            richTextBoxSalida.SelectionStart = richTextBoxSalida.TextLength;
            richTextBoxSalida.SelectionLength = 0;
            richTextBoxSalida.SelectionColor = color;

            richTextBoxSalida.AppendText(mensaje);
            richTextBoxSalida.SelectionColor = richTextBoxSalida.ForeColor;
        }
    }
}
