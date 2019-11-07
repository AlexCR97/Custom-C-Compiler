namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableSinDeclarar : ErrorNeo
    {
        public ErrorVariableSinDeclarar(string identificador)
            : base($"No existe una variable '{identificador}' declarada") { }
    }
}
