using System;

namespace Exemplo056.ExtendingExistingTypes
{
    /// <summary>
    /// Exemplo mostra uso de recursos p/ extender tipos existentes 
    /// Os "Extension Methods", permite adicionar novas capacidades a tipos existentes
    /// Precisam ser declarados em uma classe estática, non-nested e não genérica
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.Price = 100M;
            Console.WriteLine("Preço do Produto: {0}", p.Price);

            Calculator calc = new Calculator();
            Console.WriteLine("Preço após cálculo: {0}", calc.CalculateDiscount(p));
        }
    }


    /// <summary>
    /// Classe Produto
    /// </summary>
    public class Product
    {
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Classe de extensões
    /// </summary>
    public static class MyExtensions
    {
        // Note que esse método tem como seu primeiro argumento o "produto"
        // o uso do "this" faz deste método um "extension method"
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M;
        }
    }

    /// <summary>
    /// Classe Calculadora
    /// </summary>
    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }

    /*
        Lembre-se de que a diferença entre um método estático regular 
        e um método de extensão é a palavra-chave especial "this" p/ o primeiro argumento.
    */
}
