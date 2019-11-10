using NeoCompiler.Analizador.ErroresSemanticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public class FuncionPrint : Funcion
    {
        private readonly TablaSimbolos tablaSimbolos;

        public FuncionPrint(string identificador, List<object> parametros, TablaSimbolos tablaSimbolos) : base(identificador, parametros)
        {
            this.tablaSimbolos = tablaSimbolos;
        }

        public override object Ejecutar()
        {
            if (Parametros.Count != 1)
                throw new ErrorCantidadParametros(Identificador, 1);

            Console.WriteLine($"Ejecutando funcion {ToString()}");

            object parametro = Parametros[0];

            // String
            if (Utils.ValidarRegex(parametro.ToString(), Gramatica.ExpresionesRegulares.StringRegex))
            {
                Console.WriteLine($"El parametro {parametro} es un string");
                return parametro.ToString().Substring(1, parametro.ToString().Length - 2);
            }

            // Identificador
            if (Utils.ValidarRegex(parametro.ToString(), Gramatica.ExpresionesRegulares.IdRegex))
            {
                Console.WriteLine($"El parametro {parametro} es un identificador");

                string id = parametro.ToString();
                Simbolo simbolo = tablaSimbolos.BuscarSimbolo(id);
                string valor = tablaSimbolos.EncontrarValor(simbolo);

                Console.WriteLine("El valor encontrado es " + valor);

                /**
                 * De acuerdo al valor del simbolo, hay que calcular su nuevo valor
                 */

                // String
                if (Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.StringRegex))
                    return valor.ToString().Substring(1, valor.ToString().Length - 2);

                // Numero
                if (Utils.ValidarRegex(valor, Gramatica.ExpresionesRegulares.NumeroRegex))
                    return valor;

                return valor;
            }

            // Numero
            if (Utils.ValidarRegex(parametro.ToString(), Gramatica.ExpresionesRegulares.NumeroRegex))
            {
                Console.WriteLine($"El parametro {parametro} es un numero");
                return parametro;
            }

            return parametro;
        }
    }
}
