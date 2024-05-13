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
    /// Interaction logic for SCRTabControl.xaml
    /// </summary>
    public partial class SCRTabControl : UserControl
    {
        public SimCircuit simcircuit { get; set; }

        public SCRTabControl()
        {
            InitializeComponent();

            Program.ScrollZoomHandler szOpen = new Program.ScrollZoomHandler(scrollViewerOpen, sliderOpen, gridOpen, scaleTransformOpen, 0.25);
            Program.ScrollZoomHandler szDoor = new Program.ScrollZoomHandler(scrollViewerDoor, sliderDoor, gridDoor, scaleTransformDoor, 0.25);
            Program.ScrollZoomHandler szClosed = new Program.ScrollZoomHandler(scrollViewerClosed, sliderClosed, gridClosed, scaleTransformClosed,0.25);
            Program.ScrollZoomHandler szRelay = new Program.ScrollZoomHandler(scrollViewerRelay, sliderRelay, gridRelay, scaleTransformRelay, 1.0);
            
        }
        public List<Program.CBHandler> cbHandlers;


        public void configureSCR(SimCircuit sc, int scrNum)
        {
            simcircuit = sc;
            string scr = "SCR" + scrNum.ToString();
            SCRClosedControl.configureSCR(simcircuit, scrNum);
            SCROpenControl.configureSCR(simcircuit, scrNum);
            SCRDoorControl.configureSCR(simcircuit, scrNum, SCRClosedControl.Voltmeter, SCRClosedControl.Ammeter);
            SCRRelayControl.configureSCR(scrNum);

            // find uv coil

            sc.CBHandlers.Add(new Program.CBHandler(sc, SCRClosedControl.cbControl, SCROpenControl.cbControl, scr));

        }

    }
}
