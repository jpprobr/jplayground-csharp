using System;

namespace Exemplo055.GenericTypes
{
    /// <summary>
    /// Exemplo com versão simplificada do suporte ao tipo "Generic Nullable" do .NET 
    /// Generic Nullable<T>
    /// Com isso, ao invés de usar um Nullable Type para cada tipo por valor,
    /// há somente uma implementação que um tipo genérico passado por parâmetro
    /// Dessa forma, os genéricos podem ser usados ​​para promover a reutilização de código.
    /// Normalmente os tipos por valor precisa ser "boxed" e para serem usados
    /// em uma coleção não genérica. Usando "generics", podemos evitar a queda
    /// de desempenho ao fazer "boxing" e "unboxing" 
    /// 
    /// Os tipos por referência por natureza já têm a opção de serem nulos. (Nullables)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    struct Nullable<T> where T : struct
    {
        private bool hasValue;
        private T value;

        public Nullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public bool HasValue { get { return this.hasValue; } }

        public T Value
        {
            get
            {
                if (!this.HasValue) 
                    throw new ArgumentException();

                return this.value;
            }
        }

        public T GetValueOrDefault()
        {
            return this.value;
        }
    }
}
