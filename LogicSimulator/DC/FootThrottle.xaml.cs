using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpCircuit
{
    /// <summary>
    /// Interaction logic for FootThrottle.xaml
    /// </summary>
    public partial class FootThrottle : UserControl
    {
        SimCircuit simcircuit { get; set; }
        private double wiperZeroAngle { get; set; } = -90;
        private double wiperMaxAngle { get; set; } = -180;
        private double paddleZeroAngle { get; set; } = 11;
        private double paddleMaxAngle { get; set; } = 0;

        private double lastWiperAngle { get; set; }
        private double lastPaddleAngle { get; set; }

        private double _position;
        public double position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = (value < 0 ? 0 : value);
                _position = (value > 1 ? 1 : _position);

                double angle = wiperZeroAngle + ((wiperMaxAngle - wiperZeroAngle) * _position);
                if (angle != lastWiperAngle)
                {
                    RotatePot(angle);
                    lastWiperAngle = angle;
                    foreach (KeyValuePair<string, NetElement> entry in simcircuit.elements)
                    {
                        NetElement el = entry.Value;
                        if (el.location == "DC" && el.tag == "POTFT")
                        {

                            var x = el.simElement.GetType();
                            if (el.simElement.GetType() == typeof(Potentiometer))
                            {
                                Potentiometer pot = (Potentiometer)el.simElement;
                                pot.position = _position;
                            }
                        }
                    }
                }

                angle = paddleZeroAngle + ((paddleMaxAngle - paddleZeroAngle) * _position);
                if (angle != lastPaddleAngle)
                {
                    RotatePaddle(angle);
                    lastPaddleAngle = angle;
                }
            }
        }

        public FootThrottle()
        {
            InitializeComponent();
        }

        public void configureFT(SimCircuit sc)
        {

            simcircuit = sc;

            lastWiperAngle =  wiperMaxAngle;
            lastPaddleAngle = paddleMaxAngle;
            position = 0;

            simcircuit.setNode(cp01, "DC", "PFT", "1", "FT", "1");
            simcircuit.setNode(cp02, "DC", "PFT", "2", "FT", "2");
            simcircuit.setNode(cp03, "DC", "PFT", "3", "FT", "3");

            PreviewMouseWheel += OnPreviewMouseWheel;
        }

        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta > 0)
                {
                    position -= 0.1;
                }
                if (e.Delta < 0)
                {
                    position += 0.1;
                }

                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

        }

        public void RotatePot(double angle)
        {
            RotateTransform rotateTransform = new RotateTransform(angle);
            PotWiper.RenderTransform = rotateTransform;
        }

        public void RotatePaddle(double angle)
        {
            RotateTransform rotateTransform = new RotateTransform(angle);
            Paddle.RenderTransform = rotateTransform;
        }
    }
}
