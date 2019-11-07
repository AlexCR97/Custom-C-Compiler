namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorTipoIncorrento : ErrorNeo
    {
        public ErrorTipoIncorrento(string identificador, string tipoEsperado)
            : base($"La variable '{identificador}' debe ser de tipo '{tipoEsperado}'") { }
    }
}
