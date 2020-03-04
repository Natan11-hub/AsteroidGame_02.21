using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Heal : ImageObject, ICollision 
    {
        public int Power { get; set; } = 30;
        public Heal(Point Position, Point Direction, int ImageSize) 
            : base(Position, Direction,new Size(ImageSize, ImageSize), Properties.Resources.Heal)
        {
        }

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + _Direction.X,
                _Position.Y + _Direction.Y);
            if (_Position.X < 0)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);
            if (_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);
        }

    }
}
