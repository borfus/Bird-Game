using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BirdGame
{
    public static class GraphicsExtensions
    {
        // Draw and fill circle (bird) or wall in one extended method

        public static void DrawCircle(this Graphics g, Pen pen, Brush brush, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        public static void DrawWall(this Graphics g, Pen pen, Brush brush, float posX, float posY, float width, float height)
        {
            g.DrawRectangle(pen, posX, posY, width, height);
            g.FillRectangle(brush, posX, posY, width, height);
        }
    }
}
