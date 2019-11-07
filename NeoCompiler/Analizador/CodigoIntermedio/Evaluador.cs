using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    public class Evaluador
    {
        private List<string> tokens;
        private Dictionary<string, double> variables;

        public Evaluador(List<string> tokensPostfijo, Dictionary<string, double> variables)
        {
            this.tokens = tokensPostfijo;
            this.variables = variables;
        }

        public double Evaluar()
        {
            var pilaTokens = new Stack<string>();

            foreach (string tokenActual in tokens)
            {
                if (!EsOperador(tokenActual))
                    pilaTokens.Push(tokenActual);

                else
                {
                    string a = pilaTokens.Pop();
                    string b = pilaTokens.Pop();
                    string c = EjecutarOperacion(b, a, tokenActual).ToString();

                    pilaTokens.Push(c);
                }
            }

            string pop = pilaTokens.Pop();

            Console.WriteLine("/ = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = /");
            Console.WriteLine(pop);
            Console.WriteLine("/ = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = / = /");

            return Double.Parse(pop);
        }

        private double EjecutarOperacion(string a, string b, string operador)
        {
            double aValor;
            if (EsVariable(a))
                aValor = variables[a];
            else
                aValor = Double.Parse(a);

            double bValor;
            if (EsVariable(b))
                bValor = variables[b];
            else
                bValor = Double.Parse(b);

            switch (operador)
            {
                case Gramatica.Terminales.Mas: return aValor + bValor;
                case Gramatica.Terminales.Menos: return aValor - bValor;
                case Gramatica.Terminales.Por: return aValor * bValor;
                case Gramatica.Terminales.Entre: return aValor / bValor;
                case Gramatica.Terminales.Modulo: return aValor % bValor;
                case Gramatica.Terminales.Potencia: return Math.Pow(aValor, bValor);
                default: return -1;
            }
        }

        private bool EsOperador(string token)
        {
            return
                token.Equals(Gramatica.Terminales.Mas) ||
                token.Equals(Gramatica.Terminales.Menos) ||
                token.Equals(Gramatica.Terminales.Por) ||
                token.Equals(Gramatica.Terminales.Entre) ||
                token.Equals(Gramatica.Terminales.ParentesisAbrir) ||
                token.Equals(Gramatica.Terminales.ParentesisCerrar);
        }

        private bool EsVariable(string token)
        {
            try
            {
                Double.Parse(token);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
