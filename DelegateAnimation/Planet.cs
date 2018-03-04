using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DelegateAnimation
{
    class Planet
    {
        public int timeOffset       { get; private set; }
        public int orbitSpeed       { get; private set; }
        public int orbitalRadius    { get; private set; }
        private Canvas c;
        private Ellipse ell;
        public Ellipse shape
        {
            get { return ell; }
            set { c = (Canvas)value.Parent; ell = value; }
        }
        
        public Planet(int timeOffset, int orbitSpeed, int orbitalRadius, Ellipse shape)
        {
            this.timeOffset = timeOffset;
            this.orbitSpeed = orbitSpeed;
            this.orbitalRadius = orbitalRadius;
            this.shape = shape;
        }

        public void CalculatPos(int time)
        {
            if (c != null)
            {
                time += timeOffset;
                
                int posx = (int)(Math.Cos(time * orbitSpeed * Math.PI / 180) * orbitalRadius);
                int posy = (int)(Math.Sin(time * orbitSpeed * Math.PI / 180) * orbitalRadius);
                
                Canvas.SetLeft(shape, posx + c.Width / 2 - shape.Width / 2);
                Canvas.SetTop(shape, posy + c.Height / 2 - shape.Width / 2);
            }
        }

    } //class
} //ns
