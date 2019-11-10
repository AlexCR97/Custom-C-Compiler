using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorCantidadParametros : ErrorNeo
    {
        public ErrorCantidadParametros(string nombreFuncion, int cantidadParametros) :
            base($"Cantidad incorrecta de parametros. La funcion {nombreFuncion} solo puede tomar {cantidadParametros} argumentos") { }
    }
}
