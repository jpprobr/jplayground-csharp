using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo067.Manage_The_Object_Life_Cycle
{
    /* WeakReference (referencias fracas) não contém uma referência real p/ um item no HEAP 
     * p/ que não possa ser coletado como lixo, mas quando a coleta de lixo ainda não ocorreu
     * ainda podemos acessar o item por meio dele (Weak reference)
     *  (IDEIA SIMILAR A DE UM CACHE P/ REUTILIZAR DADOS)
     * 
     * Ex.: As vezes precisamos trabalhar com objetos grandes que exigem muito tempo 
     * para serem criados, por ex. um BD. Seria bom se pudéssemos manter os itens na memória,
     * no entanto, isso aumenta a carga de memória do app e talvez a lista não seja mais necessária.
     * Por isso o GC pode limpar alguns desses objetos, porém caso a coleta anida não tenha ocorrido,
     * seria bom a possibilidade de reutilizar a lista criada. 
    */ 

    public static class Exemplo4_WeekReferences
    {

        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            // Uncommenting this line will make data. Target null
            // Libera memória que o WeakReference aponta
            // GC.Collect(); 
            result = GetData();
        }

        // Verifica se WeakReference contém dados
        // Se não tiver, os dados são carregados novamente e salvos no WeakReference
        // Se 
        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }
            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }


        // Apenas simula um método p/ carregar uma lista grande
        private static object LoadLargeList()
        {
            return new object();
        }
    }
    
  
}
