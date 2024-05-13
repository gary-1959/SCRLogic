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
    /// Interaction logic for DCDoor.xaml
    /// </summary>
    public partial class DCDoor : UserControl
    {
        SimCircuit simcircuit { get; set; }
        public DCDoor()
        {
            InitializeComponent();
        }
            public void configureDC(SimCircuit sc)
        {
            simcircuit = sc;
            assignmentSwitch.configureAS(simcircuit);
            #region MP1
            MP1PotAssembly.RearPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-MP1-REAR.png"));
            simcircuit.setNode(MP1PotAssembly.RearPotWires.cp01, "DC", "P1B", "1", "POT1B", "1");
            simcircuit.setNode(MP1PotAssembly.RearPotWires.cp02, "DC", "P1B", "2", "POT1B", "2");
            simcircuit.setNode(MP1PotAssembly.RearPotWires.cp03, "DC", "P1B", "3", "POT1B", "3");
            Potentiometer p1 = MP1PotAssembly.RearPotWires.cp03.node.parent.simElement as Potentiometer;

            MP1PotAssembly.FrontPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-MP1-FRONT.png"));
            simcircuit.setNode(MP1PotAssembly.FrontPotWires.cp01, "DC", "P1A", "1", "POT1A", "1");
            simcircuit.setNode(MP1PotAssembly.FrontPotWires.cp02, "DC", "P1A", "2", "POT1A", "2");
            simcircuit.setNode(MP1PotAssembly.FrontPotWires.cp03, "DC", "P1A", "3", "POT1A", "3");
            simcircuit.setNode(MP1PotAssembly.FrontPotWires.cpCOM, "DC", "S7A", "C", "S7A", "C");
            simcircuit.setNode(MP1PotAssembly.FrontPotWires.cpNO, "DC", "S7A", "NO", "S7A", "NO");
            #endregion
            #region MP2
            MP2PotAssembly.RearPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-MP2-REAR.png"));
            simcircuit.setNode(MP2PotAssembly.RearPotWires.cp01, "DC", "P2B", "1", "POT2B", "1");
            simcircuit.setNode(MP2PotAssembly.RearPotWires.cp02, "DC", "P2B", "2", "POT2B", "2");
            simcircuit.setNode(MP2PotAssembly.RearPotWires.cp03, "DC", "P2B", "3", "POT2B", "3");
            MP2PotAssembly.FrontPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-MP2-FRONT.png"));
            simcircuit.setNode(MP2PotAssembly.FrontPotWires.cp01, "DC", "P2A", "1", "POT2A", "1");
            simcircuit.setNode(MP2PotAssembly.FrontPotWires.cp02, "DC", "P2A", "2", "POT2A", "2");
            simcircuit.setNode(MP2PotAssembly.FrontPotWires.cp03, "DC", "P2A", "3", "POT2A", "3");
            simcircuit.setNode(MP2PotAssembly.FrontPotWires.cpCOM, "DC", "S8A", "C", "S8A", "C");
            simcircuit.setNode(MP2PotAssembly.FrontPotWires.cpNO, "DC", "S8A", "NO", "S8A", "NO");
            #endregion
            #region DW
            DWPotAssembly.RearPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-DW-REAR.png"));
            simcircuit.setNode(DWPotAssembly.RearPotWires.cp01, "DC", "P3B", "1", "POT3B", "1");
            simcircuit.setNode(DWPotAssembly.RearPotWires.cp02, "DC", "P3B", "2", "POT3B", "2");
            simcircuit.setNode(DWPotAssembly.RearPotWires.cp03, "DC", "P3B", "3", "POT3B", "3");
            simcircuit.setNode(DWPotAssembly.RearPotWires.cpCOM, "DC", "S9B", "C", "S9B", "C");
            simcircuit.setNode(DWPotAssembly.RearPotWires.cpNC, "DC", "S9B", "NC", "S9B", "NC");
            DWPotAssembly.FrontPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-DW-FRONT.png"));
            simcircuit.setNode(DWPotAssembly.FrontPotWires.cp01, "DC", "P3A", "1", "POT3A", "1");
            simcircuit.setNode(DWPotAssembly.FrontPotWires.cp02, "DC", "P3A", "2", "POT3A", "2");
            simcircuit.setNode(DWPotAssembly.FrontPotWires.cp03, "DC", "P3A", "3", "POT3A", "3");
            simcircuit.setNode(DWPotAssembly.FrontPotWires.cpCOM, "DC", "S9A", "C", "S8A", "C");
            simcircuit.setNode(DWPotAssembly.FrontPotWires.cpNO, "DC", "S9A", "NO", "S8A", "NO");
            #endregion
            #region RT
            RTPotAssembly.RearPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-RT-REAR.png"));
            simcircuit.setNode(RTPotAssembly.RearPotWires.cp01, "DC", "P4B", "1", "POT4B", "1");
            simcircuit.setNode(RTPotAssembly.RearPotWires.cp02, "DC", "P4B", "2", "POT4B", "2");
            simcircuit.setNode(RTPotAssembly.RearPotWires.cp03, "DC", "P4B", "3", "POT4B", "3");
            RTPotAssembly.FrontPotWires.WireImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/POT-WIRES-RT-FRONT.png"));
            simcircuit.setNode(RTPotAssembly.FrontPotWires.cp01, "DC", "P4A", "1", "POT4A", "1");
            simcircuit.setNode(RTPotAssembly.FrontPotWires.cp02, "DC", "P4A", "2", "POT4A", "2");
            simcircuit.setNode(RTPotAssembly.FrontPotWires.cp03, "DC", "P4A", "3", "POT4A", "3");
            #endregion
            #region POT5
            simcircuit.setNode(cpPOT5A_01, "DC", "P5A", "1", "POT5A", "1");
            simcircuit.setNode(cpPOT5A_03, "DC", "P5A", "2", "POT5A", "2");
            simcircuit.setNode(cpPOT5A_02, "DC", "P5A", "3", "POT5A", "3");
            simcircuit.setNode(cpPOT5B_01, "DC", "P5B", "1", "POT5B", "1");
            simcircuit.setNode(cpPOT5B_03, "DC", "P5B", "2", "POT5B", "2");
            simcircuit.setNode(cpPOT5B_02, "DC", "P5B", "3", "POT5B", "3");
            #endregion
            #region S6
            simcircuit.setNode(cpS6_01, "DC", "S6-1", "1", "S6", "1");
            simcircuit.setNode(cpS6_02, "DC", "S6-1", "2", "S6", "2");
            simcircuit.setNode(cpS6_03, "DC", "S6-3", "3", "S6", "3");
            simcircuit.setNode(cpS6_04, "DC", "S6-3", "4", "S6", "4");

            simcircuit.setNode(cpS6_05, "DC", "S6-5", "5", "S6", "5");
            simcircuit.setNode(cpS6_06, "DC", "S6-5", "6", "S6", "6");
            simcircuit.setNode(cpS6_07, "DC", "S6-7", "7", "S6", "7");
            simcircuit.setNode(cpS6_08, "DC", "S6-7", "8", "S6", "8");

            simcircuit.setNode(cpS6_09, "DC", "S6-9", "9", "S6", "9");
            simcircuit.setNode(cpS6_10, "DC", "S6-9", "10", "S6", "10");
            simcircuit.setNode(cpS6_11, "DC", "S6-11", "11", "S6", "11");
            simcircuit.setNode(cpS6_12, "DC", "S6-11", "12", "S6", "12");

            simcircuit.setNode(cpS6_13, "DC", "S6-13", "13", "S6", "13");
            simcircuit.setNode(cpS6_14, "DC", "S6-13", "14", "S6", "14");
            simcircuit.setNode(cpS6_15, "DC", "S6-15", "15", "S6", "15");
            simcircuit.setNode(cpS6_16, "DC", "S6-15", "16", "S6", "16");
            #endregion
            #region S5
            simcircuit.setNode(cpS5_01, "DC", "S5-1", "1", "S5", "1");
            simcircuit.setNode(cpS5_02, "DC", "S5-1", "2", "S5", "2");
            simcircuit.setNode(cpS5_03, "DC", "S5-3", "3", "S5", "3");
            simcircuit.setNode(cpS5_04, "DC", "S5-3", "4", "S5", "4");

            simcircuit.setNode(cpS5_05, "DC", "S5-5", "5", "S5", "5");
            simcircuit.setNode(cpS5_06, "DC", "S5-5", "6", "S5", "6");
            simcircuit.setNode(cpS5_07, "DC", "S5-7", "7", "S5", "7");
            simcircuit.setNode(cpS5_08, "DC", "S5-7", "8", "S5", "8");

            simcircuit.setNode(cpS5_09, "DC", "S5-9", "9", "S5", "9");
            simcircuit.setNode(cpS5_10, "DC", "S5-9", "10", "S5", "10");
            simcircuit.setNode(cpS5_11, "DC", "S5-11", "11", "S5", "11");
            simcircuit.setNode(cpS5_12, "DC", "S5-11", "12", "S5", "12");

            simcircuit.setNode(cpS5_13, "DC", "S5-13", "13", "S5", "13");
            simcircuit.setNode(cpS5_14, "DC", "S5-13", "14", "S5", "14");
            simcircuit.setNode(cpS5_15, "DC", "S5-15", "15", "S5", "15");
            simcircuit.setNode(cpS5_16, "DC", "S5-15", "16", "S5", "16");
            #endregion
            #region S11
            simcircuit.setNode(cpS11_01, "DC", "S11-1", "1", "S11", "1");
            simcircuit.setNode(cpS11_02, "DC", "S11-1", "2", "S11", "2");
            simcircuit.setNode(cpS11_03, "DC", "S11-3", "3", "S11", "3");
            simcircuit.setNode(cpS11_04, "DC", "S11-3", "4", "S11", "4");

            simcircuit.setNode(cpS11_05, "DC", "S11-5", "5", "S11", "5");
            simcircuit.setNode(cpS11_06, "DC", "S11-5", "6", "S11", "6");
            simcircuit.setNode(cpS11_07, "DC", "S11-7", "7", "S11", "7");
            simcircuit.setNode(cpS11_08, "DC", "S11-7", "8", "S11", "8");
            #endregion
            #region S4
            simcircuit.setNode(cpS4_01, "DC", "S4-1", "1", "S4", "1");
            simcircuit.setNode(cpS4_02, "DC", "S4-1", "2", "S4", "2");
            simcircuit.setNode(cpS4_03, "DC", "S4-3", "3", "S4", "3");
            simcircuit.setNode(cpS4_04, "DC", "S4-3", "4", "S4", "4");

            simcircuit.setNode(cpS4_05, "DC", "S4-5", "5", "S4", "5");
            simcircuit.setNode(cpS4_06, "DC", "S4-5", "6", "S4", "6");
            simcircuit.setNode(cpS4_07, "DC", "S4-7", "7", "S4", "7");
            simcircuit.setNode(cpS4_08, "DC", "S4-7", "8", "S4", "8");
            #endregion
            #region S3
            simcircuit.setNode(cpS3_01, "DC", "S3-1", "1", "S3", "1");
            simcircuit.setNode(cpS3_02, "DC", "S3-1", "2", "S3", "2");
            simcircuit.setNode(cpS3_03, "DC", "S3-3", "3", "S3", "3");
            simcircuit.setNode(cpS3_04, "DC", "S3-3", "4", "S3", "4");
            simcircuit.setNode(cpS3_05, "DC", "S3-5", "5", "S3", "5");
            simcircuit.setNode(cpS3_06, "DC", "S3-5", "6", "S3", "6");
            simcircuit.setNode(cpS3_07, "DC", "S3-7", "7", "S3", "7");
            simcircuit.setNode(cpS3_08, "DC", "S3-7", "8", "S3", "8");
            simcircuit.setNode(cpS3_09, "DC", "S3-9", "9", "S3", "9");
            simcircuit.setNode(cpS3_10, "DC", "S3-9", "10", "S3", "10");
            #endregion
            #region S2
            simcircuit.setNode(cpS2_01, "DC", "S2-1", "1", "S2", "1");
            simcircuit.setNode(cpS2_02, "DC", "S2-1", "2", "S2", "2");
            simcircuit.setNode(cpS2_03, "DC", "S2-3", "3", "S2", "3");
            simcircuit.setNode(cpS2_04, "DC", "S2-3", "4", "S2", "4");

            simcircuit.setNode(cpS2_05, "DC", "S2-5", "5", "S2", "5");
            simcircuit.setNode(cpS2_06, "DC", "S2-5", "6", "S2", "6");
            simcircuit.setNode(cpS2_07, "DC", "S2-7", "7", "S2", "7");
            simcircuit.setNode(cpS2_08, "DC", "S2-7", "8", "S2", "8");
            #endregion
            #region METERS
            simcircuit.setNode(cpM1_01, "DC", "RM1", "[+]", "M1", "[+]");
            simcircuit.setNode(cpM1_02, "DC", "RM1", "[-]", "M1", "[-]");
            simcircuit.setNode(cpM2_01, "DC", "RM2", "[+]", "M1", "[+]");
            simcircuit.setNode(cpM2_02, "DC", "RM2", "[-]", "M1", "[-]");
            #endregion
            #region LAMPS
            simcircuit.setNode(cpL01_01, "DC", "L1", "1", "L1", "1");
            simcircuit.setNode(cpL01_02, "DC", "L1", "2", "L1", "2");
            simcircuit.setNode(cpL02_01, "DC", "L2", "1", "L2", "1");
            simcircuit.setNode(cpL02_02, "DC", "L2", "2", "L2", "2");
            simcircuit.setNode(cpL03_01, "DC", "L3", "1", "L3", "1");
            simcircuit.setNode(cpL03_02, "DC", "L3", "2", "L3", "2");
            simcircuit.setNode(cpL04_01, "DC", "L4", "1", "L4", "1");
            simcircuit.setNode(cpL04_02, "DC", "L4", "2", "L4", "2");

            simcircuit.setNode(cpL21_01, "DC", "L21", "1", "L21", "1");
            simcircuit.setNode(cpL21_02, "DC", "L21", "2", "L21", "2");
            simcircuit.setNode(cpL22_01, "DC", "L22", "1", "L22", "1");
            simcircuit.setNode(cpL22_02, "DC", "L22", "2", "L22", "2");
            simcircuit.setNode(cpL23_01, "DC", "L23", "1", "L23", "1");
            simcircuit.setNode(cpL23_02, "DC", "L23", "2", "L23", "2");
            simcircuit.setNode(cpL24_01, "DC", "L24", "1", "L24", "1");
            simcircuit.setNode(cpL24_02, "DC", "L24", "2", "L24", "2");
            simcircuit.setNode(cpL25_01, "DC", "L25", "1", "L25", "1");
            simcircuit.setNode(cpL25_02, "DC", "L25", "2", "L25", "2");
            simcircuit.setNode(cpL26_01, "DC", "L26", "1", "L26", "1");
            simcircuit.setNode(cpL26_02, "DC", "L26", "2", "L26", "2");

            simcircuit.setNode(cpL31_01, "DC", "L31", "1", "L31", "1");
            simcircuit.setNode(cpL31_02, "DC", "L31", "2", "L31", "2");
            simcircuit.setNode(cpL32_01, "DC", "L32", "1", "L32", "1");
            simcircuit.setNode(cpL32_02, "DC", "L32", "2", "L32", "2");
            simcircuit.setNode(cpL33_01, "DC", "L33", "1", "L33", "1");
            simcircuit.setNode(cpL33_02, "DC", "L33", "2", "L33", "2");
            simcircuit.setNode(cpL34_01, "DC", "L34", "1", "L34", "1");
            simcircuit.setNode(cpL34_02, "DC", "L34", "2", "L34", "2");
            simcircuit.setNode(cpL35_01, "DC", "L35", "1", "L35", "1");
            simcircuit.setNode(cpL35_02, "DC", "L35", "2", "L35", "2");
            simcircuit.setNode(cpL36_01, "DC", "L36", "1", "L36", "1");
            simcircuit.setNode(cpL36_02, "DC", "L36", "2", "L36", "2");

            #endregion
        }
    }
}
