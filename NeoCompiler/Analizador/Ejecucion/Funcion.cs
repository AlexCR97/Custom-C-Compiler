using NeoCompiler.Gui.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public abstract class Funcion : Instruccion
    {
        public string Identificador { get; }
        public List<object> Parametros { get; }

        public Funcion(string identificador, List<object> parametros, TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida) :
            base(tablaSimbolos, moduloSalida)
        {
            this.Identificador = identificador;
            this.Parametros = parametros;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Identificador).Append("(");

            for (int i = 0; i < Parametros.Count; i++)
            {
                object param = Parametros[i];

                sb.Append(param);

                if (i != Parametros.Count - 1)
                    sb.Append(", ");
            }

            sb.Append(")");

            return sb.ToString();
        }
    }
}
