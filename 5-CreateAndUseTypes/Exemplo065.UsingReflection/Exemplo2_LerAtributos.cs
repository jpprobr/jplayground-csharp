using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exemplo065.UsingReflection
{
    public static class Exemplo2_LerAtributos
    {
        public static void ExecutarExemplo()
        {
            // Ex 1 - Verifica se o atributo Serializable foi aplicado
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
            {

            }

            // Ex 2 - Obtem uma instancia de atributo específica
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)Attribute.GetCustomAttribute(
                    typeof(Person), typeof(ConditionalAttribute));

            string condition = conditionalAttribute.ConditionString; // returns CONDITION1
        }
    }
}
