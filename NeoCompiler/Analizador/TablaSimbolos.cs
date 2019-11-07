using NeoCompiler.Analizador.CodigoIntermedio;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeoCompiler.Analizador
{
    public class TablaSimbolos
    {
        private List<Simbolo> simbolos = new List<Simbolo>();
        public List<Simbolo> Simbolos { get => simbolos; }

        public TablaSimbolos() {}

        public void AgregarSimbolo(Simbolo simbolo)
        {
            Simbolos.Add(simbolo);
        }

        public void AgregarSimbolos(List<Simbolo> simbolos)
        {
            Simbolos.AddRange(simbolos);
        }

        public Simbolo BuscarSimbolo(string identificador)
        {
            return Simbolos.Find((simbolo) => simbolo.Identificador.Equals(identificador)) ?? null;
        }

        public bool ContieneSimbolo(string identificador)
        {
            foreach (Simbolo simbolo in Simbolos)
                if (simbolo.Identificador.Equals(identificador))
                    return true;

            return false;
        }

        /// <summary>
        /// Crea una nueva tabla de simbolos a partir de otra, pero con las expresiones resueltas
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static TablaSimbolos DeTablaSimbolos(TablaSimbolos tabla)
        {
            var nuevaTabla = new TablaSimbolos();

            foreach (Simbolo s in tabla.Simbolos)
            {
                // string
                if (s.Tipo.Equals(Gramatica.Terminales.String))
                    nuevaTabla.AgregarSimbolo(s);

                // bool
                else if (s.Tipo.Equals(Gramatica.Terminales.Bool))
                    nuevaTabla.AgregarSimbolo(s);

                // int, float, double
                else
                {
                    string tipo = s.Tipo;
                    string id = s.Identificador;
                    string expresion = s.Valor;

                    if (expresion == null)
                    {
                        nuevaTabla.AgregarSimbolo(new Simbolo(tipo, id));
                        continue;
                    }

                    List<string> infijo = ConvertidorNotacion.TokensDe(expresion);

                    List<string> postfijo = ConvertidorNotacion.InfijoPostfijo(infijo);
                    var variables = new Dictionary<string, double>();

                    // si hay variables, añadirlas al evaluador
                    Console.WriteLine($"Verificando si hay variables en la expresion '{expresion}'...");

                    foreach (string token in postfijo)
                    {
                        if (Utils.ValidarRegex(token, Gramatica.ExpresionesRegulares.IdRegex))
                        {
                            Simbolo temp = nuevaTabla.BuscarSimbolo(token);

                            Console.WriteLine($"Se encontro el simbolo {temp.ToString()}");

                            variables[temp.Identificador] = Double.Parse(temp.Valor);

                            Console.WriteLine($"Se agrego el valor {temp.Valor} con la llave {temp.Identificador}");
                        }
                    }

                    Console.WriteLine("Variables son:");
                    foreach (var i in variables)
                    {
                        Console.WriteLine($"{i.Key} = {i.Value}");
                    }

                    var evaluador = new Evaluador(postfijo, variables);
                    double resultado = evaluador.Evaluar();

                    nuevaTabla.AgregarSimbolo(new Simbolo(tipo, id, resultado.ToString()));
                }
            }

            return nuevaTabla;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("TablaSimbolos{\n");

            foreach (Simbolo simbolo in Simbolos)
            {
                sb.Append('\t').Append(simbolo.ToString()).Append('\n');
            }

            sb.Append('}');

            return sb.ToString();
        }
    }
}
