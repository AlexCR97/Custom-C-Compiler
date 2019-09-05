using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Controles
{
    public partial class ControlCodigo : UserControl
    {
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
    }
}
