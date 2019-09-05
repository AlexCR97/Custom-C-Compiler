using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    class Semantico
    {
        private readonly ArbolSintaxis arbol;

        public Semantico(ArbolSintaxis arbol)
        {
            this.arbol = arbol;
        }

        public TablaSimbolos GenerarTablaSimbolos()
        {
            var tabla = new TablaSimbolos();
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NT_DECLARACION_VARAIBLE);

            nodos.ForEach(nodo =>
            {
                List<Simbolo> simbolos = CrearSimbolos(nodo);
                tabla.AgregarSimbolos(simbolos);
            });

            return tabla;
        }

        private List<Simbolo> CrearSimbolos(ParseTreeNode nodo)
        {
            var simbolos = new List<Simbolo>();

            List<ParseTreeNode> tipos = arbol.Recorrer(nodo, Gramatica.NT_TIPO);
            List<ParseTreeNode> ids = arbol.Recorrer(nodo, Gramatica.R_ID);
            List<ParseTreeNode> asignables = arbol.Recorrer(nodo, Gramatica.NT_ASIGNABLE);

            Console.WriteLine("Nodos encontrados desde raiz " + nodo.ToString());

            Console.WriteLine("Tipos:");
            tipos.ForEach(n => Console.Write(n.ToString() + " | "));
            Console.WriteLine('\n');

            Console.WriteLine("Ids:");
            ids.ForEach(n => Console.Write(n.ToString() + " | "));
            Console.WriteLine('\n');

            //Console.WriteLine("Asignables:");
            //asignables.ForEach(n => Console.Write(n.ToString() + " | "));
            //Console.WriteLine('\n');

            // Crear simbolos
            ids.ForEach(nodoId =>
            {
                string tipo = tipos[0].FindTokenAndGetText();
                string id = nodoId.FindTokenAndGetText();
                string valor = null;

                Console.WriteLine("Creando simbolo desde nodo '" + nodoId.ToString() + "' con datos:");
                Console.WriteLine("Tipo = " + tipo);
                Console.WriteLine("Id = " + id);
                Console.WriteLine("Valor = " + valor);
                Console.WriteLine();

                simbolos.Add(new Simbolo(tipo, id, valor));
            });

            return simbolos;
        }
    }
}
