using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace NeoCompiler.Analizador
{
    class Gramatica : Grammar
    {
        #region Constantes
        public const string NT_INICIO = "<inicio>";
        public const string NT_DECLARACION_VARAIBLE = "<declaracion-variable>";
        public const string NT_TIPO = "<tipo>";
        public const string NT_ASIGNABLE = "<asignable>";

        public const string R_ID = "id";
        #endregion

        public Gramatica() : base()
        {
            #region Non terminals
            var inicio = new NonTerminal("<start>");
            //var useList = new NonTerminal("<use-list>");
            //var useStatement = new NonTerminal("<use-statement>");
            //var useId = new NonTerminal("<use-id>");
            //var namespaceNonTerminal = new NonTerminal("<namespace>");
            //var namespaceBlock = new NonTerminal("<namespace-block>");
            //var namespaceBlockContent = new NonTerminal("<namespace-block-content>");
            var declaracionVariable = new NonTerminal(NT_DECLARACION_VARAIBLE);
            var listaDeclaracionVaraible = new NonTerminal("<var-declaration-list>");
            var listaDeclaracionVariableDinamica = new NonTerminal("<var-declaration-list-dynamic>");
            var declaracionConstante = new NonTerminal("<const-declaration>");
            var listaDeclaracionConstante = new NonTerminal("<const-declaration-list>");
            var tipo = new NonTerminal(NT_TIPO);
            var asignacion = new NonTerminal("<assignment>");
            var asignable = new NonTerminal(NT_ASIGNABLE);
            var listaAsignable = new NonTerminal("<assignable-list>");
            var expresionAritmetica = new NonTerminal("<arithmetic-expression>");
            var operadorAritmetico = new NonTerminal("<arithmetic-operator>");
            var expresionRelacional = new NonTerminal("<relational-expresion>");
            var operadorRelacional = new NonTerminal("<relational-operator>");
            //var mathAssignment = new NonTerminal("<math-assignment>");
            //var mathOperator = new NonTerminal("<math-operator>");
            //var mathAssignable = new NonTerminal("<math-assignable>");
            var llamadaFuncion = new NonTerminal("<function-call>");
            var idLlamadaFuncion = new NonTerminal("<function-call-id>");
            var declaracionFuncion = new NonTerminal("<function-declaration>");
            var tipoFuncion = new NonTerminal("<function-type>");
            var bloqueFuncion = new NonTerminal("<function-block>");
            var parametro = new NonTerminal("<parameter>");
            var listaParametro = new NonTerminal("<parameter-list>");
            var sentencia = new NonTerminal("<statement>");
            var listaSentencia = new NonTerminal("<statement-list>");
            var controladorFlujo = new NonTerminal("<flow-controller>");
            var sentenciaIf = new NonTerminal("<if>");
            var bloqueIf = new NonTerminal("<if-block>");
            var sentenciaElse = new NonTerminal("<else>");
            var sentenciaWhen = new NonTerminal("<when>");
            var bloqueWhen = new NonTerminal("<when-block>");
            var opcionWhen = new NonTerminal("<when-match>");
            var listaOpcionWhen = new NonTerminal("<when-match-list>");
            var defaultWhen = new NonTerminal("<when-default>");
            var sentenciaWhile = new NonTerminal("<while>");
            var bloqueWhile = new NonTerminal("<while-block>");
            var sentenciaFor = new NonTerminal("<for>");
            var parametrosFor = new NonTerminal("<for-params>");
            var parametroFor1 = new NonTerminal("<for-param-1>");
            var parametroFor2 = new NonTerminal("<for-param-2>");
            var parametroFor3 = new NonTerminal("<for-param-3>");
            var bloqueFor = new NonTerminal("<for-block>");
            #endregion

            #region Terminals

            // reserved words
            var use_ = ToTerm("use");
            var namespace_ = ToTerm("namespace");
            var void_ = ToTerm("void");
            var return_ = ToTerm("return");
            var var_ = ToTerm("var");
            var const_ = ToTerm("const");
            var null_ = ToTerm("null");
            var true_ = ToTerm("true");
            var false_ = ToTerm("false");

            // flow controllers
            var if_ = ToTerm("if");
            var else_ = ToTerm("else");
            var when_ = ToTerm("when");
            var matches_ = ToTerm("matches");
            var default_ = ToTerm("default");
            var while_ = ToTerm("while");
            var for_ = ToTerm("for");
            var iterate_ = ToTerm("iterate");

            // data types
            var int_ = ToTerm("int");
            var float_ = ToTerm("float");
            var double_ = ToTerm("double");
            var bool_ = ToTerm("bool");
            var string_ = ToTerm("string");
            var array_ = ToTerm("array");
            var matrix_ = ToTerm("matrix");

            // logical operators
            var and_ = ToTerm("and");
            var or_ = ToTerm("or");
            var not_ = ToTerm("not");

            // math operators
            var add_ = ToTerm("+=");
            var sub_ = ToTerm("-=");
            var mul_ = ToTerm("*=");
            var div_ = ToTerm("/=");
            var mod_ = ToTerm("%=");
            var pow_ = ToTerm("^=");
            var roo_ = ToTerm("~=");

            // relational operators
            var doubleEquals_ = ToTerm("==");
            var different_ = ToTerm("<>");
            var greaterEquals_ = ToTerm(">=");
            var greater_ = ToTerm(">");
            var lessEquals_ = ToTerm("<=");
            var less_ = ToTerm("<");

            // arithmetic operators
            var plus_ = ToTerm("+");
            var minus_ = ToTerm("-");
            var times_ = ToTerm("*");
            var divededBy_ = ToTerm("/");
            var modulus_ = ToTerm("%");
            var powerOf_ = ToTerm("^");
            var root_ = ToTerm("~");

            // others
            var punto_ = ToTerm(".");
            var coma_ = ToTerm(",");
            var dosPuntos_ = ToTerm(":");
            var puntoComa_ = ToTerm(";");
            var dosPuntosDoble_ = ToTerm("::");
            var parentesisAbrir_ = ToTerm("(");
            var parentesisCerrar_ = ToTerm(")");
            var llavesAbrir_ = ToTerm("{");
            var llavesCerrar_ = ToTerm("}");
            //var corcheteAbrir_ = ToTerm("[");
            //var corcheteCerrar_ = ToTerm("]");
            var igual_ = ToTerm("=");
            //var barra_ = ToTerm("|");
            #endregion

            #region Regex
            var comment = new RegexBasedTerminal("comment", "\\/\\*[\\s\\S]*?\\*\\/");
            var id = new RegexBasedTerminal("id", "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*");
            var number = new RegexBasedTerminal("number", "\\d+[f|d]?(\\.\\d+[f|d]?)?");
            var stringRegex = new RegexBasedTerminal("stringRegex", "\"[^\"]*\"");
            #endregion

            #region Production rules

            inicio.Rule =
                declaracionFuncion + inicio |
                declaracionFuncion;

            declaracionFuncion.Rule =
                tipoFuncion + id + parentesisAbrir_ + parentesisCerrar_ + bloqueFuncion;

            tipoFuncion.Rule =
                void_ |
                tipo;

            tipo.Rule =
                int_ |
                float_ |
                double_ |
                bool_ |
                string_;

            bloqueFuncion.Rule =
                llavesAbrir_ + llavesCerrar_ |
                llavesAbrir_ + listaSentencia + llavesCerrar_;

            // void main() {}
            // int max() {}
            // double peso() {}


            listaSentencia.Rule =
                sentencia + puntoComa_ + listaSentencia |
                sentencia + puntoComa_ |

                controladorFlujo + listaSentencia |
                controladorFlujo;

            sentencia.Rule =
                declaracionVariable;

            declaracionVariable.Rule =
                tipo + listaDeclaracionVaraible;

            listaDeclaracionVaraible.Rule =
                id + coma_ + listaDeclaracionVaraible |
                asignacion + coma_ + listaDeclaracionVaraible |
                asignacion |
                id;

            asignacion.Rule =
                id + igual_ + asignable;

            asignable.Rule =
                id |
                expresionAritmetica |
                bool_ |
                stringRegex |
                llamadaFuncion;

            listaAsignable.Rule =
                asignable + coma_ + listaAsignable |
                asignable;

            expresionAritmetica.Rule =
                number |
                id |
                llamadaFuncion |
                parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ |
                expresionAritmetica + operadorAritmetico + expresionAritmetica;

            operadorAritmetico.Rule =
                plus_ |
                minus_ |
                times_ |
                divededBy_ |
                modulus_ |
                powerOf_ |
                root_;

            controladorFlujo.Rule =
                sentenciaIf |
                sentenciaWhen |
                sentenciaWhile |
                sentenciaFor;

            sentenciaIf.Rule =
                if_ + parentesisAbrir_ + expresionRelacional + parentesisCerrar_ + bloqueIf |
                if_ + parentesisAbrir_ + expresionRelacional + parentesisCerrar_ + bloqueIf + else_ + sentenciaIf |
                if_ + parentesisAbrir_ + expresionRelacional + parentesisCerrar_ + bloqueIf + else_ + bloqueIf;

            bloqueIf.Rule =
                bloqueFuncion |
                sentencia + puntoComa_ |
                controladorFlujo;

            expresionRelacional.Rule =
                asignable + operadorRelacional + asignable;

            operadorRelacional.Rule =
                doubleEquals_ |
                different_ |
                greaterEquals_ |
                greater_ |
                lessEquals_ |
                less_;

            sentenciaWhen.Rule =
                when_ + parentesisAbrir_ + id + parentesisCerrar_ + bloqueWhen;

            bloqueWhen.Rule =
                llavesAbrir_ + llavesCerrar_ |
                llavesAbrir_ + listaOpcionWhen + llavesCerrar_;

            listaOpcionWhen.Rule =
                opcionWhen + listaOpcionWhen |
                opcionWhen |
                defaultWhen;

            opcionWhen.Rule =
                matches_ + listaAsignable + bloqueFuncion;

            defaultWhen.Rule =
                default_ + bloqueFuncion;

            sentenciaWhile.Rule =
                while_ + parentesisAbrir_ + expresionRelacional + parentesisCerrar_ + bloqueWhile |
                while_ + parentesisAbrir_ + id + parentesisCerrar_ + bloqueWhile |
                while_ + parentesisAbrir_ + bool_ + parentesisCerrar_ + bloqueWhile;

            bloqueWhile.Rule =
                bloqueFuncion |
                sentencia + puntoComa_ |
                controladorFlujo;

            sentenciaFor.Rule =
                for_ + parentesisAbrir_ + parametrosFor + parentesisCerrar_ + bloqueFor;

            parametrosFor.Rule =
                puntoComa_ + puntoComa_ |
                parametroFor1 + puntoComa_ + puntoComa_ |
                puntoComa_ + parametroFor2 + puntoComa_ |
                parametroFor1 + puntoComa_ + parametroFor2 + puntoComa_ |
                puntoComa_ + puntoComa_ + parametroFor3 |
                parametroFor1 + puntoComa_ + puntoComa_ + parametroFor3 |
                puntoComa_ + parametroFor2 + puntoComa_ + parametroFor3 |
                parametroFor1 + puntoComa_ + parametroFor2 + puntoComa_ + parametroFor3;

            parametroFor1.Rule =
                declaracionVariable;

            parametroFor2.Rule =
                expresionRelacional;

            parametroFor3.Rule =
                asignacion;

            bloqueFor.Rule =
                bloqueFuncion |
                sentencia + puntoComa_ |
                controladorFlujo;

            llamadaFuncion.Rule =
                idLlamadaFuncion + parentesisAbrir_ + parentesisCerrar_ |
                idLlamadaFuncion + parentesisAbrir_ + listaAsignable + parentesisCerrar_;

            idLlamadaFuncion.Rule =
                id + punto_ + idLlamadaFuncion |
                id + dosPuntosDoble_ + idLlamadaFuncion |
                id;

            #endregion

            #region Preferences
            Root = inicio;
            #endregion
        }
    }
}
