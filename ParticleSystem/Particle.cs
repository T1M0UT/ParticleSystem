using Helper;
using System;
using System.Drawing;

namespace ParticleSystem
{
    public abstract class Particle
    {
        public abstract MyVector location { get; set; }

        public static Random rand = new Random();

        public abstract void Update();

        public abstract bool IsDead();

        public abstract void Show(Graphics graphics);

        public abstract void ApplyForce(MyVector force);
    }
}
