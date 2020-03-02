using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class StarIm : ImageObject
    {
        public StarIm(Point Position, Point Direction, int ImageSize) :
            base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.Star)
        {

        }
    }
}
