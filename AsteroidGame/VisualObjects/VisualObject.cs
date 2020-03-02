using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;
        //public Image image = Image.FromFile("star.jpg");
        double x = 100f;
        double y = 100f;

        RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
        GraphicsUnit units = GraphicsUnit.Pixel;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }
        public abstract void Draw(Graphics g);
        public void DrawIm(Image image, float x, float y, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            DrawIm(image, x, y, srcRect, units);
        }
        public virtual void Update()
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
