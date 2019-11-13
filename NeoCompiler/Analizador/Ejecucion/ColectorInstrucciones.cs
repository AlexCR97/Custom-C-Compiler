using Irony.Parsing;
using NeoCompiler.Gui.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public class ColectorInstrucciones
    {
        private readonly ArbolSintaxis arbol;
        private readonly TablaSimbolos tablaSimbolos;
        private readonly ModuloSalida moduloSalida;

        public ColectorInstrucciones(ArbolSintaxis arbol, TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida)
        {
            this.arbol = arbol;
            this.tablaSimbolos = tablaSimbolos;
            this.moduloSalida = moduloSalida;
        }

        /// <summary>
        /// Obtiene las instrucciones del arbol de sintaxis, listas para ser ejecutadas
        /// </summary>
        /// <returns></returns>
        public List<Instruccion> ObtenerInstrucciones()
        {
            var instrucciones = new List<Instruccion>();
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.Instruccion);

            var tokensInstruccionesPrint = new List<List<ParseTreeNode>>();

            nodos.ForEach(nodo =>
            {
                List<ParseTreeNode> tokens = arbol.HojasDe(nodo);

                // Si el ultimo token es un punto y coma, entonces se trata de una funcion
                if (tokens[tokens.Count - 1].FindTokenAndGetText().Equals(Gramatica.Terminales.PuntoComa))
                {
                    FuncionPrint funcion = ProcesarFuncionPrint(tokens);
                    instrucciones.Add(funcion);
                }

                // Si el ultimo token NO ES PUNTO Y COMA, se trata de un controlador de flujo
                else
                {
                    ControladorFlujo controlador = ProcesarControladorFlujo(tokens);
                    instrucciones.Add(controlador);
                }
            });

            return instrucciones;
        }

        private FuncionPrint ProcesarFuncionPrint(List<ParseTreeNode> tokens)
        {
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
             */

            string identificadorFuncion = tokens[0].FindTokenAndGetText();

            var parametros = new List<object>();
            var sb = new StringBuilder();

            for (int i = 2; i < tokens.Count - 2; i++)
                sb.Append($"{tokens[i].FindTokenAndGetText()} ");

            parametros.Add(sb.ToString().TrimEnd());

            return new FuncionPrint(identificadorFuncion, parametros, tablaSimbolos, moduloSalida);
        }

        private ControladorFlujo ProcesarControladorFlujo(List<ParseTreeNode> tokens)
        {
            /**
             * O tambien pueden tener el formato de un controlador de flujo
             * 
             * if ( a > b ) { }
             * 0  1 2 3 4 5 6 7
             * 
             * if ( a > b ) { } else { }
             * 0  1 2 3 4 5 6 7 8    9 10
             * 
             * if ( a > b ) { } else if ( a > b ) { } ... else { }
             * 
             * while (a > b) { }
             */

            string identificadorControlador = tokens[0].FindTokenAndGetText();

            if (identificadorControlador.Equals(Gramatica.Terminales.If))
            {
                // if
                var parametros = new List<object>();
                var sb = new StringBuilder();

                int i = 2;
                string token = tokens[i].FindTokenAndGetText();
                while (token != Gramatica.Terminales.ParentesisCerrar)
                {
                    sb.Append($"{token} ");

                    i++;
                    token = tokens[i].FindTokenAndGetText();
                }

                parametros.Add(sb.ToString().Trim());

                return new ControladorFlujoIf(new List<Instruccion>(), identificadorControlador, parametros, tablaSimbolos, moduloSalida);
            }

            return null;
        }
    }
}
