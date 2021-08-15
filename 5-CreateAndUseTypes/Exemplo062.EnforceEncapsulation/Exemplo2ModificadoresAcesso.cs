using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo062.EnforceEncapsulation
{
    class Exemplo2ModificadoresAcesso
    {
    }

    class Exemplo 
    {
        // Exemplo de propriedade auto-implementada 
        // (pois automaticamente cria os acessadores get e set)
        // Os acessadores get e set podem ter diferentes modificadores de acesso
        // (get ter um modificador de acesso e o set ter outro)
        public int Value1 { get; set; }

        public int Value2 { get; } // sem set (somente leitura)
    }


    // A Exemplo de Classe interna que só pode ser usada onde ela é declarada (mesmo assembly)    
    internal class MyInternalClass
    {
        // Este método público é restrito pelo seu encapsulamento
        // Somente quem tem acesso a classe interna pode chamar o método público
        public void MyMethod() { }
    }


    internal class MyInternalClass2
    {
        // Exemplo de como incluir um atributo p/ uso em outro assembly
        [assembly: InternalsVisibleTo("Friend1a")]
        public void MyMethod() { }
    }

}
