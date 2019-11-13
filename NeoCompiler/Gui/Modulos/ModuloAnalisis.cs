using System.Collections.Generic;
using System.Windows.Forms;
using NeoCompiler.Analizador;
using NeoCompiler.Analizador.CodigoIntermedio;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloAnalisis : UserControl
    {
        private VentanaPrincipal app;
        public VentanaPrincipal App
        {
            get { return app; }
            set { app = value; }
        }

        public ModuloAnalisis()
        {
            InitializeComponent();
        }

        public void LlenarTablaSimbolos(TablaSimbolos tabla)
        {
            dataGridViewSimbolos.Rows.Clear();

            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                dataGridViewSimbolos.Rows.Add(simbolo.Tipo, simbolo.Identificador, simbolo.Valor);
            }
        }

        public void LlenarTablaResulta(TablaSimbolos tabla)
        {
            dataGridViewTablaResuelta.Rows.Clear();

            foreach (Simbolo simbolo in tabla.Simbolos)
            {
                dataGridViewTablaResuelta.Rows.Add(simbolo.Tipo, simbolo.Identificador, simbolo.Valor);
            }
        }

        public void LlenarTriplos(List<TablaTriplos> tablasTriplos)
        {
            dataGridViewTriplos.Rows.Clear();

            foreach (TablaTriplos tabla in tablasTriplos)
            {
                foreach (var i in tabla.Triplos)
                {
                    Triplo triplo = i.Value;

                    string tipo = triplo.TipoDeTriplo();
                    string operador = triplo.Operador;
                    string operando1 = triplo.Operando1;
                    string operando2 = triplo.Operando2;

                    dataGridViewTriplos.Rows.Add(tipo, operador, operando1, operando2);
                }
            }
        }

        public void LlenarCodigoIntermedio(List<List<string>> bloquesCodigo)
        {
            dataGridViewCodigoIntermedio.Rows.Clear();

            foreach (List<string> lineasCodigo in bloquesCodigo)
            {
                foreach (string linea in lineasCodigo)
                {
                    dataGridViewCodigoIntermedio.Rows.Add(linea);
                }
            }
        }
    }
}
