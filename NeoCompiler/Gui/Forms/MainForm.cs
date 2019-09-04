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
using NeoCompiler.Gui.Modules;

namespace NeoCompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            analisisModule.App = this;
            explorerModule.App = this;
            outputModule.App = this;
            sourceCodeModule.App = this;
        }

        private void foo()
        {
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

        private string openFilePath()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Neo Files (*.neo)|*.neo",
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private string readFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private string saveFilePath()
        {
            var dialog = new SaveFileDialog()
            {
                FileName = "main.neo",
                Filter = "Neo files (*.neo) | *.neo",
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private void writeFile(string filePath, string content)
        {
            using (var writer = new StreamWriter(filePath, false))
            {
                writer.Write(content);
            }
        }

        // New File
        private void toolStripButtonNewFile_Click(object sender, EventArgs e)
        {
            string filePath = saveFilePath();

            if (filePath == null)
                return;

            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("");
            }

            sourceCodeModule.AddTab(filePath, readFile(filePath));
        }

        // Open File
        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            string filePath = openFilePath();

            if (filePath == null)
                return;

            string fileContent = readFile(filePath);

            sourceCodeModule.AddTab(filePath, fileContent);
        }

        // Save File
        private void toolStripButtonSaveFile_Click(object sender, EventArgs e)
        {
            string selectedTabName = sourceCodeModule.SelectedTabName();

            if (selectedTabName == null)
                return;

            string selectedTabContent = sourceCodeModule.SelectedSourceCodeContent();

            writeFile(selectedTabName, selectedTabContent);

            MessageBox.Show("File saved!");
        }

        // Compile
        private void toolStripButtonCompile_Click(object sender, EventArgs e)
        {
            string input = sourceCodeModule.SelectedSourceCodeContent();
            var parser = new NeoParser();
            ParseTree tree = parser.Parse(input);

            outputModule.Display("Performing analysis...\n");

            if (tree.Root == null)
            {
                outputModule.Display("Parsing FAILED :(\n", OutputModule.DisplayError);
                return;
            }

            outputModule.Display("Parsing SUCCEEDED :D\n", OutputModule.DisplaySuccess);
        }
    }
}
