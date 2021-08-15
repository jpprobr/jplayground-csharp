using System.Collections.Generic;

namespace Exemplo073
{
    /* HASHING: - É o processo de pegar um grande conjunto de dados e mapeá-lo
                  para um conjunto menor de dados de comprimento fixo
                  Ex.: Mapear todos os nomes p/ um inteiro específico (uma chave).
                       Em vez de verificar o nome completo, seria necessário usar 
                       apenas valor inteiro (chave)
                 - Divide-se os dados em um conjunto de "baldes" (buckets).
                 Cada balde contém um subgrupo de todos os itens do conjunto        
         * 
         * Esta técnica é usada pelas classes "Hashtable" e "Dictionary" no .NET Framework
         * Hashes podem ser usados p/ verificar a integridade de um objeto 
         * por ex. saber se ele foi alterado (quando alterado seu "hash code" tb é alterado)
         * Ex.: Checksum p/ verificar arquivos baixados (mais comum no Linux)
    */
    public static class Exemplo02_SetImplementationUsingHashing
    {
    }

    // Exemplo de uma implementação de um Conjunto (Set) usando Hashing 
    class Set<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            /* Método GetHashCode é difinido na classe base "Object" e 
               pode ser usado p/ cada item. Este método deve retornar 
               um código do tipo inteiro que descreve um objeto em particular
               Como diretriz geral, a distribuição dos "hash codes" devem ser
              o mais aleatório possível
            */

            // Obtem o "balde" (busca pelo hash code do item atual)
            int bucket = GetBucket(item.GetHashCode());
            
            // Verifica se o "balde" contém o item informado
            if (Contains(item, bucket))
                return;

            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            
            buckets[bucket].Add(item);
        }

        private int GetBucket(int hashcode)
        {
            // Um ​​"Hash Code" pode ser negativo. Para garantir que você termine 
            // com um valor positivo, converta o valor para um "int não assinado". (uint)
            // O bloco "unchecked" garante que você possa converter 
            // um valor maior que "int" para um "int" com segurança.
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
            {
                // Note que o "for" percorre apenas o balde específico
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            }

            return false;
        }
    }
}
