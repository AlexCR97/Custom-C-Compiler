using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    class PruebasAccionesSemanticas
    {
        private delegate void AccionSemantica(ArbolSintaxis arbol, ParseTreeNode raiz);
        private Dictionary<string, AccionSemantica> acciones;

        private readonly ArbolSintaxis arbol;

        public PruebasAccionesSemanticas(ArbolSintaxis arbol)
        {
            this.arbol = arbol;
        }

        private void InicializarAccionesSemanticas()
        {
            acciones[Gramatica.NoTerminales.Inicio] = new AccionSemantica(AccionSemanticaInicio);
        }

        private void AccionSemanticaInicio(ArbolSintaxis arbol, ParseTreeNode raiz)
        {
            Console.WriteLine("Esta es la accion semantica de ");
        }
    }
}
