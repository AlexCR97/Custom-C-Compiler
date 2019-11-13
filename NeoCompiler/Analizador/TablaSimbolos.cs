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
        /// Encuentra el valor para un simbolo dado. Esto incluye simbolos con valores
        /// recursivos, es decir, si un simbolo tiene como valor un identificador, entonces
        /// se buscara el valor del simbolo con dicho identificador, y asi recursivamente.
        /// </summary>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        public string EncontrarValor(Simbolo simbolo)
        {
            string valor = simbolo.Valor;

            if (!ContieneSimbolo(valor))
                return valor;

            return EncontrarValor(simbolo, valor);
        }

        public string EncontrarValor(string identificador)
        {
            Simbolo simbolo = BuscarSimbolo(identificador);

            if (simbolo == null)
                return identificador;

            string valor = simbolo.Valor;

            if (!ContieneSimbolo(valor))
                return valor;

            return EncontrarValor(simbolo, valor);
        }

        private string EncontrarValor(Simbolo s, string id)
        {
            s = BuscarSimbolo(id);
            string valor = s.Valor;

            if (!ContieneSimbolo(valor))
                return valor;

            return EncontrarValor(s, valor);
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
                string tipo = s.Tipo;
                string identificador = s.Identificador;
                string valor = s.Valor;

                // si el valor es un identificador, buscamos su valor recursivamente antes de realizar cualquier operacion
                if (tabla.ContieneSimbolo(valor))
                    valor = tabla.EncontrarValor(valor);

                // si el valor es un string, lo agregamos directamente a la nueva tabla
                if (Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                {
                    var nuevoSimbolo = new Simbolo(tipo, identificador, valor);
                    nuevaTabla.AgregarSimbolo(nuevoSimbolo);
                }

                // si el valor es un numero, lo resolvemos con un evaluador de expresiones
                else
                {
                    string expresionAritmetica = valor;
                    List<string> tokensInfijo = ConvertidorNotacion.TokensDe(expresionAritmetica);
                    List<string> tokensPostfijo = ConvertidorNotacion.InfijoPostfijo(tokensInfijo);
                    var variables = new Dictionary<string, double>();
                    var evaluador = new Evaluador(tokensPostfijo, variables);
                    string nuevoValor = evaluador.Evaluar().ToString();

                    var nuevoSimbolo = new Simbolo(tipo, identificador, nuevoValor);
                    nuevaTabla.AgregarSimbolo(nuevoSimbolo);
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
