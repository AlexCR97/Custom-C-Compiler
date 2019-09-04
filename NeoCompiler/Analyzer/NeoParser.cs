using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace NeoCompiler.Analyzer
{
    class NeoParser
    {
        public ParseTree Parse(string input)
        {
            var grammar = new NeoGrammar2();
            var parser = new Parser(grammar);

            return parser.Parse(input);
        }
    }
}
