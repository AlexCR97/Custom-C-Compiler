namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableYaDeclarada : ErrorNeo
    {
        public ErrorVariableYaDeclarada(string identificador)
            : base($"Ya existe una variable declarada con el identificador '{identificador}'") { }
    }
}
