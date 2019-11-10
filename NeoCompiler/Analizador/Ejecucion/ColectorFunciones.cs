using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public class ColectorFunciones
    {
        private readonly ArbolSintaxis arbol;
        private readonly TablaSimbolos tablaSimbolos;

        public ColectorFunciones(ArbolSintaxis arbol, TablaSimbolos tablaSimbolos)
        {
            this.arbol = arbol;
            this.tablaSimbolos = tablaSimbolos;
        }

        public List<FuncionPrint> FuncionesPrint()
        {
            var funciones = new List<FuncionPrint>();
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.Print);

            var tokensInstruccionesPrint = new List<List<ParseTreeNode>>();

            nodos.ForEach(nodo =>
            {
                List<ParseTreeNode> tokens = arbol.HojasDe(nodo);

                /**
                 * Los tokens obtenidos tienen el siguiente formato:
                 * 
                 * print ( x )
                 * 0     1 2 3
                 * 
                 * print ( 1 + 3 )
                 * 0     1 2 3 4 5
                 * 
                 * Siendo 0 el identificador y los demas los parametros
                 */

                string identificadorFuncion = tokens[0].FindTokenAndGetText();

                var parametros = new List<object>();
                var sb = new StringBuilder();

                for (int i = 2; i < tokens.Count - 1; i++)
                    sb.Append($"{tokens[i].FindTokenAndGetText()} ");

                parametros.Add(sb.ToString().TrimEnd());

                funciones.Add(new FuncionPrint(identificadorFuncion, parametros, tablaSimbolos));
            });

            return funciones;
        }
    }
}
