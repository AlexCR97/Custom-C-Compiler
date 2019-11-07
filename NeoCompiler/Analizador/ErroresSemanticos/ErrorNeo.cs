using System;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorNeo : Exception
    {
        public ErrorNeo(string mensaje) : base(mensaje) { }
    }
}
