using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo063.ClassHierarchy
{
    public static class Exemplo3ClasseAbstrata
    {
    }


    abstract class Base2
    {
        public virtual void MethodWithImplementation() {/*Method with implementation*/}
        public abstract void AbstractMethod();
    }
    class Derived2 : Base2
    {
        public override void AbstractMethod() { }
    }
}
