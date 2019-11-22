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

            tokens.Insert(tokens.Count - 2, "Console");
            tokens.Insert(tokens.Count - 2, ".");
            tokens.Insert(tokens.Count - 2, "ReadLine");
            tokens.Insert(tokens.Count - 2, "(");
            tokens.Insert(tokens.Count - 2, ")");
            tokens.Insert(tokens.Count - 2, ";");

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
