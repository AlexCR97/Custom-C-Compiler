using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    class TablaTriplos
    {
        private SortedDictionary<string, Triplo> triplos = new SortedDictionary<string, Triplo>();
        public SortedDictionary<string, Triplo> Triplos { get => triplos; }

        public TablaTriplos(List<string> prefijo)
        {
            int idContador = 0;

            // voltear tokens
            var pilaTokens = new Stack<string>();
            prefijo.ForEach(token => pilaTokens.Push(token));

            // iterar sobre tokens
            var operandos = new Stack<string>();

            while (pilaTokens.Count > 0)
            {
                string tokenActual = pilaTokens.Pop();

                // si el token actual es operando
                if (ConvertidorNotacion.EsOperando(tokenActual))
                    operandos.Push(tokenActual);

                // si el token actual es operador
                else
                {
                    string operando1 = operandos.Pop();
                    string operando2 = operandos.Pop();

                    Triplo triplo1 = DeExpresion(operando1);
                    Triplo triplo2 = DeExpresion(operando2);

                    if (triplo1 == null && triplo2 == null)
                    {
                        Agregar("t" + idContador, new Triplo(tokenActual, operando1, operando2));

                        string nuevoOperando = $"( {operando1} {tokenActual} {operando2} )";
                        operandos.Push(nuevoOperando);
                    }
                    else if (triplo1 != null && triplo2 != null)
                    {
                        string id1 = EncontrarId(triplo1);
                        string id2 = EncontrarId(triplo2);
                        Agregar("t" + idContador, new Triplo(tokenActual, id1, id2));

                        string nuevoOperando = $"( {id1} {tokenActual} {id2} )";
                        operandos.Push(nuevoOperando);
                    }
                    else if (triplo1 != null && triplo2 == null)
                    {
                        string id1 = EncontrarId(triplo1);
                        Agregar("t" + idContador, new Triplo(tokenActual, id1, operando2));

                        string nuevoOperando = $"( {id1} {tokenActual} {operando2} )";
                        operandos.Push(nuevoOperando);
                    }
                    else if (triplo1 == null && triplo2 != null)
                    {
                        string id2 = EncontrarId(triplo2);
                        Agregar("t" + idContador, new Triplo(tokenActual, operando1, id2));

                        string nuevoOperando = $"( {operando1} {tokenActual} {id2} )";
                        operandos.Push(nuevoOperando);
                    }

                    idContador++;
                }
            }
        }

        public bool Agregar(string id, Triplo triplo)
        {
            if (Contiene(id))
                return false;

            Triplos[id] = triplo;

            return true;
        }

        public bool Contiene(string id)
        {
            return Triplos.ContainsKey(id);
        }

        private Triplo DeExpresion(string expresion)
        {
            try
            {
                // ( A + B )
                string[] tokens = expresion.Split(' ');
                string operador = tokens[2];
                string operando1 = tokens[1];
                string operando2 = tokens[3];
                return new Triplo(operador, operando1, operando2);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Eliminar(string id)
        {
            return Triplos.Remove(id);
        }

        public string EncontrarId(Triplo triplo)
        {
            foreach (var i in Triplos)
            {
                Triplo temp = i.Value;

                if (temp.Equals(triplo))
                    return i.Key;
            }

            return null;
        }

        public Triplo Get(string id)
        {
            if (!Contiene(id))
                return null;

            return Triplos[id];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Triplos.Count == 0)
                return "Triplos: {}";

            foreach (var i in Triplos)
            {
                Triplo t = i.Value;
                sb.Append(i.Key).Append(" = ").Append(t).Append('\n');
            }

            return sb.ToString();
        }
    }
}
