using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecutor
{
    public class NeoToken
    {
        public readonly string Lexeme;
        public readonly string Token;

        public NeoToken(string lexeme, string token)
        {
            Lexeme = lexeme;
            Token = token;
        }

        public override string ToString()
        {
            return $"NeoToken({Lexeme}, {Token})";
        }
    }
}
