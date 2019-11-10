using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public abstract class Funcion
    {
        public string Identificador { get; }
        public List<object> Parametros { get; }

        public Funcion(string identificador, List<object> parametros)
        {
            this.Identificador = identificador;
            this.Parametros = parametros;
        }

        public abstract object Ejecutar();

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
