using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdGame
{
    public class Bird
    {
        int posY;
        public int PosY { get { return posY; } }
        int defaultY;
        int posX;
        public int PosX { get { return posX; } }

        int radius;
        public int Radius { get { return radius; } }

        int floor;
        int ceiling = 0; // Form top is always 0

        int gravity;
        int defaultGravity;

        public int Gravity { get { return gravity; } }

        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);

        public Bird(int posX, int posY, int radius, int floor, int gravity)
        {
            Debug.WriteLine(radius.ToString());
            this.posX = posX;
            defaultY = posY;
            this.posY = defaultY;
            this.radius = radius;
            this.floor = floor;
            defaultGravity = gravity;
            this.gravity = defaultGravity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawCircle(pen, brush, posX, posY, radius);
        }

        public void Fall()
        {
            if (posY + radius * 3 > floor)
            {
                posY = floor - radius * 3;
                gravity = 0;
            }
            posY += gravity;
            //Debug.WriteLine(posX + ", " + posY);
        }

        public void Fly()
        {
            if (posY - radius - 4 < ceiling)
            {
                posY = ceiling + radius + 4;
            }
            gravity = defaultGravity;
            posY -= gravity;
            //Debug.WriteLine(posX + ", " + posY);
        }
    }
}
