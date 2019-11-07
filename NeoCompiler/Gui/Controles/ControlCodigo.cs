using System;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Controles
{
    public partial class ControlCodigo : UserControl
    {
        public int CantidadLineas
        {
            get { return richTextBoxCodigo.Lines.Length; }
        }

        public string CodigoFuente
        {
            get { return richTextBoxCodigo.Text; }
            set {
                richTextBoxCodigo.Text = value;
            }
        }

        public ControlCodigo()
        {
            InitializeComponent();

            richTextBoxCodigo.AcceptsTab = true;
            richTextBoxCodigo.SelectAll();
            richTextBoxCodigo.SelectionTabs = new int[] { 100, 200, 300, 400 };
        }

        private void richTextBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            textBoxLineas.Clear();
            int cantidadLineas = richTextBoxCodigo.Lines.Length;

            for (int i = 1; i <= cantidadLineas; i++)
                textBoxLineas.AppendText(i.ToString() + '\n');
        }
    }
}
