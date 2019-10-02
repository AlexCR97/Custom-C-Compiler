using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    class ConvertidorNotacion
    {
        public static List<string> infijoPrefijo(List<string> tokensInfijo)
        {
            // Voltear expresion
            var pilaTokens = new Stack<string>();
            tokensInfijo.ForEach(token => pilaTokens.Push(token));

            // Iterar sobre tokens volteados
            var operadores = new Stack<string>();
            var operandos = new Stack<string>();

            while (pilaTokens.Count > 0)
            {
                string tokenActual = pilaTokens.Pop();

                // si es operador

            }

            var tokens = new List<string>();

            return tokens;
        }

        public static bool EsOperador(string token)
        {
            return
                token.Equals(Gramatica.Terminales.Mas) ||
                token.Equals(Gramatica.Terminales.Menos) ||
                token.Equals(Gramatica.Terminales.Por) ||
                token.Equals(Gramatica.Terminales.Entre) ||
                token.Equals(Gramatica.Terminales.ParentesisAbrir) ||
                token.Equals(Gramatica.Terminales.ParentesisCerrar);
        }

        public static bool EsOperando(string token)
        {
            return !EsOperador(token);
        }

        public static int PrecedenciaDe(string token)
        {
            if (!EsOperador(token))
                return -1;

            if (token.Equals(Gramatica.Terminales.ParentesisAbrir) || token.Equals(Gramatica.Terminales.ParentesisCerrar))
                return 1;

            if (token.Equals(Gramatica.Terminales.Mas) || token.Equals(Gramatica.Terminales.Menos))
                return 2;

            if (token.Equals(Gramatica.Terminales.Por) || token.Equals(Gramatica.Terminales.Entre) || token.Equals(Gramatica.Terminales.Modulo))
                return 3;

            if (token.Equals(Gramatica.Terminales.Potencia))
                return 4;

            return -1;
        }
    }
}
