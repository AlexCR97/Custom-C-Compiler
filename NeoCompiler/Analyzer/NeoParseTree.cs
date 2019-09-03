using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irony.Ast;
using Irony.Parsing;

namespace NeoCompiler.Analyzer
{
    class NeoParseTree
    {
        private readonly ParseTree parseTree;

        public NeoParseTree(ParseTree parseTree)
        {
            this.parseTree = parseTree;
        }

        public List<ParseTreeNode> Traverse()
        {
            var nodes = new List<ParseTreeNode>();
            Traverse(parseTree.Root, nodes);
            return nodes;
        }

        private void Traverse(ParseTreeNode root, List<ParseTreeNode> nodes)
        {
            nodes.Add(root);
            foreach (var node in root.ChildNodes)
            {
                Traverse(node, nodes);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            Traverse().ForEach(node =>
            {
                sb.Append(node.ToString()).Append("\n");
            });

            return sb.ToString();
        }
    }
}
