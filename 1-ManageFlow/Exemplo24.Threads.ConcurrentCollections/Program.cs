using System;
using System.Collections.Concurrent;

namespace Exemplo24.Threads.ConcurrentCollections
{
    /// <summary>
    /// Exemplos com ConcurrentStack e ConcurrentQueue (Tipos de Filas)
    /// Last In, first out (LIFO) e First-In, first out (FIFO)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com Pilha
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);
            int result;
            
            // Tenta obter item da Pilha (Stack) / (LIFO)
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);
            
            stack.PushRange(new int[] { 1, 2, 3 });
            
            int[] values = new int[2];
            
            // Tenta obter obter 
            stack.TryPopRange(values);
            
            foreach (int i in values)
                Console.WriteLine(i);

            Console.WriteLine();
            Console.WriteLine();


            // Exemplo com Fila (Queue) / (FIFO)
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            
            queue.Enqueue(42);
            queue.Enqueue(57);

            int resultTestQueue;
            if (queue.TryDequeue(out resultTestQueue))
                Console.WriteLine("Dequeued: {0}", resultTestQueue);
        }
    }
}
