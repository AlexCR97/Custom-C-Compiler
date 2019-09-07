using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    public class Simbolo
    {
        private string tipo;
        public string Tipo { get => tipo; set => tipo = value; }

        private string identificador;
        public string Identificador { get => identificador; set => identificador = value; }

        private string valor;
        public string Valor { get => valor; set => valor = value; }

        public Simbolo(string tipo, string identificador)
        {
            this.Tipo = tipo;
            this.Identificador = identificador;
        }

        public Simbolo(string tipo, string identificador, string valor)
        {
            this.Tipo = tipo;
            this.Identificador = identificador;
            this.Valor = valor;
        }

        public override string ToString()
        {
            return "Simbolo{'" + Tipo + "', '" + Identificador + "', '" + Valor + "'}";
        }
    }
}
