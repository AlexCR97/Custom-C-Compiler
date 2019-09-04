using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Modules
{
    public partial class OutputModule : UserControl
    {
        public const int DisplayError = 1;
        public const int DisplayNormal = 2;
        public const int DisplaySuccess = 3;

        private MainForm app;
        public MainForm App
        {
            get { return app; }
            set { app = value; }
        }

        public OutputModule()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            richTextBoxOutput.Clear();
        }

        public void Display(string message)
        {
            richTextBoxOutput.AppendText(message);
        }

        public void Display(string message, int displayType)
        {
            Color color;

            switch (displayType)
            {
                case DisplayError: color = Color.Red; break;
                case DisplayNormal: color = Color.Black; break;
                case DisplaySuccess: color = Color.Green; break;
                default: color = Color.Black; break;
            }

            richTextBoxOutput.SelectionStart = richTextBoxOutput.TextLength;
            richTextBoxOutput.SelectionLength = 0;
            richTextBoxOutput.SelectionColor = color;

            richTextBoxOutput.AppendText(message);
            richTextBoxOutput.SelectionColor = richTextBoxOutput.ForeColor;
        }
    }
}
