using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using NeoCompiler.Analizador;
using NeoCompiler.Analizador.CodigoIntermedio;
using NeoCompiler.Analizador.ErroresSemanticos;
using NeoCompiler.Gui.Modulos;

namespace NeoCompiler
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();

            moduloAnalisis.App = this;
            moduloExplorador.App = this;
            moduloSalida.App = this;
            moduloCodigo.App = this;

            /*string expresion = "( A + ( B * C ) / D )";
            var generador = new GeneradorCodigoIntermedio();
            TablaTriplos tabla = generador.GenerarTriplos(expresion);
            List<string> codigo = generador.GenerarCodigo(tabla);

            Console.WriteLine(tabla);
            Console.WriteLine();

            codigo.ForEach(linea => Console.WriteLine(linea));

            Console.WriteLine("=============================================");
            Console.WriteLine("=============================================");
            Console.WriteLine();*/

            //Foo();
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
            // Primero, guardar archivo
            string nombrePestanaSeleccionada = moduloCodigo.NombrePestanaSeleccionada();

            if (nombrePestanaSeleccionada == null)
                return;

            string codigoPestanaSeleccionada = moduloCodigo.CodigoFuenteSeleccionado();

            EscribirArchivo(nombrePestanaSeleccionada, codigoPestanaSeleccionada);

            // Segundo, realizar analisis lexico-sintactico
            var sintactico = new Sintactico();
            ParseTree arbol = sintactico.Analizar(codigoPestanaSeleccionada);

            moduloSalida.Mostrar("Compilando archivo '" + nombrePestanaSeleccionada + "'...\n");

            if (arbol.Root == null)
            {
                moduloSalida.Mostrar("Error lexico-sintáctico\n", ModuloSalida.SalidaError);
                return;
            }

            moduloSalida.Mostrar("Analisis lexico-sintáctico realizado con exito\n", ModuloSalida.SalidaExito);

            // Tercero, realizar analisis semantico
            var arbolSintaxis = new ArbolSintaxis(arbol);
            var semantico = new Semantico(arbolSintaxis);

            try
            {

                TablaSimbolos tabla = semantico.GenerarTablaSimbolos();

                moduloAnalisis.LlenarTablaSimbolos(tabla);

                semantico.ChecarDuplicados(tabla, -1);

                semantico.ChecarTipos(tabla, -1);

                semantico.ChecarExpresionesRelacionales(tabla);
            }
            catch (ErrorNeo err)
            {
                moduloSalida.Mostrar("Error semántico. " + err.Message + "\n", ModuloSalida.SalidaError);
                return;
            }

            moduloSalida.Mostrar("Analisis semantico realizado con exito\n", ModuloSalida.SalidaExito);

            // Cuarto, generacion de codigo intermedio
            List<string> expresiones = semantico.ObtenerExpresiones();
            expresiones.ForEach(expresion =>
            {
                Console.WriteLine(expresion);
            });


        }

        // Cerrar archivo
        private void toolStripButtonCloseFile_Click(object sender, EventArgs e)
        {

        }

        public void Foo()
        {
            var generador = new GeneradorCodigoIntermedio();

            //List<string> expresiones = semantico.ObtenerExpresiones();
            List<string> expresiones = new List<string>();
            expresiones.Add("( A + ( (B * C) / D ) )");
            expresiones.Add("( 1 * 10 )");
            expresiones.Add("( ( 10 / ( B * E ) ) ^ ( 10 - 5 ) )");

            var triplos = new List<TablaTriplos>();

            expresiones.ForEach(expresion =>
            {
                TablaTriplos tablaTriplos = generador.GenerarTriplos(expresion);
                triplos.Add(tablaTriplos);
            });

            var bloquesDeCodigo = new List<List<string>>();

            triplos.ForEach(tabla =>
            {
                List<string> lineasDeCodigo = generador.GenerarCodigo(tabla);
                bloquesDeCodigo.Add(lineasDeCodigo);
            });

            bloquesDeCodigo.ForEach(lineas =>
            {
                lineas.ForEach(linea => Console.WriteLine(linea));
            });
        }
    }
}
