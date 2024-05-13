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
    /// Interaction logic for PanelMeter.xaml
    /// </summary>
    public partial class PanelMeter : UserControl
    {
        private CircuitElement terminalElement = null;

        public PanelMeter()
        {
            InitializeComponent();
        }

        public void configureMeter(string scale, string location, string tag)
        {
            CircuitPoint cp = new CircuitPoint();
            Program.simMain.setNode(cp, location, tag, "[+]", tag, "[+]");
            if (cp.node != null)
            {
                if (cp.node.parent != null)
                {
                    if (cp.node.parent.simElement != null)
                    {
                        terminalElement = cp.node.parent.simElement;
                    }
                }

            }
            Scale.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scale)); //PANEL-METER-SCALE-1000VDC.png

            Program.TickComplete += tickCompleteHandler;
        }

        public void setPointer()
        {

            if (ActualWidth > 0)
            {
                double terminalVolts = 0;
                if (terminalElement != null) terminalVolts = Math.Abs(terminalElement.getVoltageDelta());

                double deflection = terminalVolts / 0.050;
                double aOffset = 50;
                double angle = aOffset + (deflection * (360 - (2 * aOffset)));

                RotateTransform rotateTransform = new RotateTransform(angle);
                Pointer.RenderTransform = rotateTransform;
            }
        }

        public void tickCompleteHandler(object sender, EventArgs e)
        {
            setPointer();
        }
    }
}
