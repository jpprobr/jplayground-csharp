using System.Collections.Generic;

namespace Exemplo073.UsingHashing
{
    public static class Exemplo01_SetImplementation
    {
    }

    // Exemplo de uma implementação de um Conjunto (Set) 
    // Um "Set" armazena somente itens únicos
    // Note que para cada item adicionado é necessário percorrer todos os itens existentes
    // Por este motivo, em casos de grandes quantidades de itens pode gerar problemas de 
    // desempenho. O ideal então é verificar apenas um pequeno subgrupo 
    // em vez de todos os itens. Para isso é pode ser usado o "Hash Code" (ver exemplo 2)
    class Set<T>
    {
        private List<T> list = new List<T>();

        public void Insert(T item)
        {
            if (!Contains(item))
                list.Add(item);
        }

        public bool Contains(T item)
        {
            foreach (T member in list)
                if (member.Equals(item))
                    return true;

            return false;
        }
    }
}
