using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo054.CreateTypes
{
    /// <summary>
    /// Exemplo de struct
    /// </summary>
    public static class ExemploStruct
    {
        // Exemplo 1 - Struct podem conter métodos, campos, propriedades, 
        // construtores e outras funcionalidades, mas não pode declare um 
        // construtor sem parâmetros (vazio)
        // Também não pode usar a hierarquia de herança

        public struct Point
        {
            public int x, y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
    }
}
