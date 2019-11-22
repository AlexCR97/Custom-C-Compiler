using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.Ejecutor
{
    public static class Programa
    {
        public static readonly string Exe = "NeoProgram.exe";
        public static List<CompilerError> Errores = new List<CompilerError>();
        public static List<string> Salida = new List<string>();

        public static bool Compilar(string codigoFuente)
        {
            Errores.Clear();
            Salida.Clear();

            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, Exe, true)
            {
                GenerateExecutable = true,
                OutputAssembly = Exe,
            };

            CompilerResults results = csc.CompileAssemblyFromSource(parameters, codigoFuente);

            Console.WriteLine("===================================");
            Console.WriteLine("Output: " + results.Output.Count);
            Console.WriteLine("===================================");

            Errores = results.Errors.Cast<CompilerError>().ToList();

            if (Errores.Count != 0)
            {
                return false;
            }

            foreach (string s in results.Output)
            {
                Salida.Add(s);
            }

            return true;
        }
    }
}
