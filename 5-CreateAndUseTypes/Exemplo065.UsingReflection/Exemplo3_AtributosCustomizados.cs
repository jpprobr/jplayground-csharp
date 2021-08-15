using System;
using Xunit;

namespace Exemplo065.UsingReflection
{
    public static class Exemplo3_AtributosCustomizados
    {

    }

    /*
    public class CategoryAttribute : TraitAttribute
    {
        public CategoryAttribute(string value) : base("Category", value)
        { 
        
        }
    }

    public class UnitTestAttribute : CategoryAttribute
    {
        public UnitTestAttribute() : base("Unit Test")
        {

        }
    }
    */

    // A definição do uso de um atributo é feita aplicando um atributo. 
    // Podemos combinar quantos destinos quiser. 
    // Pdemos também usar o parâmetro AllowMultiple para habilitar várias instâncias 
    // de um atributo para um único tipo

    // Ex 1 - declaração de um "Custom Attribute"
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MyMultipleUsageAttribute : Attribute 
    { 

    }

    // Ex 2 - declaração de um "Custom Attribute" completo (c/ construtor e propriedade)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class CompleteCustomAttribute : Attribute
    {
        public CompleteCustomAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
