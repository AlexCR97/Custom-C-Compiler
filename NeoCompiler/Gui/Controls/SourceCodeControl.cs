using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Controls
{
    public partial class SourceCodeControl : UserControl
    {
        public string SourceCode
        {
            get { return richTextBoxCode.Text; }
            set {
                richTextBoxCode.Text = value;
            }
        }

        public SourceCodeControl()
        {
            InitializeComponent();

            richTextBoxCode.AcceptsTab = true;
            richTextBoxCode.SelectAll();
            richTextBoxCode.SelectionTabs = new int[] { 100, 200, 300, 400 };
        }
    }
}
