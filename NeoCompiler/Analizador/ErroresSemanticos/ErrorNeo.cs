using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorNeo : Exception
    {
        public ErrorNeo(string mensaje) : base(mensaje) { }
    }
}
