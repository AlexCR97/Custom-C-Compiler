using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NeoCompiler.Analizador
{
    public class Utils
    {
        public const string RutaArchivoCompilacionExitosa = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\compilacion exitosa.txt";
        public const string RutaArchivoErrorSintactico = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\error sintactico.txt";
        public const string RutaArchivoErrorSemantico = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\error semantico.txt";

        public const string RutaArchivoTiempoPromedioCompilacionExitosa = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\compilacion exitosa tiempo promedio.txt";
        public const string RutaArchivoTiempoPromedioErrorSintactico = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\error sintactico tiempo promedio.txt";
        public const string RutaArchivoTiempoPromedioErrorSemantico = @"C:\Users\carp_\Desktop\Neo Compiler Analisis\error semantico tiempo promedio.txt";

        public static void EscribirArchivo(string rutaArchivo, string texto, bool append)
        {
            using (var sw = new StreamWriter(rutaArchivo, append))
            {
                sw.WriteLine(texto);
            }
        }

        public static List<string> LeerArchivo(string rutaArchivo)
        {
            string[] lineas = File.ReadAllLines(rutaArchivo);
            return new List<string>(lineas);
        }

        public static Dictionary<int, long> TiemposPromedioDe(string rutaArchivo)
        {
            List<string> lineas = LeerArchivo(rutaArchivo);
            var sumasTiempo = new Dictionary<int, long>();
            var cantidadTiempos = new Dictionary<int, int>();

            foreach (string linea in lineas)
            {
                string[] tokens = linea.Split(' ');

                int cantidadLineas = int.Parse(tokens[0]);
                long tiempo = long.Parse(tokens[1]);

                if (!sumasTiempo.ContainsKey(cantidadLineas))
                    sumasTiempo[cantidadLineas] = 0;

                if (!cantidadTiempos.ContainsKey(cantidadLineas))
                    cantidadTiempos[cantidadLineas] = 0;

                sumasTiempo[cantidadLineas] += tiempo;
                cantidadTiempos[cantidadLineas]++;
            }

            var tiemposPromedio = new Dictionary<int, long>();

            foreach (var cantidadLineas in sumasTiempo.Keys)
            {
                tiemposPromedio[cantidadLineas] = sumasTiempo[cantidadLineas] / cantidadTiempos[cantidadLineas];
            }

            return tiemposPromedio;
        }

        public static void RegistrarTiemposPromedio(string rutaArchivo, Dictionary<int, long> tiempos)
        {
            EscribirArchivo(rutaArchivo, "", false);

            foreach (var i in tiempos)
            {
                int cantidadLineas = i.Key;
                long tiempoPromedio = i.Value;

                EscribirArchivo(rutaArchivo, $"{cantidadLineas} {tiempoPromedio}", true);
            }
        }

        public static bool ValidarRegex(string cadena, string regex)
        {
            Match validacion = Regex.Match(cadena, regex);
            return validacion.Success;
        }
    }
}
