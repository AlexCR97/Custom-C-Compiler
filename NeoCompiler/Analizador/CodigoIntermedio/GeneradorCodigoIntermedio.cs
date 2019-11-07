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
            string expresion = simbolo.Valor;
            List<string> infijo = ConvertidorNotacion.TokensDe(expresion);
            List<string> prefijo = ConvertidorNotacion.InfijoPrefijo(infijo);

            TablaTriplos tablaTriplos = TablaTriplosFactory.DeExpresionPrefija(prefijo);

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
        /// Generar el codigo intermedio dada una tabla de triplos
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
        /// Generar todos los bloques de codigo intermedio dada una lista de tablas de triplos
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
