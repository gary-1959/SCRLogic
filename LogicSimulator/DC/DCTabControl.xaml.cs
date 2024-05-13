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
    /// Interaction logic for DCTabControl.xaml
    /// </summary>
    public partial class DCTabControl : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public DCTabControl()
        {
            InitializeComponent();
        }

        public void configureDC(SimCircuit sc)
        {
            simcircuit = sc;           

            Program.ScrollZoomHandler szOpen = new Program.ScrollZoomHandler(scrollViewerOpen, sliderOpen, gridOpen, scaleTransformOpen, 1.0);
            Program.ScrollZoomHandler szDoor = new Program.ScrollZoomHandler(scrollViewerDoor, sliderDoor, gridDoor, scaleTransformDoor, 1.0);
            Program.ScrollZoomHandler szClosed = new Program.ScrollZoomHandler(scrollViewerClosed, sliderClosed, gridClosed, scaleTransformClosed, 1.0);
            Program.ScrollZoomHandler szFT= new Program.ScrollZoomHandler(scrollViewerFT, sliderFT, gridFT, scaleTransformFT, 1.0);

            DCClosedControl.configureDC(simcircuit);
            DCOPenControl.configureDC(simcircuit);
            DCDoorControl.configureDC(simcircuit);
            DCFTControl.configureFT(simcircuit);

            #region HANDWHEELS
            Program.HandwheelHandler mp1 = new Program.HandwheelHandler(simcircuit, DCClosedControl.MP1Handwheel, DCDoorControl.MP1PotAssembly.Handwheel, "DC", "POT1");
            mp1.microSwitches.Add(new Program.SwitchContact(simcircuit, "DC", "S7A", false));
            Program.HandwheelHandler mp2 = new Program.HandwheelHandler(simcircuit, DCClosedControl.MP2Handwheel, DCDoorControl.MP2PotAssembly.Handwheel, "DC", "POT2");
            mp2.microSwitches.Add(new Program.SwitchContact(simcircuit, "DC", "S8A", false));
            Program.HandwheelHandler dw = new Program.HandwheelHandler(simcircuit, DCClosedControl.DWHandwheel, DCDoorControl.DWPotAssembly.Handwheel, "DC", "POT3");
            dw.microSwitches.Add(new Program.SwitchContact(simcircuit, "DC", "S9A", false));
            dw.microSwitches.Add(new Program.SwitchContact(simcircuit, "DC", "S9B", true));
            Program.HandwheelHandler rt = new Program.HandwheelHandler(simcircuit, DCClosedControl.RTHandwheel, DCDoorControl.RTPotAssembly.Handwheel, "DC", "POT4");
            Program.HandwheelHandler rtIlim = new Program.HandwheelHandler(simcircuit, DCClosedControl.RTILim, null, "DC", "POT5");
            rtIlim.clickOn = false;
            #endregion
           
        }

    }
}
