using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    class TablaSimbolos
    {
        public List<Simbolo> simbolos = new List<Simbolo>();

        public TablaSimbolos() {}

        public void AgregarSimbolo(Simbolo simbolo)
        {
            simbolos.Add(simbolo);
        }

        public void AgregarSimbolos(List<Simbolo> simbolos)
        {
            Console.WriteLine("Agregando los siguientes simbolos a la tabla: ");
            simbolos.ForEach(s => Console.WriteLine(s));
            simbolos.AddRange(simbolos);
        }

        public override string ToString()
        {
            if (simbolos == null)
                return "TablaSimbolos{}";

            var sb = new StringBuilder();
            sb.Append("TablaSimbolos{\n");

            simbolos.ForEach(simbolo =>
            {
                sb.Append('\t').Append(simbolo.ToString()).Append('\n');
            });

            sb.Append('}');

            return sb.ToString();
        }
    }
}
