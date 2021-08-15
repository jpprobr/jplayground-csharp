using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo063.ClassHierarchy
{
    public static class Exemplo4PrincipioLiskov
    {
        public static void ExecutarExemplo()
        {
            // Exemplo 1 - Instanciando um retângulo como um quadrado,
            Rectangle rectangle = new Square(width: 10, height: 5);
            Console.WriteLine("Area do quadrado é: {0}", rectangle.Area);
            // Resulta em 25 (área do quadarado => base e altura são iguais)
            // Deveria resultar em 50 (area do retangulo => base e altura são diferentes)
        }
    }

    class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public int Area
        {
            get
            {
                return Height * Width;
            }
        }
    }

    // Como no Quadrado a base é igual a altura
    // note que ao alterar um altera-se também o valor do outro
    class Square : Rectangle
    {
        public Square(int width, int height): base(width, height)
        {
            Width = width;
            Height = height;
        }

        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
