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
    /// Interaction logic for MotorTabControl.xaml
    /// </summary>
    public partial class MotorTabControl : UserControl
    {
        public SimCircuit simcircuit { get; set; }

        public MotorTabControl()
        {
            InitializeComponent();

            Program.ScrollZoomHandler szMP1A = new Program.ScrollZoomHandler(scrollViewerMP1A, sliderMP1A, gridMP1A, scaleTransformMP1A, 1);
            Program.ScrollZoomHandler szMP1B = new Program.ScrollZoomHandler(scrollViewerMP1B, sliderMP1B, gridMP1B, scaleTransformMP1B, 1);
            Program.ScrollZoomHandler szMP2A = new Program.ScrollZoomHandler(scrollViewerMP2A, sliderMP2A, gridMP2A, scaleTransformMP2A, 1);
            Program.ScrollZoomHandler szMP2B = new Program.ScrollZoomHandler(scrollViewerMP2B, sliderMP2B, gridMP2B, scaleTransformMP2B, 1);
            Program.ScrollZoomHandler szDWA = new Program.ScrollZoomHandler(scrollViewerDWA, sliderDWA, gridDWA, scaleTransformDWA, 1);
            Program.ScrollZoomHandler svDWB = new Program.ScrollZoomHandler(scrollViewerDWB, sliderDWB, gridDWB, scaleTransformDWB, 1);
            Program.ScrollZoomHandler szRT = new Program.ScrollZoomHandler(scrollViewerRT, sliderRT, gridRT, scaleTransformRT, 1);
        }

        public void configureBoxes()
        {
            // TODO: for quick debugging hide MCC
            MP1A.configureBox("MP1A", Program.mainWindow.mccTabControl.MCCControl.B1, "SMP1RO", Program.mainWindow.mccTabControl.MCCControl.B3);
            MP1B.configureBox("MP1B", Program.mainWindow.mccTabControl.MCCControl.B2, "SMP1CO", Program.mainWindow.mccTabControl.MCCControl.B4);

            MP2A.configureBox("MP2A", Program.mainWindow.mccTabControl.MCCControl.C1, "SMP2RO", Program.mainWindow.mccTabControl.MCCControl.C3);
            MP2B.configureBox("MP2B", Program.mainWindow.mccTabControl.MCCControl.C2, "SMP2CO", Program.mainWindow.mccTabControl.MCCControl.C4);

            RT.configureBox("RT", Program.mainWindow.mccTabControl.MCCControl.A1, null, null);

            DWA.configureBox("DWA", Program.mainWindow.mccTabControl.MCCControl.A2, null, null);
            DWB.configureBox("DWB", Program.mainWindow.mccTabControl.MCCControl.A3, null, null);
        }

    }
}
