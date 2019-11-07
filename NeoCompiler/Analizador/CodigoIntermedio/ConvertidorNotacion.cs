using System.Collections.Generic;
using System.Text;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    class ConvertidorNotacion
    {
        public static string NormalizarExpresion(string expresion)
        {
            List<string> infijo = TokensDe(expresion);
            List<string> postfijo = InfijoPostfijo(infijo);
            List<string> infijoParentesis = PostfijoInfijo(postfijo);

            var sb = new StringBuilder();

            for (int i = 0; i < infijoParentesis.Count; i++)
            {
                sb.Append(infijoParentesis[i]);

                if (i != infijoParentesis.Count - 1)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public static List<string> InfijoPostfijo(List<string> tokensInfijo)
        {
            var postfijo = new List<string>();
            var pilaTokens = new Stack<string>();
            string popped;

            foreach (string tokenActual in tokensInfijo)
            {
                if (!EsOperador(tokenActual))
                    postfijo.Add(tokenActual);

                else if (tokenActual.Equals(Gramatica.Terminales.ParentesisCerrar))
                    while (!(popped = pilaTokens.Pop()).Equals(Gramatica.Terminales.ParentesisAbrir))
                        postfijo.Add(popped);

                else
                {
                    while (pilaTokens.Count != 0 && !tokenActual.Equals(Gramatica.Terminales.ParentesisAbrir) && PrecedenciaDe(pilaTokens.Peek()) >= PrecedenciaDe(tokenActual))
                        postfijo.Add(pilaTokens.Pop());

                    pilaTokens.Push(tokenActual);
                }
            }

            while (pilaTokens.Count != 0)
                postfijo.Add(pilaTokens.Pop());

            return postfijo;
        }

        public static List<string> InfijoPrefijo(List<string> tokensInfijo)
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
                if (EsOperador(tokenActual))
                {
                    operadores.Push(tokenActual);

                    if (operadores.Contains(Gramatica.Terminales.ParentesisAbrir) && operadores.Contains(Gramatica.Terminales.ParentesisCerrar))
                    {
                        bool encontroAbrir = false;
                        bool encontroCerrar = false;

                        while (!encontroAbrir || !encontroCerrar)
                        {
                            string token = operadores.Pop();

                            if (token.Equals(Gramatica.Terminales.ParentesisAbrir))
                            {
                                encontroAbrir = true;
                                continue;
                            }

                            if (token.Equals(Gramatica.Terminales.ParentesisCerrar))
                            {
                                encontroCerrar = true;
                                continue;
                            }

                            operandos.Push(token);
                        }
                    }
                }
                // si es operando
                else
                {
                    operandos.Push(tokenActual);
                }
            }

            // voltear tokens
            var prefijo = new List<string>();

            while (operandos.Count > 0)
            {
                string token = operandos.Pop();
                prefijo.Add(token);
            }

            return prefijo;
        }

        public static List<string> PostfijoInfijo(List<string> tokensPostfijo)
        {
            var operandos = new Stack<string>();

            foreach (string tokenActual in tokensPostfijo)
            {
                if (EsOperando(tokenActual))
                    operandos.Push(tokenActual);

                else
                {
                    string operando2 = operandos.Pop();
                    string operando1 = operandos.Pop();
                    string operador = tokenActual;
                    string nuevoOperando = $"( {operando1} {operador} {operando2} )";
                    operandos.Push(nuevoOperando);
                }
            }

            string expression = operandos.Pop();
            var infjo = TokensDe(expression);
            return infjo;
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

        public static List<string> TokensDe(string expresion)
        {
            if (expresion == null)
                return new List<string>();

            string[] tokens = expresion.Split(' ');
            var listaTokens = new List<string>(tokens);
            return listaTokens;
        }
    }
}
