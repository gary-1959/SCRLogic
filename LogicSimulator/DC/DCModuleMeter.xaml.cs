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
    /// Interaction logic for DCModuleMeter.xaml
    /// </summary>
    public partial class DCModuleMeter : UserControl
    {
        const int startWidth = 130;
        const int startHeight = 60;
        public int monitorPin { get; set; }
        private double xmin { get; set; }
        private double xmax { get; set; }
        private double maxVoltage { get; set; }
        private double y1 { get; set; }
        private double y2 { get; set; }
        private double span { get; set; }
        private string thisSCR { get; set; }
        private DCModule thisModule { get; set; }

        public DCModuleMeter()
        {
            InitializeComponent();
        
            monitorPin = 0;
            xmin = 18;
            xmax = 116;
            maxVoltage = 15;
            y1 = 7;
            y2 = 43;

            MeterPointer.X1 = xmin;
            MeterPointer.X2 = xmin;
            MeterPointer.Y1 = y1;
            MeterPointer.Y2 = y2;

            span = (xmax - xmin);
        }

        public void configureMeter(int scrNum, DCModule parent)
        {
            string thisSCR = "SCR" + scrNum.ToString();
            thisModule = parent;

            Program.simMain.TimerComplete += dispatcherTimer_Tick;

            /*System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();    */
        }
        double rampPoint = 0;
        public void setPointer(double p)
        {

            if (ActualWidth > 0)
            {
               // pid.SetPoint = p;
               // double cv = pid.ControlVariable();

                if (p != rampPoint)
                {
                    rampPoint += ((p - rampPoint) / 2);
                }

                MeterPointer.X1 = MeterPointer.X2 = (xmin + (span * rampPoint)) * ActualWidth / startWidth;
                MeterPointer.Y1 = y1 * ActualHeight / startHeight;
                MeterPointer.Y2 = y2 * ActualHeight / startHeight;
            }
            
        }


        bool timerLock = false;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!timerLock)
            {
                timerLock = true;
                bool pointerSet = false;
                if (monitorPin != 0)
                {

                    string lZ = monitorPin.ToString("D3");
                    CircuitPoint cp = thisModule.FindName("cpDCM_" + lZ) as CircuitPoint;
                    if (cp != null)
                    {
                        if (cp.node != null)
                        {
                            if (cp.node.parent != null)
                            {
                                if (cp.node.parent.simElement != null)
                                {
                                    setPointer(Math.Abs(cp.node.parent.simElement.getLeadVoltage(0)) / maxVoltage);
                                    pointerSet = true;
                                }
                            }
                        }

                    }
                }
                if (!pointerSet) setPointer(0);
                timerLock = false;
            }

        }
    }
}
