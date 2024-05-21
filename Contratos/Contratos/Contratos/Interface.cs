using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Contratos
{
    // Representa una forma general.
    interface IShape
    {
    }

    // Representa un objeto con dimensiones.
    interface ISize : IShape
    {
        int Width { get; set; }
        int Height { get; set; }
    }

    // Representa un punto en un espacio bidimensional.
    interface IPoint : IShape
    {
        int X { get; set; }
        int Y { get; set; }
    }

    // Representa una línea, que es un punto con dimensiones.
    interface ILine : IPoint, ISize
    {
    }

    // Representa un cuadrado, que es una línea con ancho y alto iguales.
    interface ISquare : ILine
    {
        new int Width { get; set; }
        new int Height { get; set; }
    }

    class Square : ISquare
    {
        private int _size;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width
        {
            get { return _size; }
            set { _size = value; }
        }
        public int Height
        {
            get { return _size; }
            set { _size = value; }
        }
    }

    class Rectangle : ILine
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    class Line : ILine
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; } = 1; // default height for a horizontal line
    }

}
