using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.CodigoIntermedio
{
    public class Triplo
    {
        private string id;
        public string Id { get => id; set => id = value; }

        private string operador;
        public string Operador { get => operador; set => operador = value; }

        private string operando1;
        public string Operando1 { get => operando1; set => operando1 = value; }

        private string operando2;
        public string Operando2 { get => operando2; set => operando2 = value; }

        public Triplo() { }

        public Triplo(string id, string operador, string operando1, string operando2)
        {
            this.Id = id;
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

        public override string ToString()
        {
            return $"{Operador}, {Operando1}, {Operando2}";
        }
    }
}
