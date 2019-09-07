using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.DeclaracionVariable);

            foreach (ParseTreeNode nodo in nodos)
            {
                List<Simbolo> simbolos = CrearSimbolos(nodo);
                tabla.AgregarSimbolos(simbolos);
            }

            return tabla;
        }

        private List<Simbolo> CrearSimbolos(ParseTreeNode nodo)
        {
            var simbolos = new List<Simbolo>();

            List<ParseTreeNode> tipos = arbol.Recorrer(nodo, Gramatica.NoTerminales.Tipo);
            //List<ParseTreeNode> ids = arbol.Recorrer(nodo, Gramatica.R_ID);
            List<ParseTreeNode> ids = arbol.Recorrer(nodo, Gramatica.ExpresionesRegulares.Id);
            //List<ParseTreeNode> asignaciones = arbol.Recorrer(nodo, Gramatica.NT_ASIGNABLE);
            List<ParseTreeNode> asignaciones = arbol.Recorrer(nodo, Gramatica.NoTerminales.Asignable);

            Console.WriteLine("Nodos encontrados desde raiz " + nodo.ToString());

            Console.WriteLine("Tipos:");
            tipos.ForEach(n => Console.Write(n.FindTokenAndGetText() + " | "));
            Console.WriteLine('\n');

            Console.WriteLine("Ids:");
            ids.ForEach(n => Console.Write(n.FindTokenAndGetText() + " | "));
            Console.WriteLine('\n');

            Console.WriteLine("Asignables:");
            asignaciones.ForEach(n => Console.Write(n.FindTokenAndGetText() + " | "));
            Console.WriteLine('\n');

            // Crear simbolos
            for (int i = 0; i < ids.Count; i++)
            {
                string tipo = tipos[0].FindTokenAndGetText();
                string id = ids[i].FindTokenAndGetText();

                if (asignaciones.Count == 0)
                {
                    simbolos.Add(new Simbolo(tipo, id));
                }
                else
                {
                    string asignable = asignaciones[i].FindTokenAndGetText();
                    simbolos.Add(new Simbolo(tipo, id, asignable));
                }
            }

            return simbolos;
        }

        public bool ChecarDuplicados(TablaSimbolos tabla)
        {
            var contadores = new Dictionary<string, int>();

            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                string id = simbolo.Identificador;

                if (!contadores.ContainsKey(id))
                    contadores[id] = 0;

                contadores[id] += 1;

                if (contadores[id] > 1)
                    return false;
            }

            return true;
        }

        public bool ChecarTipos(TablaSimbolos tablas)
        {
            foreach (Simbolo simbolo in tablas.Simbolos)
            {
                string tipo = simbolo.Tipo;
                string valor = simbolo.Valor;

                if (valor == null)
                    continue;

                switch (tipo)
                {
                    //case Gramatica.T_TIPO_INT:
                    case Gramatica.Terminales.Int:
                    {
                        //if (!ValidarRegex(valor, Gramatica.RG_NUMBER))
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            return false;

                        if (valor.Contains('.'))
                            return false;

                        break;
                    }

                    //case Gramatica.T_TIPO_FLOAT:
                    //case Gramatica.T_TIPO_DOUBLE:
                    case Gramatica.Terminales.Float:
                    case Gramatica.Terminales.Double:
                    {
                        //if (!ValidarRegex(valor, Gramatica.RG_NUMBER))
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            return false;

                        break;
                    }

                    //case Gramatica.T_TIPO_BOOL:
                    case Gramatica.Terminales.Bool:
                    {
                        if (!valor.Equals(Gramatica.Terminales.True) || !valor.Equals(Gramatica.Terminales.False))
                            return false;

                        break;
                    }

                    //case Gramatica.T_TIPO_STRING:
                    case Gramatica.Terminales.String:
                    {
                        //if (!ValidarRegex(valor, Gramatica.RG_STRING))
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                            return false;

                        break;
                    }
                }
            }

            return true;
        }

        private bool ValidarRegex(string cadena, string regex)
        {
            Match validacion = Regex.Match(cadena, regex);
            return validacion.Success;
        }
    }
}
