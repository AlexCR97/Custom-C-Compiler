using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCompiler.Analizador.Ejecucion;
using NeoCompiler.Gui.Modulos;

namespace NeoCompiler.Analizador.Ejecucion
{
    public class ControladorFlujoIf : ControladorFlujo
    {
        public ControladorFlujoIf(List<Instruccion> cuerpo, string identificador, List<object> parametros, TablaSimbolos tablaSimbolos, ModuloSalida moduloSalida) :
            base(cuerpo, identificador, parametros, tablaSimbolos, moduloSalida) { }

        public override object Ejecutar()
        {
            Console.WriteLine("Ejecutando controlador de flujo 'if'");
            Console.WriteLine(ToString());

            /**
             * Primero, tenemos que obtener los tokens de la expresion relacional y pasarlos
             * a un evaluador de expresiones relacionales
             * 
             * La expresion tiene el siguiente formato:
             * 
             * x > y
             */

            string expresionRelacional = Parametros[0].ToString();
            string[] tokens = expresionRelacional.Split(' ');

            string operando1 = tokens[0];
            string operando2 = tokens[2];
            string operador = tokens[1];

            string valorOperando1 = tablaSimbolos.EncontrarValor(operando1);
            string valorOperando2 = tablaSimbolos.EncontrarValor(operando2);

            var operandoRelacional1 = new EvaluadorRelacional.OperandoRelacional(operando1, valorOperando1);
            var operandoRelacional2 = new EvaluadorRelacional.OperandoRelacional(operando2, valorOperando2);

            /**
             * Evaluamos la expresion.
             * Si el resultado es true, obtenemos las instrucciones en su bloque y las ejecutamos
             * Si el resultado es false, no hacemos nada... por lo pronto
             */

            var evaluador = new EvaluadorRelacional(operandoRelacional1, operandoRelacional2, operador);

            if (evaluador.Evaluar() == true)
            {
                Console.WriteLine($"El resultado de la expresion '{expresionRelacional}' es '{true}'");


            }
            else
            {
                Console.WriteLine($"El resultado de la expresion '{expresionRelacional}' es '{false}'");
            }

            return -1;
        }
    }
}
