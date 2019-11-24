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
            ["print"] = "Console.Write",
            ["println"] = "Console.WriteLine",
            ["@i"] = "int.Parse(Console.ReadLine())",
            ["@f"] = "float.Parse(Console.ReadLine())",
            ["@d"] = "double.Parse(Console.ReadLine())",
            ["@b"] = "bool.Parse(Console.ReadLine())",
            ["@s"] = "Console.ReadLine()",
            ["base"] = "basee",
            ["when"] = "switch",
            ["matches"] = "case",
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

            for (int i = 0; i < NeoSourceCode.Count; i++)
            {
                string currentToken = NeoSourceCode[i].Token;

                if (ParseTokens.ContainsKey(currentToken))
                    currentToken = ParseTokens[currentToken];

                tokens.Add(currentToken);
                
                // check for 'matches'
                if (i - 1 >= 0)
                {
                    string lastToken = NeoSourceCode[i - 1].Token;

                    if (lastToken == "matches")
                        tokens.Add(":");
                }

                // check for 'default'
                if (currentToken == "default")
                    tokens.Add(":");
            }

            tokens.Add("}");

            return tokens;
        }

        public string ParseToSourceCode()
        {
            var sb = new StringBuilder();

            List<string> tokens = ParseToTokenList();

            for (int i = 0; i < tokens.Count; i++)
            {
                string currentToken = tokens[i];
                string nextToken = "";

                if (i != tokens.Count - 1)
                    nextToken = tokens[i + 1];

                sb.Append(currentToken);

                // check for <=, >=, ==, !=
                if (currentToken == "<" && nextToken == "=") { }

                else if (currentToken == ">" && nextToken == "=") { }

                else if (currentToken == "=" && nextToken == "=") { }

                else if (currentToken == "!" && nextToken == "=") { }

                else
                {
                    sb.Append(" ");
                }

                // check for {, }, ;
                if (currentToken == "{" || currentToken == "}" || currentToken == ";")
                    sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
