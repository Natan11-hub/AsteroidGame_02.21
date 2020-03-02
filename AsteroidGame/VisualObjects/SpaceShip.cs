﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject
    {
        public SpaceShip(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size)
        {

        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            _Position = new Point(_Position.X + _Direction.X,
                _Position.Y + _Direction.Y);
            if (_Position.X < 0)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
        }
    }

}
