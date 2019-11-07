using Irony.Parsing;

namespace NeoCompiler.Analizador
{
    class Sintactico
    {
        public ParseTree Analizar(string entrada)
        {
            var gramatica = new Gramatica();
            var sintactico = new Parser(gramatica);
            return sintactico.Parse(entrada);
        }
    }
}
