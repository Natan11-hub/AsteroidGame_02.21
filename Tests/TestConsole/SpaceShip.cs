using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class SpaceShip
    {
        private Vector2D _Position = new Vector2D(5, 7);

        public SpaceShip()
        {

        }

        public SpaceShip(Vector2D Position)
        {
            _Position = Position;
        }
    }

    struct Vector2D
    {
        private double _X;
        private double _Y;

        public double X { get; set; }
        public double Y { get; set; }
        public double Length => Math.Sqrt(X * X + Y * Y);

        public Vector2D(double X, double Y)
        {
            _X = X;
            _Y = Y;
        }
    }
}
