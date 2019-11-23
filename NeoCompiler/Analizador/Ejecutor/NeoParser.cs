using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecutor
{
    public class NeoParser
    {
        public static readonly Dictionary<string, string> ParseTokens = new Dictionary<string, string>()
        {
            ["void"] = "public static void",
            ["main"] = "Main",
            ["print"] = "Console.WriteLine",
            ["@i"] = "int.Parse(Console.ReadLine())",
            ["@f"] = "float.Parse(Console.ReadLine())",
            ["@d"] = "double.Parse(Console.ReadLine())",
            ["@b"] = "bool.Parse(Console.ReadLine())",
            ["@s"] = "Console.ReadLine()",
        };

        public List<NeoToken> NeoSourceCode { get; }

        public NeoParser(List<NeoToken> neoSourceCode)
        {
            NeoSourceCode = neoSourceCode;
        }

        public List<string> ParseToTokenList()
        {
            var tokens = new List<string>()
            {
                "using", "System", ";",
                "class", "NeoProgram", "{",
            };

            NeoSourceCode.ForEach(token =>
            {
                string currentToken = token.Token;

                if (ParseTokens.ContainsKey(currentToken))
                    currentToken = ParseTokens[currentToken];

                tokens.Add(currentToken);
            });

            tokens.Add("}");

            return tokens;
        }

        public string ParseToSourceCode()
        {
            var sb = new StringBuilder();

            ParseToTokenList().ForEach(token =>
            {
                sb.Append(token).Append(" ");

                if (token == "{" || token == "}" || token == ";")
                    sb.Append("\n");
            });

            return sb.ToString();
        }
    }
}
