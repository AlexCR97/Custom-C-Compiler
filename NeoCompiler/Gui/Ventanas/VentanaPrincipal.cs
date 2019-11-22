using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using NeoCompiler.Analizador;
using NeoCompiler.Analizador.CodigoIntermedio;
using NeoCompiler.Analizador.Ejecucion;
using NeoCompiler.Analizador.Ejecutor;
using NeoCompiler.Analizador.ErroresSemanticos;
using NeoCompiler.Gui.Modulos;

namespace NeoCompiler
{
    public partial class VentanaPrincipal : Form
    {
        private Stopwatch cronometro = new Stopwatch();

        private ArbolSintaxis arbolSintaxis;
        private TablaSimbolos tablaSimbolos;

        public VentanaPrincipal()
        {
            InitializeComponent();

            moduloAnalisis.App = this;
            moduloExplorador.App = this;
            moduloSalida.App = this;
            moduloCodigo.App = this;

            /*string expresion = "a + b * c / d";

            List<string> infijo = ConvertidorNotacion.TokensDe(expresion);
            List<string> postfijo = ConvertidorNotacion.InfijoPostfijo(infijo);

            var variables = new Dictionary<string, double>();
            variables["a"] = 1;
            variables["b"] = 2;
            variables["c"] = 3;
            variables["d"] = 4;

            var evaluador = new Evaluador(postfijo, variables);

            double resultado = evaluador.Evaluar();

            Console.WriteLine(resultado);*/
        }

        /// <summary>
        /// Metodo para testear la ejecucion
        /// </summary>
        private void Foo()
        {
            string nombrePestanaSeleccionada = moduloCodigo.NombrePestanaSeleccionada();

            if (nombrePestanaSeleccionada == null)
                return;

            // analisis lexico

            string codigoFuente = moduloCodigo.CodigoFuenteSeleccionado();
            var lexer = new NeoLexer(codigoFuente);

            while (lexer.HasNext())
            {
                Console.WriteLine($"{lexer.CurrentLexeme}, {lexer.CurrentToken}");
            }

            if (!lexer.IsSuccessful)
            {
                MessageBox.Show($"Error: {lexer.ErrorMessage}");
                return;
            }

            MessageBox.Show("Success");

            lexer.Tokens.ForEach(token =>
            {
                Console.WriteLine(token);
            });

            // conversion de codigo

            var parser = new NeoParser(lexer.Tokens);

            string cSharpSourceCode = parser.ParseToSourceCode();

            MessageBox.Show(cSharpSourceCode);

            // compilacion de codigo

            if (!Programa.Compilar(cSharpSourceCode))
            {
                MessageBox.Show(String.Join("\n", Programa.Errores));
                return;
            }

            MessageBox.Show("Compilacion exitosa");

            // mostrar resultados
            moduloSalida.Mostrar("=====================================\n");
            moduloSalida.Mostrar(String.Join("\n", Programa.Salida));
            moduloSalida.Mostrar("=====================================\n");

            Process.Start(Programa.Exe);
        }

