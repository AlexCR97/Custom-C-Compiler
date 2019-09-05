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

            // Despues, realizar analisis
            var sintactico = new Sintactico();
            ParseTree arbol = sintactico.Analizar(codigoPestanaSeleccionada);

            moduloSalida.Mostrar("Realizando analisis...\n");

            if (arbol.Root == null)
            {
                moduloSalida.Mostrar("Analisis FALLÓ :(\n", ModuloSalida.SalidaError);
                return;
            }

            moduloSalida.Mostrar("Analisis EXITOSO :D\n", ModuloSalida.SalidaExito);
        }

        // Cerrar archivo
        private void toolStripButtonCloseFile_Click(object sender, EventArgs e)
        {
            string entrada = moduloCodigo.CodigoFuenteSeleccionado();
            var sintactico = new Sintactico();
            ParseTree arbol = sintactico.Analizar(entrada);
            var arbolSintaxis = new ArbolSintaxis(arbol);

            ///

            List<ParseTreeNode> nodos = arbolSintaxis.Recorrer(Gramatica.NT_DECLARACION_VARAIBLE);
            Console.WriteLine("\n\nNodos con '"+ Gramatica.NT_DECLARACION_VARAIBLE +"' encontrados:");

            //List<ParseTreeNode> nodos = arbolSintaxis.Recorrer();
            //Console.WriteLine("\n\nNodos encontrados:");

            nodos.ForEach(nodo =>
            {
                Console.WriteLine(arbolSintaxis.ImprimirNodo(nodo));
                Console.WriteLine("========================================================");
            });

            Console.WriteLine("\nRecorridos sobre cada nodo encontrado:\n");
            nodos.ForEach(nodo =>
            {
                arbolSintaxis
                    .Recorrer(nodo)
                    .ForEach(hijo => Console.Write(hijo.ToString() + " | "));

                Console.WriteLine();
            });

            Console.WriteLine("\n////////////////////////////////////////////////////////\n");

            var semantico = new Semantico(arbolSintaxis);
            TablaSimbolos tabla = semantico.GenerarTablaSimbolos();

            Console.WriteLine("\n////////////////////////////////////////////////////////\n");
            Console.WriteLine(tabla);

            Console.WriteLine(tabla.simbolos.Count);
            tabla.simbolos.ForEach(s => Console.WriteLine(s.ToString()));
        }
    }
}
