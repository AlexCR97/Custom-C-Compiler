using System.Windows.Forms;
using NeoCompiler.Gui.Controles;

namespace NeoCompiler.Gui.Modulos
{
    public partial class ModuloCodigo : UserControl
    {
        private VentanaPrincipal app;
        public VentanaPrincipal App
        {
            get { return app; }
            set { app = value; }
        }

        public ModuloCodigo()
        {
            InitializeComponent();
        }

        public void AgregarPestana(string nombrePestana)
        {
            var controlCodigo = new ControlCodigo()
            {
                Dock = DockStyle.Fill,
            };

            var nuevaPagina = new TabPage(nombrePestana);
            nuevaPagina.Controls.Add(controlCodigo);

            tabControlPestanas.TabPages.Add(nuevaPagina);
            tabControlPestanas.SelectedIndex = tabControlPestanas.TabCount - 1;
        }

        public void AgregarPestana(string nombrePestana, string codigoFuente)
        {
            var controlCodigo = new ControlCodigo()
            {
                Dock = DockStyle.Fill,
                CodigoFuente = codigoFuente,
            };

            var nuevaPagina = new TabPage(nombrePestana);
            nuevaPagina.Controls.Add(controlCodigo);

            tabControlPestanas.TabPages.Add(nuevaPagina);
            tabControlPestanas.SelectedIndex = tabControlPestanas.TabCount - 1;
        }

        public int CantidadLineas()
        {
            return ControlCodigoSeleccionado().CantidadLineas;
        }

        public string NombrePestanaSeleccionada()
        {
            if (tabControlPestanas.TabCount == 0)
                return null;

            return tabControlPestanas.SelectedTab.Text;
        }

        public ControlCodigo ControlCodigoSeleccionado()
        {
            TabPage paginaSeleccionada = tabControlPestanas.SelectedTab;
            var controlCodigoSeleccionado = paginaSeleccionada.Controls[0] as ControlCodigo;
            return controlCodigoSeleccionado;
        }

        public string CodigoFuenteSeleccionado()
        {
            ControlCodigo controlCodigoSeleccionado = ControlCodigoSeleccionado();
            return controlCodigoSeleccionado.CodigoFuente;
        }
    }
}