        private string ObtenerRutaArchivo()
        {
            var dialogo = new OpenFileDialog()
            {
                Filter = "Neo Files (*.neo)|*.neo",
                RestoreDirectory = true,
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return null;

            return dialogo.FileName;
        }

        private string LeerArchivo(string rutaArchivo)
        {
            return File.ReadAllText(rutaArchivo);
        }

        private string GuardarRutaArchivo()
        {
            var dialogo = new SaveFileDialog()
            {
                FileName = "main.neo",
                Filter = "Neo files (*.neo) | *.neo",
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
                return null;

            return dialogo.FileName;
        }

        private void EscribirArchivo(string rutaArchivo, string contenido)
        {
            using (var escritor = new StreamWriter(rutaArchivo, false))
            {
                escritor.Write(contenido);
            }
        }

        // Nuevo archivo
        private void toolStripButtonNewFile_Click(object sender, EventArgs e)
        {
            string rutaArchivo = GuardarRutaArchivo();

            if (rutaArchivo == null)
                return;

            using (var escritor = new StreamWriter(rutaArchivo, true))
            {
                escritor.WriteLine("");
            }

            moduloCodigo.AgregarPestana(rutaArchivo, LeerArchivo(rutaArchivo));
        }

        // Abrir archivo
        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            string rutaArchivo = ObtenerRutaArchivo();

            if (rutaArchivo == null)
                return;

            string contenidoArchivo = LeerArchivo(rutaArchivo);

            moduloCodigo.AgregarPestana(rutaArchivo, contenidoArchivo);
        }

        // Guardar archivo
        private void toolStripButtonSaveFile_Click(object sender, EventArgs e)
        {
            string nombrePestanaSeleccionada = moduloCodigo.NombrePestanaSeleccionada();

            if (nombrePestanaSeleccionada == null)
                return;

            string codigoPestanaSeleccionada = moduloCodigo.CodigoFuenteSeleccionado();

            EscribirArchivo(nombrePestanaSeleccionada, codigoPestanaSeleccionada);

            MessageBox.Show("Archivo guardado!");
        }

        // Compilar
        private void toolStripButtonCompile_Click(object sender, EventArgs e)
        {
            // Guardar archivo
            string nombrePestanaSeleccionada = moduloCodigo.NombrePestanaSeleccionada();

            if (nombrePestanaSeleccionada == null)
                return;

            string codigoPestanaSeleccionada = moduloCodigo.CodigoFuenteSeleccionado();

            EscribirArchivo(nombrePestanaSeleccionada, codigoPestanaSeleccionada);

            // Iniciar el cronometro para medir el tiempo de compilacion
            int cantidadLineas = moduloCodigo.CantidadLineas();
            long milisegundos;
            var tiemposPromedio = new Dictionary<int, long>();

            cronometro.Reset();
            cronometro.Start();

            // Realizar analisis lexico-sintactico
            var sintactico = new Sintactico();
            ParseTree arbol = sintactico.Analizar(codigoPestanaSeleccionada);

            moduloSalida.Mostrar("Compilando archivo '" + nombrePestanaSeleccionada + "'...\n");

            if (arbol.Root == null)
            {
                // Analisis lexico-sintactico fallido, registrar el tiempo
                cronometro.Stop();

                milisegundos = cronometro.ElapsedMilliseconds;
                Utils.EscribirArchivo(Utils.RutaArchivoErrorSintactico, $"{cantidadLineas} {milisegundos}", true);

                tiemposPromedio = Utils.TiemposPromedioDe(Utils.RutaArchivoErrorSintactico);
                Utils.RegistrarTiemposPromedio(Utils.RutaArchivoTiempoPromedioErrorSintactico, tiemposPromedio);

                moduloSalida.Mostrar("Error lexico-sintáctico\n", ModuloSalida.SalidaError);
                return;
            }

            moduloSalida.Mostrar("Analisis lexico-sintáctico realizado con exito\n", ModuloSalida.SalidaExito);

            // Tercero, realizar analisis semantico
            arbolSintaxis = new ArbolSintaxis(arbol);
            var semantico = new Semantico(arbolSintaxis);

            tablaSimbolos = semantico.GenerarTablaSimbolos();
            //TablaSimbolos tablaSimbolosResuelta = TablaSimbolos.DeTablaSimbolos(tablaSimbolos);

            try
            {
                moduloAnalisis.LlenarTablaSimbolos(tablaSimbolos);
                //moduloAnalisis.LlenarTablaSimbolos(tablaSimbolosResuelta);

                semantico.ChecarDuplicados(tablaSimbolos, -1);

                semantico.ChecarTipos(tablaSimbolos, -1);

                semantico.ChecarExpresionesRelacionales(tablaSimbolos);
            }
            catch (ErrorNeo err)
            {
                // Analisis semantico fallido, registrar el tiempo
                cronometro.Stop();

                milisegundos = cronometro.ElapsedMilliseconds;
                Utils.EscribirArchivo(Utils.RutaArchivoErrorSemantico, $"{cantidadLineas} {milisegundos}", true);

                tiemposPromedio = Utils.TiemposPromedioDe(Utils.RutaArchivoErrorSemantico);
                Utils.RegistrarTiemposPromedio(Utils.RutaArchivoTiempoPromedioErrorSemantico, tiemposPromedio);

                moduloSalida.Mostrar("Error semántico. " + err.Message + "\n", ModuloSalida.SalidaError);
                return;
            }

            moduloSalida.Mostrar("Analisis semantico realizado con exito\n", ModuloSalida.SalidaExito);

            // Generacion de codigo intermedio
            TablaTriplosFactory.ReiniciarContador();

            var generador = new GeneradorCodigoIntermedio();
            List<TablaTriplos> tablasTriplos = generador.GenerarTriplos(tablaSimbolos);
            List<List<string>> codigoGenerado = generador.GenerarCodigo(tablasTriplos);

            // Compilacion exitosa, registrar el tiempo
            cronometro.Stop();

            milisegundos = cronometro.ElapsedMilliseconds;
            Utils.EscribirArchivo(Utils.RutaArchivoCompilacionExitosa, $"{cantidadLineas} {milisegundos}", true);

            tiemposPromedio = Utils.TiemposPromedioDe(Utils.RutaArchivoCompilacionExitosa);
            Utils.RegistrarTiemposPromedio(Utils.RutaArchivoTiempoPromedioCompilacionExitosa, tiemposPromedio);

            // Llenar tablas de codigo intermedio
            moduloAnalisis.LlenarTriplos(tablasTriplos);

            moduloAnalisis.LlenarCodigoIntermedio(codigoGenerado);

            moduloSalida.Mostrar("\n");

            // Empezar con la ejecucion de codigo
            Ejecutar();
        }

        // Ejecutar
        private void Ejecutar()
        {
            try
            {
                TablaSimbolos tablaResulta = TablaSimbolos.DeTablaSimbolos(tablaSimbolos);
                moduloAnalisis.LlenarTablaResulta(tablaResulta);

                //var colector = new ColectorInstrucciones(arbolSintaxis, tablaSimbolos, moduloSalida);
                var colector = new ColectorInstrucciones(arbolSintaxis, tablaResulta, moduloSalida);

                List<Instruccion> funciones = colector.ObtenerInstrucciones();

                funciones.ForEach(fun =>
                {
                    fun.Ejecutar();
                    Console.WriteLine("----------------------------------------");
                });
            }
            catch(ErrorNeo err)
            {
                moduloSalida.Mostrar("Error de ejecucion. " + err.Message + "\n", ModuloSalida.SalidaError);
                return;
            }
        }

        // Cerrar archivo
        private void toolStripButtonCloseFile_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCompileAndRun_Click(object sender, EventArgs e)
        {
            Foo();
        }
    }
}
