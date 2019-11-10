using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorCantidadParametros : ErrorNeo
    {
        public ErrorCantidadParametros(string nombreFuncion, int cantidadEsperada, int cantidadProporcionada) :
            base($"Cantidad incorrecta de parametros. La funcion {nombreFuncion} solo puede tomar {cantidadEsperada} argumentos. " +
                $"Se proporcionaron {cantidadProporcionada} argumentos.") { }
    }
}
