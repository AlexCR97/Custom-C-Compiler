using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloSalida : UserControl
    {
        public const int SalidaError = 1;
        public const int SalidaNormal = 2;
        public const int SalidaExito = 3;

        public VentanaPrincipal App { get; set; }

        private string entrada;

        public ModuloSalida()
        {
            InitializeComponent();

            richTextBoxSalida.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var rtb = sender as RichTextBox;
                    string[] tokens = rtb.Text.Split(' ');
                    string ultimoToken = tokens[tokens.Length - 1];

                    entrada = ultimoToken;
                }
            };
        }

        public void Enfocar()
        {
            richTextBoxSalida.ReadOnly = false;
            richTextBoxSalida.Focus();
        }

        public void Desenfocar()
        {
            richTextBoxSalida.ReadOnly = true;
        }

        public async Task<int> EntradaInt()
        {
            Enfocar();

            int entrada = -1;

            Desenfocar();

            return entrada;
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
