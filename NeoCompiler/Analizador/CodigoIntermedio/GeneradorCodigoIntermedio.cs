using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    class GeneradorCodigoIntermedio
    {
        public TablaTriplos GenerarTriplos(string expresion)
        {
            List<string> infijo = ConvertidorNotacion.TokensDe(expresion);
            List<string> prefijo = ConvertidorNotacion.InfijoPrefijo(infijo);

            Console.Write("Infijo:  ");
            infijo.ForEach(token => Console.Write(token + ", "));
            Console.WriteLine();

            Console.Write("Prefijo: ");
            prefijo.ForEach(token => Console.Write(token + ", "));
            Console.WriteLine();

            return new TablaTriplos(prefijo);
        }

        public List<string> GenerarCodigo(TablaTriplos triplos)
        {
            var codigo = new List<string>();
            int contadorId = 0;

            foreach (var i in triplos.Triplos)
            {
                string id = i.Key;
                Triplo t = i.Value;

                string linea = $"{id} = {t.Operando1} {t.Operador} {t.Operando2};";
                codigo.Add(linea);

                contadorId++;
            }

            string ultimaLinea = $"t{contadorId} = t{contadorId - 1}";
            codigo.Add(ultimaLinea);

            return codigo;
        }
    }
}
