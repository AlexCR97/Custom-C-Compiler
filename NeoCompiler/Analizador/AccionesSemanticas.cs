using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    class AccionesSemanticas
    {
        public static object Inicio(ArbolSintaxis arbol, ParseTreeNode raiz)
        {
            Console.WriteLine("Executing semantic action Start from root: " + raiz.ToString());
            return null;
        }

        public static TablaSimbolos DeclaracionVariable(ArbolSintaxis arbol, ParseTreeNode raiz)
        {
            Console.WriteLine("Executing semantic action VarDeclaration from root: " + raiz.ToString());
            return null;
        }
    }
}
