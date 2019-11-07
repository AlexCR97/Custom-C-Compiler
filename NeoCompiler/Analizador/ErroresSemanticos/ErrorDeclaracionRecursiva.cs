namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorDeclaracionRecursiva : ErrorNeo
    {
        public ErrorDeclaracionRecursiva(string identificador)
            : base($"Declaracion recursiva de la variable '{identificador}'") { }
    }
}
