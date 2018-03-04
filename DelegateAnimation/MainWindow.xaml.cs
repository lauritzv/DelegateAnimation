using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DelegateAnimation
{
    public partial class MainWindow : Window
    {
        public delegate void TimeDelegate(int time);
        public event TimeDelegate moveIt;
        private System.Windows.Threading.DispatcherTimer timer;
        private int time = 0;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            populateSpace(500);
            startTimer(60000);
        }

        private void startTimer(int tickInterval)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(tickInterval);
            timer.Tick += (sender, eventargs) => moveIt(time++); //event on tick
            timer.Start();
        }

        private void populateSpace(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Planet p = new Planet(
                    random.Next(2048),                  //timeoffset
                    random.Next(1, 4),                  //orbitspeed
                    random.Next(50, 150),               //orbitradius
                    newEllipse(random.Next(20, 40)));   //shape + add to canvas

                moveIt += p.CalculatPos;
            }
        }

        private Ellipse newEllipse(int diameter)
        {
            Ellipse el = new Ellipse();
            el.Height = diameter;
            el.Width = diameter;
            el.Fill = new SolidColorBrush(Color.FromRgb( (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255) ));
            
            spaceCanvas.Children.Add(el);
            return el;
        }

    } //windowclass
}//ns