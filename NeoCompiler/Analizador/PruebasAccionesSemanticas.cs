using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador
{
    class PruebasAccionesSemanticas
    {
        private readonly ArbolSintaxis arbol;

        public PruebasAccionesSemanticas(ArbolSintaxis arbol)
        {
            this.arbol = arbol;
        }

        private delegate T SemanticAction<T>(ArbolSintaxis arbol, ParseTreeNode raiz);

        public void TestSemanticActions()
        {
            SemanticAction<TablaSimbolos> x = AccionesSemanticas.DeclaracionVariable;
            SemanticAction<object> y = AccionesSemanticas.Inicio;
            SemanticAction<double> z = (tree, root) =>
            {
                Console.WriteLine("Lambda semantic action executing!");
                return -1;
            };

            arbol.Recorrer().ForEach(nodo =>
            {
                switch (nodo.ToString())
                {
                    case Gramatica.NoTerminales.Inicio:
                    {
                        y.Invoke(arbol, nodo);
                        break;
                    }

                    case Gramatica.NoTerminales.DeclaracionVariable:
                    {
                        x.Invoke(arbol, nodo);
                        break;
                    }

                    case Gramatica.NoTerminales.DeclaracionFuncion:
                    {
                        z.Invoke(arbol, nodo);
                        break;
                    }
                }
            });
        }
    }
}
