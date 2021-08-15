using System;

namespace Exemplo058.Boxing_And_Unboxing
{
    /*
        BOXING:     É o processo de pegar um value type (tipo por valor), 
                    colocá-lo dentro de um novo objeto na pilha (heap) e armazenar 
                    uma referência para ele na stack.
        
        UNBOXING:   É o processo inverso. Pega o item da pilha (heap) 
                    e retorna um value type (tipo por valor) que contém 
                    o valor da pilha

        Existem algumas implicações de desempenho em cada operação de "boxing" e "unboxing". 
        Ao usar as coleções não genéricas para armazenar um "value type", 
        ocorrem muitas dessas operações, as quais podem prejudicar o desempenho; 
        no entanto, com o suporte genérico no .NET Framework, isso é um problema menor, 
        pois é possível armazenar "value types" em uma coleção sem fazer "boxing".
    */

    class Program
    {
        static void Main(string[] args)
        {            
            int i = 42;         // cria value type "i"
            object o = i;       // objeto recebe o value type "i"
            int x = (int)o;     // pega objeto "o" e 

            // Chamar o GetType sempre coloca o value type em um "box" (pq ele é objeto)
            // porque o GetType é definido apenas em um objeto e não pode ser substituído.
            var resultGetType = o.GetType();
            Console.WriteLine("resultGetType: {0}", resultGetType.Name);

            // Algo que pode causar surpresa é que um "value type" é "boxed" (encaixotado)
            // quando usamos como Interface
            IFormattable teste = 3;
            Console.WriteLine("teste: {0}", teste);
        }
    }
}
