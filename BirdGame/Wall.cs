using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdGame
{
    public class Wall
    {
        int posX;
        public int PosX { get { return posX; } }
        int posY;
        public int PosY { get { return posY; } }
        int width;
        public int Width { get { return width; } }
        int height;
        public int Height { get { return height; } }
        int speed;
        int gap;
        int floor;

        public Wall(int posX, int posY, int width, int height, int speed, int gap, int floor)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.gap = gap;
            this.floor = floor;
        }

        public void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.DrawWall(pen, brush, posX, posY, width, height);
            graphics.DrawWall(pen, brush, posX, height + gap, width, floor - (posY + height + gap));
        }

        public bool Move()
        {
            posX -= speed;
            if (posX <= 0 - width)
            {
                return false;
            }
            return true;
        }

        public bool Hit(Bird bird)
        {
            if (bird.PosX + bird.Radius > posX && bird.PosX - bird.Radius < posX + width)           
            {
                if (bird.PosY - bird.Radius < height || bird.PosY + bird.Radius  > height + gap)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
