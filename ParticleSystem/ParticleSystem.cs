using Helper;
using System.Collections.Generic;
using System.Drawing;

namespace ParticleSystem
{
    public class ParticleSystem
    {
        private List<Particle> particles;
        public MyVector origin;

        public ParticleSystem(MyVector origin)
        {
            this.origin = new MyVector(origin);
            particles = new List<Particle>();
        }

        public int NumberOfParticles { get => particles.Count; }

        public void Display(Graphics graphics)
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Update();
                particles[i].Show(graphics);
                if (particles[i].IsDead()) particles.RemoveAt(i);
                //if (particles.Count > 1000) particles.RemoveAt(i);
            }
        }

        public void AddParticle(Color color)
        {
            particles.Add(new RoundParticle(origin, color));
        }

        public void ApplyForce(MyVector force)
        {
            foreach (var particle in particles)
            {
                particle.ApplyForce(force);
            }
        }

        public void ApplyRepeller(Repeller repeller)
        {
            foreach(var particle in particles)
            {
                MyVector force = repeller.Repell(particle);
                particle.ApplyForce(force);
            }
        }
    }
}
