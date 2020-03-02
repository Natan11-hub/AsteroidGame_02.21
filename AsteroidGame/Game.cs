using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame
{
    static class Game
    {
        private const int __FrameTimeout = 10;

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
            if (Width > 1000 || Height > 1000 || Width < 0 || Height < 0)
                throw new ArgumentOutOfRangeException("Нарушен размер приложения!");

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0,0, Width, Height));

            var timer = new Timer { Interval = __FrameTimeout };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        //private static VisualObject[] __GameObjectsSmall;
        public static void Load()
        {
            var game_objects = new List<VisualObject>();
            var rnd = new Random();

            const int stars_count = 160;
            const int stars_size = 5;
            const int stars_max_speed = 20;


            for (var i = 0; i < stars_count; i++)
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, stars_max_speed)),
                    stars_size));

            const int ellipses_count = 20;
            const int ellipses_size_x = 20;
            const int ellipses_size_y = 20;

            for (var i = 0; i < ellipses_count; i++)
                game_objects.Add(new EllipseObject(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, stars_max_speed)),
                    new Size(ellipses_size_x, ellipses_size_y)));

            const int starIm_count = 10;
            const int starIm_size = 45;
            const int starIm_max_speed = 20;


            for (var i = 0; i < starIm_count; i++)
                game_objects.Add(new StarIm(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, starIm_max_speed)),
                    starIm_size));

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);
        }
        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50,50,200,200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100,50,70, 120));

            foreach (var visual_object in __GameObjects)
                visual_object?.Draw(g);

            __Bullet.Draw(g);
            //foreach (var visual_object in __GameObjectsSmall)
            //    visual_object.Draw(g);

            __Buffer.Render();
        }
        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object?.Update();

            __Bullet.Update();
            if (__Bullet.Position.X > Width)
                __Bullet = new Bullet(new Random().Next(Width));
            //foreach (var visual_object in __GameObjectsSmall)
            //    visual_object.Update();
            for(var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (__Bullet.CheckCollision(collision_object))
                    {
                        __Bullet = new Bullet(new Random().Next(Width));
                        __GameObjects[i] = null;
                        MessageBox.Show("Объект уничтожен!", "Столконовение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
