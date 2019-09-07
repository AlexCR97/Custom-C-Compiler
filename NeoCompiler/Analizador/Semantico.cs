using Irony.Parsing;
using NeoCompiler.Analizador.ErroresSemanticos;
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
            List<ParseTreeNode> ids = arbol.Recorrer(nodo, Gramatica.ExpresionesRegulares.Id);
            List<ParseTreeNode> asignaciones = arbol.Recorrer(nodo, Gramatica.NoTerminales.Asignable);
            var asignacionesCola = new Queue<ParseTreeNode>(asignaciones);

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

                if (asignacionesCola.Count == 0)
                {
                    simbolos.Add(new Simbolo(tipo, id));
                }
                else
                {
                    string asignable = asignacionesCola.Dequeue().FindTokenAndGetText();
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

        public bool ChecarDuplicados(TablaSimbolos tabla, int foo)
        {
            var contadores = new Dictionary<string, int>();

            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                string id = simbolo.Identificador;

                if (!contadores.ContainsKey(id))
                    contadores[id] = 0;

                contadores[id] += 1;

                if (contadores[id] > 1)
                    throw new ErrorVariableYaDeclarada(id);
            }

            return true;
        }

        public bool ChecarTipos(TablaSimbolos tabla)
        {
            foreach (Simbolo simbolo in tabla.Simbolos)
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

        public bool ChecarTipos(TablaSimbolos tabla, int foo)
        {
            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                Console.WriteLine("owowowowowowowowowowowowowowowowowowo");
                Console.WriteLine("Comprobando el tipo del simbolo actual: " + simbolo);
                Console.WriteLine("owowowowowowowowowowowowowowowowowowo");

                string tipo = simbolo.Tipo;
                string valor = simbolo.Valor;

                if (valor == null)
                    continue;

                // Si el valor del simbolo actual es un id
                if (ValidarRegex(valor, Gramatica.ExpresionesRegulares.IdRegex) && !ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                {
                    // Primero, checamos si el identificador existe
                    if (!tabla.ContieneSimbolo(valor))
                    {
                        throw new ErrorVariableSinDeclarar(valor);
                    }

                    // Despues, tenemos que obtener el valor de dicho id para comprobar su tipo
                    Console.WriteLine($"Simbolo actual con id '{simbolo.Identificador}' tiene valor de id '{simbolo.Valor}'. Buscando valor del id...");
                    valor = ValorDe(tabla, valor);
                }
                else
                {
                    Console.WriteLine("Simbolo actual tiene un valor primitivo. Procediendo a comprobar tipo...");
                }

                switch (tipo)
                {
                    case Gramatica.Terminales.Int:
                    {
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Int);

                        if (valor.Contains('.'))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Int);

                        break;
                    }

                    case Gramatica.Terminales.Float:
                    {
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Float);

                        break;
                    }

                    case Gramatica.Terminales.Double:
                    {
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Double);

                        break;
                    }

                    case Gramatica.Terminales.Bool:
                    {
                        if (!valor.Equals(Gramatica.Terminales.True) || !valor.Equals(Gramatica.Terminales.False))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Bool);

                        break;
                    }

                    case Gramatica.Terminales.String:
                    {
                        if (!ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.String);

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

        private string TipoDe(TablaSimbolos tabla, string id)
        {
            Console.WriteLine("/ = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = /");
            Console.WriteLine($"Checando tipo del id '{id}'");

            Simbolo simbolo = tabla.BuscarSimbolo(id);

            Console.WriteLine($"El valor del id actual '{id}' es '{simbolo.Valor}'");

            if (id.Equals(simbolo.Valor))
                throw new ErrorAsignacionRecursiva(id);

            if (ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex))
            {
                Console.WriteLine("Recursando...");
                return TipoDe(tabla, simbolo.Valor);
            }

            Console.WriteLine($"Se encontro el tipo del id '{id}'. Tipo es '{simbolo.Tipo}'");
            return simbolo.Tipo;
        }

        private string ValorDe(TablaSimbolos tabla, string id)
        {
            Console.WriteLine("/ = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = /");
            Console.WriteLine($"Checando tipo del id '{id}'");

            Simbolo simbolo = tabla.BuscarSimbolo(id);

            Console.WriteLine($"El valor del id actual '{id}' es '{simbolo.Valor}'");

            if (simbolo.Valor == null)
            {
                throw new ErrorVariableSinInicializar(simbolo.Identificador);
            }

            if (ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex))
            {
                Console.WriteLine("Recursando...");
                return TipoDe(tabla, simbolo.Valor);
            }

            Console.WriteLine($"Se encontro el tipo del id '{id}'. Tipo es '{simbolo.Tipo}'");
            return simbolo.Valor;
        }
    }
}
