using System;
using System.Data.Entity.Core.Objects;

namespace Exemplo062.EnforceEncapsulation
{
    /*
     A implementação de uma interface explícita significa que um elemento 
     do tipo Interface só pode ser acessado quando usamos a interface diretamente
    */

    public static class Exemplo3InterfaceExplicita
    {
        public static void ExecutarExemplo()
        {
            // Quando temos uma instancia de Implementation não podemos acessar o MyMethod(),
            // mas quando lançamos o Implementation p/ a IInterfaceA
            // Dessa forma a implementação explícita pode ser usada p/ ocultar
            // membros de uma classe para "uso" externos

            // SITUAÇÃO 1
            // Note que a instancia ex1 não consegue acessar o MyMethod() (ocultou da instancia)
            var ex1 = new Implementation();

            IInterfaceA interfaceA = new Implementation();
            interfaceA.MyMethod();


            // SITUAÇÃO 2
            ILeft left = new MoveableOject();
            left.Move();
            
            IRight right = new MoveableOject();
            right.Move();
        }
    }

    // SITUAÇÃO 1 - Oculta
    // Classe Implementation implementa a Interface A explicitamente.
    interface IInterfaceA
    {
        void MyMethod();
    }

    class Implementation : IInterfaceA
    {
        void IInterfaceA.MyMethod()
        {
            Console.WriteLine("Executando método da Interface A");
        }
    }


    // SITUAÇÃO 2
    // Quando uma classe implementa 2 interfaces que contém assinaturas de método
    // duplicadas mas deseja uma implementação diferente para ambas
    // Ao implementar implicitamente essas 2 interfaces, apenas um método existe na implementação 
    // (ver caso 1)
    // Com a implementação explícita da Interface, ambas as interfaces tem a sua própria implementação
    // (ver caso 2)

    // CASO 1 - Exemplo de Interfaces e classe usando implementação IMPLÍCITA da Interface
    interface ITeste1
    {
        void Testar();
    }
    interface ITeste2
    {
        void Testar();
    }

    class Teste : ITeste1, ITeste2
    {
        public void Testar()
        {
            Console.WriteLine("Executando método Testar...");
        }
    }

    // CASO 2
    // Exemplo de Interfaces e classe usando implementação EXPLÍCITA da Interface
    interface ILeft
    {
        void Move();
    }
    interface IRight
    {
        void Move();
    }

    class MoveableOject : ILeft, IRight
    {   // Note que ambas podem ter implementações independentes para cada interface
        void ILeft.Move()
        {
            Console.WriteLine("Executando método Move da Interface ILeft...");
        }
        void IRight.Move()
        {
            Console.WriteLine("Executando método Move da Interface ILeft...");
        }
    }
}
