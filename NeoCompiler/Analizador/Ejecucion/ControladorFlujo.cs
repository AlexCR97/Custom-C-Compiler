using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCompiler.Gui.Modulos;

namespace NeoCompiler.Analizador.Ejecucion
{
    public abstract class ControladorFlujo : Funcion
    {
        public List<Instruccion> Cuerpo { get; }

        public ControladorFlujo(List<Instruccion> cuerpo, string identificador, List<object> parametros, TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida) :
            base(identificador, parametros, tablaSimbolos, moduloSalida)
        {
            this.Cuerpo = cuerpo;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Identificador).Append(" (").Append(String.Join(" ", Parametros)).Append(") {\n");

            foreach (var instruccion in Cuerpo)
                sb.Append("    ").Append(instruccion.ToString()).Append('\n');

            sb.Append("}");

            return sb.ToString();
        }
    }
}
