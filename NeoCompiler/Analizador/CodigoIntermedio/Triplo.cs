﻿using System;

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
            if (TipoDeOperando(Operando1).Equals(Gramatica.Terminales.String) || TipoDeOperando(Operando2).Equals(Gramatica.Terminales.String))
                return Gramatica.Terminales.String;

            if (TipoDeOperando(Operando1).Equals(Gramatica.Terminales.Double) || TipoDeOperando(Operando2).Equals(Gramatica.Terminales.Double))
                return Gramatica.Terminales.Double;

            if (TipoDeOperando(Operando1).Equals(Gramatica.Terminales.Float) || TipoDeOperando(Operando2).Equals(Gramatica.Terminales.Float))
                return Gramatica.Terminales.Float;

            return Gramatica.Terminales.Int;
        }

        public override string ToString()
        {
            return "{" + Operador + ", " + Operando1 + ", " + Operando2 + "}";
        }
    }
}
