using System;
using System.Runtime.ExceptionServices;

namespace Exemplo052.HandlingExceptions
{
    /// <summary>
    /// Exemplo mostra uso do ExceptionDispatchInfo p/ capturar as exceções
    /// e preservar o stack trace original
    /// Pode ser usado até mesmo fora do bloco catch
    /// Também é útil p/ capturar uma exceção em uma thread e lançar em outra
    /// Ex.: Uma exceção lançada em uma thread async será captura e relançada
    /// na thread que está em execução
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionDispatchInfo possibleException = null;

            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
            {
                possibleException.Throw();
            }
        }
    }
}
