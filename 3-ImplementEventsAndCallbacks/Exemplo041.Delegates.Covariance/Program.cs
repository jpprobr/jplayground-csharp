using System;
using System.IO;

namespace Exemplo041.Delegates.Covariance
{
    /// <summary>
    /// Exemplo de delegate com covariância e contravariáncia
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // COVARIANCE: Torna possível que um métodos
            // tenha um tipo de retorno MAIS DERIVADO do que 
            // aqueles definidos no tipo delegate

            // CONTRAVARIANCE: Permite que um método tenha um
            // tipo de retorno MENOS DERIVADO do que 
            // aqueles definidos no tipo delegate

            var exemplo = new ExemploCovariance();
            exemplo.ExecutarExemplo();

            Console.WriteLine("\n");

            var exemplo2 = new ExemploCovariance();
            exemplo.ExecutarExemplo();
        }
    }

    /// <summary>
    /// Exemplo de contravariância
    /// Como o método DoSomething pode funcionar com um TextWriter, 
    /// certamente também pode funcionar com um StreamWriter. 
    /// Por causa da contravariância, você pode chamar o delegate 
    /// e passar uma instância do StreamWriter para o método DoSomething
    /// </summary>
    class ExemploCovariance
    {
        void DoSomething(TextWriter tw) { }

        public delegate void ContravarianceDel(StreamWriter tw);

        public void ExecutarExemplo()
        {
            ContravarianceDel del = DoSomething;           
        }
    }
}
