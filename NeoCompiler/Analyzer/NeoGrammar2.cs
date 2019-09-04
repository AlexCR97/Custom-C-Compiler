using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace NeoCompiler.Analyzer
{
    class NeoGrammar2 : Grammar
    {
        public NeoGrammar2() : base()
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
            var relationalExpression = new NonTerminal("<relational-expresion>");
            var relationalOperator = new NonTerminal("<relational-operator>");
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
            var ifBlock = new NonTerminal("<if-block>");
            var elseStatement = new NonTerminal("<else>");
            var whenStatement = new NonTerminal("<when>");
            var whenBlock = new NonTerminal("<when-block>");
            var whenMatch = new NonTerminal("<when-match>");
            var whenMatchList = new NonTerminal("<when-match-list>");
            var whenDefault = new NonTerminal("<when-default>");
            var whileStatement = new NonTerminal("<while>");
            var whileBlock = new NonTerminal("<while-block>");
            var forStatement = new NonTerminal("<for>");
            var forParams = new NonTerminal("<for-params>");
            var forParam1 = new NonTerminal("<for-param-1>");
            var forParam2 = new NonTerminal("<for-param-2>");
            var forParam3 = new NonTerminal("<for-param-3>");
            var forBlock = new NonTerminal("<for-block>");
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
                functionDeclaration + start |
                functionDeclaration;

            functionDeclaration.Rule =
                functionType + id + parenthesisOpen_ + parenthesisClose_ + functionBlock;

            functionType.Rule =
                void_ |
                type;

            type.Rule =
                int_ |
                float_ |
                double_ |
                bool_ |
                string_;

            functionBlock.Rule =
                curlyBraceOpen_ + curlyBraceClose_ |
                curlyBraceOpen_ + statementList + curlyBraceClose_;

            // void main() {}
            // int max() {}
            // double peso() {}


            statementList.Rule =
                statement + semicolon_ + statementList |
                statement + semicolon_ |

                flowController + statementList |
                flowController;

            statement.Rule =
                varDeclaration;

            varDeclaration.Rule =
                type + varDeclarationList;

            varDeclarationList.Rule =
                id + comma_ + varDeclarationList |
                assignment + comma_ + varDeclarationList |
                assignment |
                id;

            assignment.Rule =
                id + equals_ + assignable;

            assignable.Rule =
                id |
                arithmeticExpression |
                bool_ |
                stringRegex |
                functionCall;

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

            flowController.Rule =
                ifStatement |
                whenStatement |
                whileStatement |
                forStatement;

            ifStatement.Rule =
                if_ + parenthesisOpen_ + relationalExpression + parenthesisClose_ + ifBlock |
                if_ + parenthesisOpen_ + relationalExpression + parenthesisClose_ + ifBlock + else_ + ifStatement |
                if_ + parenthesisOpen_ + relationalExpression + parenthesisClose_ + ifBlock + else_ + ifBlock;

            ifBlock.Rule =
                functionBlock |
                statement + semicolon_ |
                flowController;

            relationalExpression.Rule =
                assignable + relationalOperator + assignable;

            relationalOperator.Rule =
                doubleEquals_ |
                different_ |
                greaterEquals_ |
                greater_ |
                lessEquals_ |
                less_;

            whenStatement.Rule =
                when_ + parenthesisOpen_ + id + parenthesisClose_ + whenBlock;

            whenBlock.Rule =
                curlyBraceOpen_ + curlyBraceClose_ |
                curlyBraceOpen_ + whenMatchList + curlyBraceClose_;

            whenMatchList.Rule =
                whenMatch + whenMatchList |
                whenMatch |
                whenDefault;

            whenMatch.Rule =
                matches_ + assignableList + functionBlock;

            whenDefault.Rule =
                default_ + functionBlock;

            whileStatement.Rule =
                while_ + parenthesisOpen_ + relationalExpression + parenthesisClose_ + whileBlock |
                while_ + parenthesisOpen_ + id + parenthesisClose_ + whileBlock |
                while_ + parenthesisOpen_ + bool_ + parenthesisClose_ + whileBlock;

            whileBlock.Rule =
                functionBlock |
                statement + semicolon_ |
                flowController;

            forStatement.Rule =
                for_ + parenthesisOpen_ + forParams + parenthesisClose_ + forBlock;

            forParams.Rule =
                semicolon_ + semicolon_ |
                forParam1 + semicolon_ + semicolon_ |
                semicolon_ + forParam2 + semicolon_ |
                forParam1 + semicolon_ + forParam2 + semicolon_ |
                semicolon_ + semicolon_ + forParam3 |
                forParam1 + semicolon_ + semicolon_ + forParam3 |
                semicolon_ + forParam2 + semicolon_ + forParam3 |
                forParam1 + semicolon_ + forParam2 + semicolon_ + forParam3;

            forParam1.Rule =
                varDeclaration;

            forParam2.Rule =
                relationalExpression;

            forParam3.Rule =
                assignment;

            forBlock.Rule =
                functionBlock |
                statement + semicolon_ |
                flowController;

            functionCall.Rule =
                functionCallId + parenthesisOpen_ + parenthesisClose_ |
                functionCallId + parenthesisOpen_ + assignableList + parenthesisClose_;

            functionCallId.Rule =
                id + dot_ + functionCallId |
                id + doubleColon_ + functionCallId |
                id;

            #endregion

            #region Preferences
            Root = start;
            #endregion
        }
    }
}
