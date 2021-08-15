using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo062.EnforceEncapsulation
{
    public static class Exemplo1ProtecaoAcessoHierarquiaHeranca
    {
        public static void ExecutarExemplo()
        {

        }
    }

    public class Base
    {
        private int _privateField = 42;
        protected int _protectedField = 42;

        private void MyPrivateMethod() { }
        protected void MyProtectedMethod() { }
    }


    public class Derived : Base
    {
        public void MyDerivedMethod()
        {
            // _privateField = 41;  // Not OK, this will generate a compile error
            _protectedField = 43;   // OK, protected fields can be accessed
                                    // MyPrivateMethod(); // Not OK, this will generate a compile error
            MyProtectedMethod();    // OK, protected methods can be accessed
        }
    }


  
}
