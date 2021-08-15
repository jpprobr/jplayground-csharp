using System;

namespace Exemplo054.CreateTypes
{
    /*  O sistema de tipagem do C# contém três categorias diferentes: 
     *  ■ Tipos valor:       Contém o valor diretamente da variável
     *      - Exemplo de dar uma cópia de artigo de uma revista p/ um amigo
     *  ■ Tipos referência:  Contém a referência de um valor real
     *      - Exemplo de pessoas acessando a mesma URL
     *      
     *  ■ Tipos ponteiro:    Somente usado p/ casos com "unsafe code" (ponteiros aritméticos)
    */

    class Program
    {
        static void Main(string[] args)
        {
            // Enumerações
            ExemploEnumeracoes.ExecutarExemplo1();
            ExemploEnumeracoes.ExecutarExemplo2();


        }
    }
}
