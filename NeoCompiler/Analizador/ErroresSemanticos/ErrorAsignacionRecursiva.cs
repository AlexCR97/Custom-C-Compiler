using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorAsignacionRecursiva : Exception
    {
        public ErrorAsignacionRecursiva(string identificador)
            : base($"Asignacion recursiva de la variable '{identificador}'") { }
    }
}
