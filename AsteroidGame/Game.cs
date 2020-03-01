using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        
        static Game()
        {

        }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0,0, Width, Height));

            var timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static VisualObject[] __GameObjectsSmall;
        public static void Load()
        {
            __GameObjects = new VisualObject[40];
            for (var i = 0; i < __GameObjects.Length / 2; i++)
                __GameObjects[i] = new VisualObject(
                new Point(600, i * 20),
                new Point(15 - i, 20 - i),
                new Size(20, 20));
            for (var i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
                __GameObjects[i] = new Star(
                new Point(600, (-15 + i) * 25),
                new Point( - i, 20 - i),
                20);
            __GameObjectsSmall = new VisualObject[20];
            for (var i = 0; i < __GameObjectsSmall.Length; i++)
                __GameObjectsSmall[i] = new Comet(
                new Point(900, (5 + i) * 25),
                new Point( - i, 20 - i),
                7);
            //var image = Properties.Resources.Star;
            //var image_object = new ImageObject(new Point(4, 7), new Point(-4, 6), new Size(20,20), image);
        }
        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50,50,200,200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100,50,70, 120));

            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);
            foreach (var visual_object in __GameObjectsSmall)
                visual_object.Draw(g);

            __Buffer.Render();
        }
        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object.Update();
            foreach (var visual_object in __GameObjectsSmall)
                visual_object.Update();
        }
    }
}
