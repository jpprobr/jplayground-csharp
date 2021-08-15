using System;
using System.Linq.Expressions;

namespace Exemplo066.LambdaExpressions
{
    // Lambda Expressions: Forma compacta de criar funções anônimas
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1 - Criando uma tipo "Func" com uma expressão lamda
            Func<int, int, int> somaFunc = (x, y) => x + y; // Forma de ler: "o x,y se torna x + y
            Console.WriteLine(somaFunc(2, 3));

            // Ex 2 - Criando um Hello World com uma árvore de expressão (expression tree)
            // Uma árvore de expressão descreve o código em vez de ser o próprio código
            // Uma árvore de expressão descreve a query
            // A expressão é criada primeiro com uma chamada p/ Console.Write e Console.WriteLine. 
            // Após a construção, a expressão é compilada em uma ação (pq não retorna nada) e é executada.
            BlockExpression blockExpr = Expression.Block(
             Expression.Call(
                 null,
                 typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                 Expression.Constant("Hello")
             ),
             Expression.Call(
                 null,
                 typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                 Expression.Constant("World!")
             )
            );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}
