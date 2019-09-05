using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace NeoCompiler.Analizador
{
    class Sintactico
    {
        public ParseTree Analizar(string entrada)
        {
            var gramatica = new Gramatica();
            var sintactico = new Parser(gramatica);

            return sintactico.Parse(entrada);
        }
    }
}
