using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableSinInicializar : ErrorNeo
    {
        public ErrorVariableSinInicializar(string identificador)
            : base($"La variable '{identificador}' no ha sido inicializada") { }
    }
}
