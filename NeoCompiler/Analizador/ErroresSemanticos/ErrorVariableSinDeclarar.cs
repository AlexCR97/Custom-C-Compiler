using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableSinDeclarar : Exception
    {
        public ErrorVariableSinDeclarar(string identificador)
            : base($"No existe una variable '{identificador}' declarada") { }
    }
}
