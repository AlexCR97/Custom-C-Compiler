using NeoCompiler.Gui.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public abstract class Instruccion
    {
        internal readonly TablaSimbolos tablaSimbolos;
        internal readonly ModuloSalida moduloSalida;

        public Instruccion(TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida)
        {
            this.tablaSimbolos = tablaSimbolos;
            this.moduloSalida = moduloSalida;
        }

        public abstract object Ejecutar();
    }
}
