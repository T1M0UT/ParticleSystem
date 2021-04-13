using Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        private static readonly Random rand = new Random();
        private MyVector startVector;
        private Bitmap bitmap;
        private Graphics graphics;
        private Pen myPen;
        private List<ParticleSystem> particleSystems;
        private Repeller repeller;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            bitmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bitmap);
            myPen = new Pen(Color.White, 1f);

            startVector = new MyVector(Width / 2, 100);
            particleSystems = new List<ParticleSystem>();
            particleSystems.Add(new ParticleSystem(startVector));

            repeller = new Repeller(new MyVector(Width / 2 - 20,Height / 2));
        }

        private void Draw()
        {
            foreach(ParticleSystem ps in particleSystems)
            {
                if (ps.NumberOfParticles * particleSystems.Count > 200 * rand.Next(4, 10)) 
                {
                    int r = rand.Next(0, particleSystems.Count);
                    if (r == 0)
                        ps.AddParticle(Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
                    continue;
                }

                for (int i = 0; i < rand.Next(0,5); i++)
                {
                    ps.AddParticle(Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
                }
            }

            graphics.Clear(Color.Black);

            repeller.Display(graphics);
            MyVector gravity = new MyVector(0, 0.05f);
            foreach (ParticleSystem ps in particleSystems)
            {
                ps.ApplyForce(gravity);
                ps.ApplyRepeller(repeller);
                ps.Display(graphics);
            }
            
            picture.Image = bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            particleSystems.Add(new ParticleSystem(new MyVector(e.X, e.Y)));
        }
    }
}
