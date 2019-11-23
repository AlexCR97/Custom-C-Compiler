using Irony.Parsing;
using NeoCompiler.Analizador.CodigoIntermedio;
using NeoCompiler.Analizador.ErroresSemanticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var listaAsignables = new List<List<ParseTreeNode>>();

            asignaciones.ForEach(node =>
            {
                List<ParseTreeNode> hojas = arbol.HojasDe(node);
                listaAsignables.Add(hojas);
            });

            // Crear simbolos
            for (int i = 0; i < ids.Count; i++)
            {
                string tipo = tipos[0].FindTokenAndGetText();
                string id = ids[i].FindTokenAndGetText();

                Console.WriteLine("==========================================================================================");
                Console.WriteLine("Tipo actual es: " + tipo);
                Console.WriteLine("Id actual es: " + id);

                if (listaAsignables.Count == 0)
                {
                    Console.WriteLine("Lista asignables esta vacia");
                    simbolos.Add(new Simbolo(tipo, id));
                }
                else
                {
                    Console.WriteLine("Lista asignables count: " + listaAsignables.Count);

                    var sb = new StringBuilder();

                    listaAsignables[i].ForEach(token =>
                    {
                        Console.Write(token + " ");
                        sb.Append($"{token.FindTokenAndGetText()} ");
                    });

                    Console.WriteLine();
                    Console.WriteLine("==========================================================================================");

                    string asignable = sb.ToString().Trim();
                    string asignableNormalizado = ConvertidorNotacion.NormalizarExpresion(asignable);

                    Console.WriteLine($"asignable = {asignable}");
                    Console.WriteLine($"normalizado = {asignableNormalizado}");

                    // si el asignable es un string, no tenemos que normalizarlo
                    if (asignable[0] == '"' || asignable[asignable.Length - 1] == '"')
                    {
                        simbolos.Add(new Simbolo(tipo, id, asignable));
                    }
                    // si no es un string, entonces lo normalizamos
                    else
                    {
                        simbolos.Add(new Simbolo(tipo, id, asignableNormalizado));
                    }
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
                if (Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.IdRegex) && !Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                {
                    // Primero, checamos si el identificador existe
                    if (!tabla.ContieneSimbolo(valor))
                    {
                        // Si el identificador no existe

                        // pero es un float, omitimos
                        if (valor[valor.Length - 1] == 'f')
                        {
                            continue;
                        }

                        // pero es una expresion, omitimos
                        if (valor[0] == '(' && valor[valor.Length - 1] == ')')
                        {
                            continue;
                        }

                        // pero es un bool, omitimos
                        else if (
                            valor == Gramatica.Terminales.True ||
                            valor == Gramatica.Terminales.False)
                        {
                            continue;
                        }

                        // pero es una lectura, omitimos
                        else if (
                            valor == Gramatica.Terminales.InputInt ||
                            valor == Gramatica.Terminales.InputFloat ||
                            valor == Gramatica.Terminales.InputDouble ||
                            valor == Gramatica.Terminales.InputBool ||
                            valor == Gramatica.Terminales.InputString)
                        {
                            continue;
                        }

                        // pero no es ninguno de los anteriores, aventamos un error
                        else
                        {
                            Console.WriteLine($"Error en clase {this.GetType().Name}: valor = {valor}");
                            throw new ErrorVariableSinDeclarar(valor);
                        }
                    }
                    else
                    {
                        // Si el identificador si existe, tenemos que obtener el valor de dicho id para comprobar su tipo
                        valor = ValorDe(tabla, valor);
                    }
                }

                switch (tipo)
                {
                    case Gramatica.Terminales.Int:
                    {
                        if (!Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Int);

                        if (valor.Contains('.'))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Int);

                        break;
                    }

                    case Gramatica.Terminales.Float:
                    {
                        if (!Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                            throw new ErrorTipoIncorrento(simbolo.Identificador, Gramatica.Terminales.Float);

                        break;
                    }

                    case Gramatica.Terminales.Double:
                    {
                        if (!Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
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
                        if (!Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
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
                {
                    throw new ErrorVariableSinDeclarar(asignableIzquierdo);
                }

                if (!tabla.ContieneSimbolo(asignableDerecho))
                {
                    throw new ErrorVariableSinDeclarar(asignableDerecho);
                }

                Console.WriteLine($"izq = {asignableIzquierdo}\nder = {asignableDerecho}\n");

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

        private string TipoDe(TablaSimbolos tabla, string id)
        {
            Console.WriteLine("/ = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = /");
            Console.WriteLine($"Checando tipo del id '{id}'");

            // checamos si es una lectura
            if (id[0] == '@')
            {
                if (id == Gramatica.Terminales.InputBool)
                    return Gramatica.Terminales.Bool;

                if (id == Gramatica.Terminales.InputInt)
                    return Gramatica.Terminales.Int;

                if (id == Gramatica.Terminales.InputFloat)
                    return Gramatica.Terminales.Float;

                if (id == Gramatica.Terminales.InputDouble)
                    return Gramatica.Terminales.Double;

                if (id == Gramatica.Terminales.InputString)
                    return Gramatica.Terminales.String;
            }

            Simbolo simbolo = tabla.BuscarSimbolo(id);

            Console.WriteLine($"El valor del id actual '{id}' es '{simbolo.Valor}'");

            if (id.Equals(simbolo.Valor))
                throw new ErrorDeclaracionRecursiva(id);

            if (Utils.ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex) && !Utils.ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.StringRegex))
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

            // checamos si es una lectura
            if (simbolo.Valor[0] == '@')
                return simbolo.Valor;

            if (id.Equals(simbolo.Valor))
                throw new ErrorDeclaracionRecursiva(id);

            if (simbolo.Valor == null)
                throw new ErrorVariableSinInicializar(simbolo.Identificador);

            if (Utils.ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.IdRegex) && !Utils.ValidarRegex(simbolo.Valor, Gramatica.ExpresionesRegulares.StringRegex))
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
    }
}
