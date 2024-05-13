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
    /// Interaction logic for SCRDoor.xaml
    /// </summary>
    public partial class SCRDoor : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public SCRDoor()
        {
            InitializeComponent();
        }


        public void configureSCR(SimCircuit sc, int scrNum, PanelMeter vM, PanelMeter aM)
        {
            simcircuit = sc;
            string scr = "SCR" + scrNum.ToString();
            string sZ = scrNum.ToString("D2");

            SCRWires.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-DOOR.png"));

            #region M1
            simcircuit.setNode(cpM1_1, scr, "RM1", "[+]", "M1", "[+]");
            simcircuit.setNode(cpM1_2, scr, "RM1", "[-]", "M1", "[-]");
            #endregion
            #region M2
            simcircuit.setNode(cpM2_1, scr, "RM2", "[+]", "M2", "[+]");
            simcircuit.setNode(cpM2_2, scr, "RM2", "[-]", "M2", "[-]");
            #endregion
            #region L1
            simcircuit.setNode(cpL1_1, scr, "L1", "1", "L1", "1");
            cpL1_1.IsACVoltage = true;
            simcircuit.setNode(cpL1_2, scr, "L1", "2", "L1", "2");
            cpL1_2.IsACVoltage = true;
            #endregion
            #region PC1
            for (int i = 1; i <= 40; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpPC1_" + lZ) as CircuitPoint;
                if (i != 13)
                {
                    simcircuit.setNode(cp, scr, "XPC1-" + lZ, i.ToString(), "PC1", i.ToString());
                    if (i >=10 && i <=12)
                    {
                        cp.IsACVoltage = true;
                    }
                }
                else
                {
                    simcircuit.setNode(cp, scr, "VPC1-" + lZ, i.ToString(), "PC1", i.ToString());
                }

            }
            Program.RelayHandler pc1_1Handler = new Program.RelayHandler(Program.simMain, scr, "RPC1", 24);
            #endregion
            #region DCM
            DCM.configureDCM(simcircuit, scrNum, vM, aM);
            #endregion


        }
    }
    
}
