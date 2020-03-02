﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Bullet : CollisionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;

        public Bullet(int Position)
            : base(new Point(0, Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            //g.FillEllipse(Brushes.Red, new Rectangle(_Position, _Size));
            //g.DrawEllipse(Pens.White, new Rectangle(_Position, _Size));
            var rect = Rect;
            g.FillEllipse(Brushes.Red, rect);
            g.DrawEllipse(Pens.White, rect);

        }
        public override void Update()
        {
            _Position = new Point(_Position.X + 10, _Position.Y);
        }
    }
}