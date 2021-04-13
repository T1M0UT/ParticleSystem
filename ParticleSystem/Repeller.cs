using Helper;
using System;
using System.Drawing;

namespace ParticleSystem
{
    public class Repeller
    {
        public MyVector location;
        private float strength = 400;
        private int radius;

        public Repeller(MyVector location)
        {
            radius = 70;
            this.location = new MyVector(location);
        }

        public MyVector Repell(Particle particle)
        {
            MyVector dir = location - particle.location;
            float lengthSquared = dir.LengthSquared;
            dir.Normalize();
            float force = -1f * strength / lengthSquared;
            dir *= force;
            return dir;
        }

        public void Display(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.White),
                location.X - radius / 2, location.Y - radius / 2, radius, radius);
            graphics.DrawEllipse(new Pen(Color.DarkGray, 4f),
                location.X - radius / 2 - 1, location.Y - radius / 2 - 1, radius + 2, radius + 2);
            /*graphics.DrawLine(new Pen(Color.Black, 3f),
                location.X + radius / 3,
                location.Y,
                location.X - radius / 3,
                location.Y
            );*/
        }
    }
}
