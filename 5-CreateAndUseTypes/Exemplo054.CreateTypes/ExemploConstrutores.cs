using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo054.CreateTypes
{
    class ExemploConstrutores
    {
    }


    /// <summary>
    /// Classe com vários construtores encadeados
    /// 
    /// </summary>
    class ConstructorChaining
    {
        private int _p;

        /// <summary>
        /// Construtor vazio por default chama o outro construtor 
        /// com o valor default 3 para "p"
        /// </summary>
        public ConstructorChaining() : this(3) { }

        public ConstructorChaining(int p)
        {
            this._p = p;
        }
    }
}
