using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorComparacionImposible : Exception
    {
        public ErrorComparacionImposible(string id1, string tipo1, string id2, string tipo2)
            : base($"No es posible comparar el tipo '{tipo1}' ('{id1}') con el tipo '{tipo2}' ('{id2}')") { }
    }
}
