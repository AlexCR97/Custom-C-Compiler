using System;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    public class Triplo
    {
        private string operador;
        public string Operador { get => operador; set => operador = value; }

        private string operando1;
        public string Operando1 { get => operando1; set => operando1 = value; }

        private string operando2;
        public string Operando2 { get => operando2; set => operando2 = value; }

        public Triplo() { }

        public Triplo(string operador, string operando1, string operando2)
        {
            this.Operador = operador;
            this.Operando1 = operando1;
            this.Operando2 = operando2;
        }

        public override bool Equals(object obj)
        {
            var triplo = obj as Triplo;

            try
            {
                return
                    triplo.Operador.Equals(Operador) &&
                    triplo.Operando1.Equals(Operando1) &&
                    triplo.Operando2.Equals(Operando2);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string TipoDeOperando(string operando)
        {
            if (operando == null)
                return null;

            if (Utils.ValidarRegex(operando, Gramatica.ExpresionesRegulares.StringRegex))
                return Gramatica.Terminales.String;

            if (Utils.ValidarRegex(operando, Gramatica.ExpresionesRegulares.NumeroRegex))
            {
                if (operando.Contains("."))
                    return Gramatica.Terminales.Double;
                else
                    return Gramatica.Terminales.Int;
            }

            return null;
        }

        public string TipoDeTriplo()
        {
            string tipoOperando1 = "";
            string tipoOperando2 = "";

            // Si el segundo operando es nulo, entonces solo hay que sacar el tipo del primer operando
            if (Operando2 == null)
            {
                tipoOperando1 = TipoDeOperando(Operando1);

                // Checando tipo del operando 1
                if (tipoOperando1 == null)
                    return null;

                if (tipoOperando1.Equals(Gramatica.Terminales.String))
                    return Gramatica.Terminales.String;

                if (tipoOperando1.Equals(Gramatica.Terminales.Double))
                    return Gramatica.Terminales.Double;

                if (tipoOperando1.Equals(Gramatica.Terminales.Float))
                    return Gramatica.Terminales.Float;

                if (tipoOperando1.Equals(Gramatica.Terminales.Int))
                    return Gramatica.Terminales.Int;
            }

            // Sino, hay que checar ambos tipos
            tipoOperando2 = TipoDeOperando(Operando2);

            // Checando operando 2
            if (tipoOperando2 == null)
                return null;

            if (tipoOperando2.Equals(Gramatica.Terminales.String) && tipoOperando1.Equals(Gramatica.Terminales.String))
                return Gramatica.Terminales.String;

            if (tipoOperando2.Equals(Gramatica.Terminales.Double) || tipoOperando1.Equals(Gramatica.Terminales.Double))
                return Gramatica.Terminales.Double;

            if (tipoOperando2.Equals(Gramatica.Terminales.Float) || tipoOperando1.Equals(Gramatica.Terminales.Double))
                return Gramatica.Terminales.Float;

            if (tipoOperando2.Equals(Gramatica.Terminales.Int) || tipoOperando1.Equals(Gramatica.Terminales.Double))
                return Gramatica.Terminales.Int;

            return Gramatica.Terminales.Int;
        }

        public override string ToString()
        {
            return "{" + Operador + ", " + Operando1 + ", " + Operando2 + "}";
        }
    }
}
