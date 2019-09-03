using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace NeoCompiler.Analyzer
{
    class NeoGrammar : Grammar
    {
        public NeoGrammar() : base()
        {
            #region Non terminals
            var start = new NonTerminal("<start>");
            var useList = new NonTerminal("<use-list>");
            var useStatement = new NonTerminal("<use-statement>");
            var useId = new NonTerminal("<use-id>");
            var namespaceNonTerminal = new NonTerminal("<namespace>");
            var namespaceBlock = new NonTerminal("<namespace-block>");
            var namespaceBlockContent = new NonTerminal("<namespace-block-content>");
            var varDeclaration = new NonTerminal("<var-declaration>");
            var varDeclarationList = new NonTerminal("<var-declaration-list>");
            var varDeclarationListDynamic = new NonTerminal("<var-declaration-list-dynamic>");
            var constDeclaration = new NonTerminal("<const-declaration>");
            var constDeclarationList = new NonTerminal("<const-declaration-list>");
            var type = new NonTerminal("<type>");
            var assignment = new NonTerminal("<assignment>");
            var assignable = new NonTerminal("<assignable>");
            var assignableList = new NonTerminal("<assignable-list>");
            var arithmeticExpression = new NonTerminal("<arithmetic-expression>");
            var arithmeticOperator = new NonTerminal("<arithmetic-operator>");
            var mathAssignment = new NonTerminal("<math-assignment>");
            var mathOperator = new NonTerminal("<math-operator>");
            var mathAssignable = new NonTerminal("<math-assignable>");
            var functionCall = new NonTerminal("<function-call>");
            var functionCallId = new NonTerminal("<function-call-id>");
            var functionDeclaration = new NonTerminal("<function-declaration>");
            var functionType = new NonTerminal("<function-type>");
            var functionBlock = new NonTerminal("<function-block>");
            var parameter = new NonTerminal("<parameter>");
            var parameterList = new NonTerminal("<parameter-list>");
            var statement = new NonTerminal("<statement>");
            var statementList = new NonTerminal("<statement-list>");
            var flowController = new NonTerminal("<flow-controller>");
            var ifStatement = new NonTerminal("<if>");
            var whenStatement = new NonTerminal("<when>");
            var whileStatement = new NonTerminal("<while>");
            var forStatement = new NonTerminal("<for>");
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
            var dot_ = ToTerm(".");
            var comma_ = ToTerm(",");
            var colon_ = ToTerm(":");
            var semicolon_ = ToTerm(";");
            var doubleColon_ = ToTerm("::");
            var parenthesisOpen_ = ToTerm("(");
            var parenthesisClose_ = ToTerm(")");
            var curlyBraceOpen_ = ToTerm("{");
            var curlyBraceClose_ = ToTerm("}");
            var bracketOpen_ = ToTerm("[");
            var bracketClose_ = ToTerm("]");
            var equals_ = ToTerm("=");
            var bar_ = ToTerm("|");
            #endregion

            #region Regex
            var comment = new RegexBasedTerminal("comment", "\\/\\*[\\s\\S]*?\\*\\/");
            var id = new RegexBasedTerminal("id", "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*");
            var number = new RegexBasedTerminal("number", "\\d+[f|d]?(\\.\\d+[f|d]?)?");
            var stringRegex = new RegexBasedTerminal("stringRegex", "\"[^\"]*\"");
            #endregion

            #region Production rules

            start.Rule =
                useList |
                namespaceNonTerminal |
                useList + namespaceNonTerminal;

            useList.Rule =
                useStatement + semicolon_ + useList |
                useStatement + semicolon_;

            useStatement.Rule =
                use_ + useId;

            useId.Rule =
                id + doubleColon_ + useId |
                id;

            namespaceNonTerminal.Rule =
                namespace_ + useId + namespaceBlock;

            namespaceBlock.Rule =
                curlyBraceOpen_ + curlyBraceClose_ |
                curlyBraceOpen_ + namespaceBlockContent + curlyBraceClose_;

            namespaceBlockContent.Rule =
                varDeclaration + semicolon_ + namespaceBlockContent |
                varDeclaration + semicolon_ |

                constDeclaration + semicolon_ + namespaceBlockContent |
                constDeclaration + semicolon_ |

                functionDeclaration + namespaceBlockContent |
                functionDeclaration;

            varDeclaration.Rule =
                type + varDeclarationList |
                var_ + varDeclarationListDynamic;

            varDeclarationList.Rule =
                id + comma_ + varDeclarationList |
                assignment + comma_ + varDeclarationList |
                assignment |
                id;

            varDeclarationListDynamic.Rule =
                assignment + comma_ + varDeclarationList |
                assignment;

            constDeclaration.Rule =
                const_ + constDeclarationList;

            constDeclarationList.Rule =
                assignment + comma_ + constDeclarationList |
                assignment;

            type.Rule =
                int_ |
                float_ |
                double_ |
                bool_ |
                string_ |
                array_ |
                matrix_;

            assignment.Rule =
                id + equals_ + assignable;

            assignable.Rule =
                id |
                bool_ |
                stringRegex |
                functionCall |
                arithmeticExpression;

            assignableList.Rule =
                assignable + comma_ + assignableList |
                assignable;

            arithmeticExpression.Rule =
                number |
                id |
                functionCall |
                parenthesisOpen_ + arithmeticExpression + parenthesisClose_ |
                arithmeticExpression + arithmeticOperator + arithmeticExpression;

            arithmeticOperator.Rule =
                plus_ |
                minus_ |
                times_ |
                divededBy_ |
                modulus_ |
                powerOf_ |
                root_;

            mathAssignment.Rule =
                id + mathOperator + mathAssignable;

            mathOperator.Rule =
                add_ |
                sub_ |
                mul_ |
                div_ |
                mod_ |
                pow_ |
                roo_;

            mathAssignable.Rule =
                id |
                arithmeticExpression |
                functionCall;

            functionCall.Rule =
                functionCallId + parenthesisOpen_ + parenthesisClose_ |
                functionCallId + parenthesisOpen_ + assignableList + parenthesisClose_;

            functionCallId.Rule =
                id + dot_ + functionCallId |
                id + doubleColon_ + functionCallId |
                id;

            functionDeclaration.Rule =
                functionType + id + parenthesisOpen_ + parameterList + parenthesisClose_ + functionBlock |
                functionType + id + parenthesisOpen_ + parenthesisClose_ + functionBlock;

            functionType.Rule =
                void_ |
                type;

            functionBlock.Rule =
                curlyBraceOpen_ + curlyBraceClose_ |
                curlyBraceOpen_ + statementList + curlyBraceClose_;

            statementList.Rule =
                statement + semicolon_ + statementList |
                statement + semicolon_;

            statement.Rule =
                varDeclaration |
                constDeclaration |
                assignment |
                mathAssignment |
                functionCall |
                return_ |
                return_ + assignable;

            parameter.Rule =
                type + id;

            parameterList.Rule =
                parameter + comma_ + parameterList |
                parameter;

            #endregion

            #region Preferences
            Root = start;
            #endregion
        }
    }
}
