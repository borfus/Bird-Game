using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BirdGame
{
    public partial class formBirdGame : Form
    {
        Graphics graphics;
        Bird bird;
        int posX;
        int posY;
        int radius;
        int gravity;

        // Wall settings
        Queue<Wall> walls = new Queue<Wall>();
        int width = 50;
        int gap = 150;
        int speed = 3;

        // Misc
        Form form;
        Random random;
        int count = 0;

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);

        public formBirdGame()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            form = this;

            // Starting location as well as size and gravity
            posX = 150 + radius;
            posY = form.Height / 2 - radius;
            radius = 20;
            gravity = 6;

            bird = new Bird(posX, posY, radius, this.Bottom, gravity);
            form.Refresh();
            
            timerLoop.Enabled = true;
            timerLoop.Start();
            bckWorker.RunWorkerAsync();
        }

        private void formBirdGame_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            bird.Draw(graphics);
            foreach (Wall wall in walls)
            {
                wall.Draw(graphics);
            }
        }

        private void timerLoop_Tick(object sender, EventArgs e)
        {
            random = new Random();
            if (count % 100 == 0)
            {
                walls.Enqueue(new Wall(form.Width + width, 0, width, random.Next(0, form.Height - gap), speed, gap, form.Height));
            }
            foreach (Wall wall in walls)
            {
                wall.Move();
                if (wall.Hit(bird))
                {
                    Application.Restart();
                }
            }

            if (walls.Count > 5)
            {
                walls.Dequeue();
            }

            ++count;
            if (count == int.MaxValue)
            {
                count = 0;
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bird.Fall();

                // While holding space
                while (GetAsyncKeyState(32) < 0)
                {
                    bird.Fly();
                    Thread.Sleep(12);
                }
                Thread.Sleep(12);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            form.Refresh();
        }
    }
}

