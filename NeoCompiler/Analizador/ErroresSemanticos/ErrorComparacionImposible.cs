namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorComparacionImposible : ErrorNeo
    {
        public ErrorComparacionImposible(string id1, string tipo1, string id2, string tipo2)
            : base($"No es posible comparar el tipo '{tipo1}' ('{id1}') con el tipo '{tipo2}' ('{id2}')") { }
    }
}
