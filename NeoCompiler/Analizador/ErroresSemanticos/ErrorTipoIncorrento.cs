using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorTipoIncorrento : Exception
    {
        public ErrorTipoIncorrento(string identificador, string tipoEsperado)
            : base($"La variable '{identificador}' debe ser de tipo '{tipoEsperado}'") { }
    }
}
