using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using NeoCompiler.Analyzer;

namespace NeoCompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Console.WriteLine("Reading file...");

            string input = readFile(@"C:\Users\carp_\Documents\neo\02.neo");

            Console.WriteLine("Input is: \n\n" + input + "\n");

            var parser = new NeoParser();

            ParseTree tree = parser.Parse(input);

            if (tree.Root == null)
            {
                Console.WriteLine("Parsing FAILED\n");
                return;
            }

            Console.WriteLine("Parsing SUCCESSFUL\n");

            var neoTree = new NeoParseTree(tree);
            var nodes = neoTree.Traverse();

            Console.WriteLine("Parse tree is:\n" + neoTree);
        }

        private string readFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
