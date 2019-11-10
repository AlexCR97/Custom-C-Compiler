using Irony.Parsing;
using NeoCompiler.Gui.Modulos;
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
        private readonly ModuloSalida moduloSalida;

        public ColectorFunciones(ArbolSintaxis arbol, TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida)
        {
            this.arbol = arbol;
            this.tablaSimbolos = tablaSimbolos;
            this.moduloSalida = moduloSalida;
        }

        public List<Instruccion> ObtenerInstrucciones()
        {
            var instrucciones = new List<Instruccion>();
            //List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.Print);
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.Instruccion);

            var tokensInstruccionesPrint = new List<List<ParseTreeNode>>();

            nodos.ForEach(nodo =>
            {
                List<ParseTreeNode> tokens = arbol.HojasDe(nodo);

                /**
                 * Los tokens obtenidos tienen el siguiente formato (el de una funcion):
                 * 
                 * print ( x ) ;
                 * 0     1 2 3 4
                 * 
                 * print ( 1 + 3 ) ;
                 * 0     1 2 3 4 5 6
                 * 
                 * Siendo 0 el identificador y los demas indices los parametros (a excepcion de '(', ')' y ';')
                 * 
                 * O tambien pueden tener el formato de un controlador de flujo
                 * 
                 * if (a > b) { }
                 * if (a > b) { } else { }
                 * if (a > b) { } else if (a > b) { } ... else { }
                 * 
                 * while (a > b) { }
                 */

                Console.WriteLine($"Las hojas obtenidas del nodo '{nodo.FindToken()}' son '{String.Join("|", tokens)}'");

                // Si el ultimo token es un punto y coma, entonces se trata de una funcion
                if (tokens[tokens.Count - 1].FindTokenAndGetText().Equals(Gramatica.Terminales.PuntoComa))
                {
                    string identificadorFuncion = tokens[0].FindTokenAndGetText();

                    var parametros = new List<object>();
                    var sb = new StringBuilder();

                    for (int i = 2; i < tokens.Count - 2; i++)
                        sb.Append($"{tokens[i].FindTokenAndGetText()} ");

                    parametros.Add(sb.ToString().TrimEnd());

                    instrucciones.Add(new FuncionPrint(identificadorFuncion, parametros, tablaSimbolos, moduloSalida));
                }
            });

            return instrucciones;
        }
    }
}
