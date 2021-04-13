using Helper;
using System.Drawing;

namespace ParticleSystem
{
    public class SquareParticle : RoundParticle
    {
        private int radius;
        private Color color;
        
        public SquareParticle(MyVector location, Color color) : base(location, color)
        {
            this.color = color;
            radius = rand.Next(1, 12);
        }

        public override void Show(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(color),
                location.X - radius / 2,
                location.Y - radius / 2,
                radius, radius);
        }
    }
}