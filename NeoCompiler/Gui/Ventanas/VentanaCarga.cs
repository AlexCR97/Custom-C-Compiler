using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCompiler.Gui.Ventanas
{
    public partial class VentanaCarga : Form
    {
        string[] cargando = new string[]
        {
            "Iniciando IDE...",
            "Ejecutando servicios...",
            "Cargando modulos...",
            "Pintando interfaz...",
            "Abriendo IDE...",
        };

        public VentanaCarga()
        {
            InitializeComponent();

            Cargar();
        }

        private void Cargar()
        {
            var timer = new Timer()
            {
                Interval = 1800,
            };

            int index = 0;
            timer.Tick += (s, e) =>
            {
                if (index >= cargando.Length)
                {
                    timer.Stop();

                    var ventana = new VentanaPrincipal();
                    ventana.Show();

                    this.Hide();
                }
                else
                {
                    labelCargando.Text = cargando[index++];
                }
            };

            timer.Start();
        }
    }
}
