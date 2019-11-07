namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorVariableSinInicializar : ErrorNeo
    {
        public ErrorVariableSinInicializar(string identificador)
            : base($"La variable '{identificador}' no ha sido inicializada") { }
    }
}
