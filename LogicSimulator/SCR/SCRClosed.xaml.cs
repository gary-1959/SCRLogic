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
    /// Interaction logic for SCRClosed.xaml
    /// </summary>
    public partial class SCRClosed : UserControl
    {
        public List<Program.LampHandler> scrLamps;
        public SimCircuit simcircuit { get; set; }

        public SCRClosed()
        {
            InitializeComponent();
            scrLamps = new List<Program.LampHandler>();
        }

        public void configureSCR(SimCircuit sc, int scrNum)
        {
            simcircuit = sc;
            string scr = "SCR" + scrNum.ToString();
            string sZ = scrNum.ToString("D2");
            LabelImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-LABEL.png"));

            scrLamps.Add(new Program.LampHandler(Program.simMain, LampImage, scr, "L1", 115, "/SCRLogic;component/Resources/SCR-LAMP-OFF.png", "/SCRLogic;component/Resources/SCR-LAMP-ON.png"));

            Voltmeter.configureMeter("PANEL-METER-SCALE-1000VDC.png", scr, "RM1");
            Ammeter.configureMeter("PANEL-METER-SCALE-2000ADC.png", scr, "RM2");
        }
    }
}
