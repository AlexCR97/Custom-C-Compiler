﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCompiler.Analizador.ErroresSemanticos
{
    class ErrorDeclaracionRecursiva : ErrorNeo
    {
        public ErrorDeclaracionRecursiva(string identificador)
            : base($"Declaracion recursiva de la variable '{identificador}'") { }
    }
}
