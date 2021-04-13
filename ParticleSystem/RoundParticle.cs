using Helper;
using System.Drawing;

namespace ParticleSystem
{
    public class RoundParticle : Particle
    {
        public override MyVector location { get; set; }
        private MyVector velocity;
        private MyVector acceleration;
        private Color color;
        private int radius;
        private int alpha;

        public RoundParticle(MyVector location, Color color)
        {
            this.color = color;
            this.location = location - radius / 2;
            acceleration = new MyVector(0, 0);
            double sign = rand.Next(0, 2) == 0 ? 1 : -1;
            velocity = new MyVector();
            velocity.X = (float)(2 * sign * rand.NextDouble());
            velocity.Y = (float)(rand.NextDouble());
            alpha = 255;
            radius = rand.Next(14, 15);
        }

        public override void Update()
        {
            velocity += acceleration;
            location += velocity;
            acceleration *= 0f;
            alpha -= 1;
        }

        public override bool IsDead()
        {
            return alpha <= 1;
        }

        public override void Show(Graphics graphics)
        {
            graphics.FillEllipse(
                new SolidBrush(Color.FromArgb(alpha, color)),
                location.X,
                location.Y,
                radius, radius
            );
        }

        public override void ApplyForce(MyVector force)
        {
            acceleration += force;
        }
    }
}