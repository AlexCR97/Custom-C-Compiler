using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecutor
{
    public static class NeoTokens
    {
        public static readonly SortedDictionary<string, string> Tokens = new SortedDictionary<string, string>()
        {
            ["COMMENT"] = @"^\/\*[\s\S]*?\*\/",
            ["RESERVED_WORD_USE"] = @"^use\b",
            ["RESERVED_WORD_NAMESPACE"] = @"^namespace\b",
            ["RESERVED_WORD_VOID"] = @"^void\b",
            ["RESERVED_WORD_RETURN"] = @"^return\b",
            ["RESERVED_WORD_VAR"] = @"^var\b",
            ["RESERVED_WORD_CONST"] = @"^const\b",
            ["RESERVED_WORD_NULL"] = @"^null\b",
            ["RESERVED_WORD_TRUE"] = @"^true\b",
            ["RESERVED_WORD_FALSE"] = @"^false\b",
            ["FLOW_CONTROLLER_IF"] = @"^if\b",
            ["FLOW_CONTROLLER_ELSE"] = @"^else\b",
            ["FLOW_CONTROLLER_WHEN"] = @"^when\b",
            ["FLOW_CONTROLLER_MATCHES"] = @"^matches\b",
            ["FLOW_CONTROLLER_DEFAULT"] = @"^default\b",
            ["FLOW_CONTROLLER_WHILE"] = @"^while\b",
            ["FLOW_CONTROLLER_FOR"] = @"^for\b",
            ["FLOW_CONTROLLER_ITERATE"] = @"^iterate\b",
            ["DATA_TYPE_INT"] = @"^int\b",
            ["DATA_TYPE_FLOAT"] = @"^float\b",
            ["DATA_TYPE_DOUBLE"] = @"^double\b",
            ["DATA_TYPE_BOOL"] = @"^bool\b",
            ["DATA_TYPE_STRING"] = @"^string\b",
            ["DATA_TYPE_ARRAY"] = @"^array\b",
            ["DATA_TYPE_MATRIX"] = @"^matrix\b",
            ["DELIMITER_PARENTHESIS_OPEN"] = @"^\(",
            ["DELIMITER_PARENTHESIS_CLOSE"] = @"^\)",
            ["DELIMITER_BRACKET_OPEN"] = @"^\{",
            ["DELIMITER_BRACKET_CLOSE"] = @"^\}",
            ["LOGIC_OPERATOR_AND"] = @"^and\b",
            ["LOGIC_OPERATOR_OR"] = @"^or\b",
            ["LOGIC_OPERATOR_NOT"] = @"^not\b",
            ["MATH_OPERATOR_ADD"] = @"^+=\b",
            ["MATH_OPERATOR_SUB"] = @"^-=\b",
            ["MATH_OPERATOR_MUL"] = @"^*=\b",
            ["MATH_OPERATOR_DIV"] = @"^/=\b",
            ["MATH_OPERATOR_MOD"] = @"^%=\b",
            ["MATH_OPERATOR_POW"] = @"^^=\b",
            ["MATH_OPERATOR_ROO"] = @"^~=\b",
            ["RELATIONAL_OPERATOR_EQUALS"] = @"^==",
            ["RELATIONAL_OPERATOR_DIFFERENT"] = @"^<>",
            ["RELATIONAL_OPERATOR_GREATER_EQUALS"] = @"^>=",
            ["RELATIONAL_OPERATOR_GREATER"] = @"^>",
            ["RELATIONAL_OPERATOR_LESS_EQULAS"] = @"^<=",
            ["RELATIONAL_OPERATOR_LESS"] = @"^<",
            ["ARITHMETIC_OPERATOR_ADD"] = @"^\+",
            ["ARITHMETIC_OPERATOR_SUB"] = @"^\-",
            ["ARITHMETIC_OPERATOR_MUL"] = @"^\*",
            ["ARITHMETIC_OPERATOR_DIV"] = @"^\/",
            ["ARITHMETIC_OPERATOR_MOD"] = @"^\%",
            ["ARITHMETIC_OPERATOR_POW"] = @"^\^",
            ["ARITHMETIC_OPERATOR_ROO"] = @"^\~",
            ["ACCESS_OPERATOR_CLASS"] = @"^\:{2}",
            ["ACCESS_OPERATOR_INSTANCE"] = @"^\.",
            ["ACCESS_OPERATOR_INDEX_OPEN"] = @"^\[",
            ["ACCESS_OPERATOR_INDEX_CLOSE"] = @"^\]",
            ["ASSIGNMENT_OPERATOR"] = @"^\=",
            ["COLON"] = @"^\:",
            ["COMMA"] = @"^\,",
            ["SEMICOLON"] = @"^\;",
            ["TYPE_SPECIFIER"] = @"^\|",
            ["STRING"] = "^\"[^\"]*\"",
            ["MAIN"] = @"^main\b",
            ["NUMBER"] = @"^\d+[f|d]?(\.\d+[f|d]?)?",
            ["IDENTIFIER"] = @"^([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*",

            ["INPUT_INT"] = @"^@i\b",
            ["INPUT_FLOAT"] = @"^@f\b",
            ["INPUT_DOUBLE"] = @"^@d\b",
            ["INPUT_BOOL"] = @"^@f\b",
            ["INPUT_STRING"] = @"^@s\b",
        };

        public static int EndOfMatch(string token, string regex)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine($"Validating '{token}' with regex '{regex}'");

            Match match = Regex.Match(token, regex);

            if (match.Success)
            {
                Console.WriteLine("Match!");
                Console.WriteLine("================================================================================");
                return match.Length;
            }

            Console.WriteLine("No match :(");
            Console.WriteLine("================================================================================");
            return -1;
        }
    }
}
