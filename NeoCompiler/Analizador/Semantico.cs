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

            // int x = 10, y = 20;
            // int foo;
            // string s = "";

            List<ParseTreeNode> tipos = arbol.Recorrer(nodo, Gramatica.NoTerminales.Tipo);
            List<ParseTreeNode> ids = arbol.Recorrer(nodo, Gramatica.ExpresionesRegulares.Id);
            List<ParseTreeNode> asignaciones = arbol.Recorrer(nodo, Gramatica.NoTerminales.Asignable);
            var asignacionesCola = new Queue<ParseTreeNode>(asignaciones);

            // Crear simbolos
            for (int i = 0; i < ids.Count; i++)
            {
                string tipo = tipos[0].FindTokenAndGetText();
                string id = ids[i].FindTokenAndGetText();

                if (asignacionesCola.Count == 0)
                    simbolos.Add(new Simbolo(tipo, id));

                else
                {
                    string asignable = asignacionesCola.Dequeue().FindTokenAndGetText();
                    simbolos.Add(new Simbolo(tipo, id, asignable));
                }
            }

            return simbolos;
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

        public bool ChecarTipos(TablaSimbolos tabla, int foo)
        {
            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                string tipo = simbolo.Tipo;
                string valor = simbolo.Valor;

                if (valor == null)
                    continue;

                // Si el valor del simbolo actual es un id
                if (ValidarRegex(valor, Gramatica.ExpresionesRegulares.IdRegex) && !ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                {
                    // Primero, checamos si el identificador existe
                    if (!tabla.ContieneSimbolo(valor))
                        throw new ErrorVariableSinDeclarar(valor);

                    // Despues, tenemos que obtener el valor de dicho id para comprobar su tipo
                    valor = ValorDe(tabla, valor);
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

        public bool ChecarExpresionesRelacionales(TablaSimbolos tabla)
        {
            List<ParseTreeNode> nodos = arbol.Recorrer(Gramatica.NoTerminales.ExpresionRelacional);

            foreach (ParseTreeNode nodo in nodos)
            {
                List<ParseTreeNode> asignables = arbol.Recorrer(nodo, Gramatica.ExpresionesRegulares.IdAsignable);
                List<ParseTreeNode> operadoresRelacionales = arbol.Recorrer(nodo, Gramatica.NoTerminales.OperadorRelacional);

                string asignableIzquierdo = asignables[0].FindTokenAndGetText();
                string asignableDerecho = asignables[1].FindTokenAndGetText();
                string operadorRelacional = operadoresRelacionales[0].FindTokenAndGetText();

                // Primero, checamos si los asignables existen
                if (!tabla.ContieneSimbolo(asignableIzquierdo))
                    throw new ErrorVariableSinDeclarar(asignableIzquierdo);

                if (!tabla.ContieneSimbolo(asignableDerecho))
                    throw new ErrorVariableSinDeclarar(asignableDerecho);

                // Despues, checamos si estan inicializados
                if (ValorDe(tabla, asignableIzquierdo) == null) return false;
                if (ValorDe(tabla, asignableDerecho) == null) return false;

                // Luego, checamos si se pueden comparar
                string tipo1 = TipoDe(tabla, asignableIzquierdo);
                string tipo2 = TipoDe(tabla, asignableDerecho);

                if (!EsComparable(tipo1, tipo2))
                    throw new ErrorComparacionImposible(asignableIzquierdo, tipo1, asignableDerecho, tipo2);
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
                throw new ErrorDeclaracionRecursiva(id);

            if (ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex) && !ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.StringRegex))
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

            if (id.Equals(simbolo.Valor))
                throw new ErrorDeclaracionRecursiva(id);

            if (simbolo.Valor == null)
                throw new ErrorVariableSinInicializar(simbolo.Identificador);

            if (ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex) && !ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.StringRegex))
            {
                Console.WriteLine("Recursando...");
                return ValorDe(tabla, simbolo.Valor);
            }

            Console.WriteLine($"Se encontro el tipo del id '{id}'. Tipo es '{simbolo.Tipo}'");
            return simbolo.Valor;
        }

        private bool EsComparable(string tipo1, string tipo2)
        {
            return
                // int float double
                (EsTipoNumero(tipo1) && EsTipoNumero(tipo2)) ||

                // bool bool
                (tipo1.Equals(Gramatica.Terminales.Bool) && tipo2.Equals(Gramatica.Terminales.Bool)) ||
                
                // string string
                (tipo1.Equals(Gramatica.Terminales.String) && tipo2.Equals(Gramatica.Terminales.String));
        }

        private bool EsTipoNumero(string tipo)
        {
            return
                tipo.Equals(Gramatica.Terminales.Int) ||
                tipo.Equals(Gramatica.Terminales.Float) ||
                tipo.Equals(Gramatica.Terminales.Double);
        }

        private List<List<string>> ObtenerExpresiones()
        {
            var expresiones = new List<List<string>>();

            List<ParseTreeNode> nodosExpresiones = arbol.Recorrer(Gramatica.NoTerminales.ExpresionAritmetica);

            foreach (var nodo in nodosExpresiones)
            {
                Console.WriteLine(nodo);
            }

            return expresiones;
        }
    }
}
