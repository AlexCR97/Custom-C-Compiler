using System;
using System.Collections.Generic;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    class GeneradorCodigoIntermedio
    {
        /// <summary>
        /// Generar los triplos para un simbolo determinado
        /// </summary>
        /// <param name="simbolo"></param>
        /// <returns></returns>
        public TablaTriplos GenerarTriplos(Simbolo simbolo)
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");

            string identificador = simbolo.Identificador;
            string expresion = simbolo.Valor;

            Console.WriteLine("Generando triplos para simbolo con valor " + expresion);

            List<string> infijo = ConvertidorNotacion.TokensDe(expresion);

            /**
             * Si tenemos una expresion de un solo simbolo (x),
             * entonces debemos converitlo a una expresion infija (x + 0)
             */
            if (infijo.Count == 1)
            {
                string tokenTemp = infijo[0];
                infijo = new List<string>()
                {
                    "(", tokenTemp, "+", "0", ")"
                };
            }

            Console.WriteLine($"Tokens de expresion infija: {String.Join(", ", infijo)}");

            List<string> prefijo = ConvertidorNotacion.InfijoPrefijo(infijo);

            Console.WriteLine($"Tokens de expresion prefija: {String.Join(", ", prefijo)}");

            TablaTriplos tablaTriplos = TablaTriplosFactory.DeExpresionPrefija(identificador, prefijo);

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");

            return tablaTriplos;
        }

        /// <summary>
        /// Generar todas las tablas de triplos dada una tabla de simbolos
        /// </summary>
        /// <param name="tablaSimbolos"></param>
        /// <returns></returns>
        public List<TablaTriplos> GenerarTriplos(TablaSimbolos tablaSimbolos)
        {
            var tablasTriplos = new List<TablaTriplos>();

            foreach (Simbolo simbolo in tablaSimbolos.Simbolos)
            {
                TablaTriplos triplos = GenerarTriplos(simbolo);
                tablasTriplos.Add(triplos);
            }

            return tablasTriplos;
        }

        /// <summary>
        /// Genera el codigo intermedio dada una tabla de triplos
        /// </summary>
        /// <param name="triplos"></param>
        /// <returns></returns>
        public List<string> GenerarCodigo(TablaTriplos triplos)
        {
            var lineasCodigo = new List<string>();

            foreach (var i in triplos.Triplos)
            {
                string id = i.Key;
                Triplo triplo = i.Value;

                lineasCodigo.Add($"{triplo.TipoDeTriplo()} {id} = {triplo.Operando1} {triplo.Operador} {triplo.Operando2};");
            }

            return lineasCodigo;
        }

        /// <summary>
        /// Genera todos los bloques de codigo intermedio dada una lista de tablas de triplos
        /// </summary>
        /// <param name="tablasTriplos"></param>
        /// <returns></returns>
        public List<List<string>> GenerarCodigo(List<TablaTriplos> tablasTriplos)
        {
            var bloquesCodigo = new List<List<string>>();

            foreach (TablaTriplos triplos in tablasTriplos)
            {
                List<string> codigo = GenerarCodigo(triplos);
                bloquesCodigo.Add(codigo);
            }

            return bloquesCodigo;
        }
    }
}
