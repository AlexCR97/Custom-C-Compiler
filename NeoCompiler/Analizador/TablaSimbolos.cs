using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    public class TablaSimbolos
    {
        private List<Simbolo> simbolos = new List<Simbolo>();
        public List<Simbolo> Simbolos { get => simbolos; }

        public TablaSimbolos() {}

        public void AgregarSimbolo(Simbolo simbolo)
        {
            simbolos.Add(simbolo);
        }

        public void AgregarSimbolos(List<Simbolo> simbolos)
        {
            this.simbolos.AddRange(simbolos);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("TablaSimbolos{\n");

            foreach (Simbolo simbolo in simbolos)
            {
                sb.Append('\t').Append(simbolo.ToString()).Append('\n');
            }

            sb.Append('}');

            return sb.ToString();
        }
    }
}
