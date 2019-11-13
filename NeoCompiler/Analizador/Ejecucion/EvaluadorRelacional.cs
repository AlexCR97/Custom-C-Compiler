using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecucion
{
    public class EvaluadorRelacional
    {
        public class OperandoRelacional
        {
            public string Operando { get; }
            public object Valor { get; }

            public OperandoRelacional(string operando, string valor)
            {
                this.Operando = operando;
                this.Valor = valor;
            }

            public override string ToString()
            {
                return $"OperadorRelacional({Operando} = {Valor})";
            }
        }

        private OperandoRelacional operando1;
        private OperandoRelacional operando2;
        private string operador;

        public EvaluadorRelacional(OperandoRelacional operando1, OperandoRelacional operando2, string operador)
        {
            this.operando1 = operando1;
            this.operando2 = operando2;
            this.operador = operador;
        }

        public bool Evaluar()
        {
            double valorOperando1 = ValorDe(operando1);
            double valorOperando2 = ValorDe(operando2);
            return EjecutarOperacion(valorOperando1, valorOperando2, operador);
        }

        private bool EjecutarOperacion(double a, double b, string operador)
        {
            switch (operador)
            {
                case Gramatica.Terminales.IgualIgual: return a == b;
                case Gramatica.Terminales.Diferente: return a != b;
                case Gramatica.Terminales.Menor: return a < b;
                case Gramatica.Terminales.MenorIgual: return a <= b;
                case Gramatica.Terminales.Mayor: return a > b;
                case Gramatica.Terminales.MayorIgual: return a >= b;
                default: return false;
            }
        }

        public double ValorDe(OperandoRelacional operando)
        {
            Console.WriteLine($"Encontrando valor de {operando}");
            return Double.Parse(operando.Valor.ToString());
        }
    }
}
