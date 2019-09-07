using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableYaDeclarada : Exception
    {
        public ErrorVariableYaDeclarada(string identificador)
            : base($"Ya existe una variable declarada con el identificador '{identificador}'") { }
    }
}
