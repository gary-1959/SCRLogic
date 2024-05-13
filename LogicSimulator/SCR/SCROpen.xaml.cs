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
    /// Interaction logic for SCROpen.xaml
    /// </summary>
    public partial class SCROpen : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public SCROpen()
        {
            InitializeComponent();

        }

        public void configureSCR(SimCircuit sc, int scrNum)
        {
            simcircuit = sc;
            string scr = "SCR" + scrNum.ToString();
            string sZ = scrNum.ToString("D2");

            if (K1 != null) K1.configureContactor(simcircuit, 1250, scr, 1);
            if (K2 != null) K2.configureContactor(simcircuit, 1800, scr, 2);
            if (K3 != null) K3.configureContactor(simcircuit, 1250, scr, 3);
            if (K4 != null) K4.configureContactor(simcircuit, 1250, scr, 4);
            if (K5 != null) K5.configureContactor(simcircuit, scr, 5);
            if (K6 != null) K6.configureContactor(simcircuit, 1250, scr, 6);
            if (K7 != null) K7.configureContactor(simcircuit, 1800, scr, 7);
            SCRTerminals.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-TERMINALS.png"));
            SCRWires.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-CONTACTOR-WIRES.png"));
            SCRAuctioneering.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-AUCTIONEERING.png"));
            BlowerContactor.configureBlowerContactor(simcircuit, scr, Blower);

            #region CB
            // coil is R, contacts are S
            Program.simMain.setNode(cpCB_U08L, scr, "RCB", "U8", "CB", "U8");
            Program.simMain.setNode(cpCB_U10L, scr, "RCB", "U10", "CB", "U10");
            Program.simMain.setNode(cpCB_01L, scr, "SCB-2", "1", "CB", "1");
            cpCB_01L.IsACVoltage = true;
            Program.simMain.setNode(cpCB_02L, scr, "SCB-2", "2", "CB", "2");
            cpCB_02L.IsACVoltage = true;
            Program.simMain.setNode(cpCB_03L, scr, "SCB-2", "3", "CB", "3");
            Program.simMain.setNode(cpCB_04L, scr, "SCB-5", "4", "CB", "4");
            Program.simMain.setNode(cpCB_05L, scr, "SCB-5", "5", "CB", "5");
            Program.simMain.setNode(cpCB_06L, scr, "SCB-5", "6", "CB", "6");
            Program.simMain.setNode(cpCB_07L, scr, "SCB-8", "7", "CB", "7");
            Program.simMain.setNode(cpCB_08L, scr, "SCB-8", "8", "CB", "8");
            Program.simMain.setNode(cpCB_09L, scr, "SCB-8", "9", "CB", "9");
            Program.simMain.setNode(cpCB_10L, scr, "SCB-11", "10", "CB", "10");
            Program.simMain.setNode(cpCB_11L, scr, "SCB-11", "11", "CB", "11");
            Program.simMain.setNode(cpCB_12L, scr, "SCB-11", "12", "CB", "12");

            Program.simMain.setNode(cpCB_U08R, scr, "RCB", "U8", "CB", "U8");
            Program.simMain.setNode(cpCB_U10R, scr, "RCB", "U10", "CB", "U10");
            Program.simMain.setNode(cpCB_01R, scr, "SCB-2", "1", "CB", "1");
            cpCB_01R.IsACVoltage = true;
            Program.simMain.setNode(cpCB_02R, scr, "SCB-2", "2", "CB", "2");
            cpCB_02R.IsACVoltage = true;
            Program.simMain.setNode(cpCB_03R, scr, "SCB-2", "3", "CB", "3");
            Program.simMain.setNode(cpCB_04R, scr, "SCB-5", "4", "CB", "4");
            Program.simMain.setNode(cpCB_05R, scr, "SCB-5", "5", "CB", "5");
            Program.simMain.setNode(cpCB_06R, scr, "SCB-5", "6", "CB", "6");
            Program.simMain.setNode(cpCB_07R, scr, "SCB-8", "7", "CB", "7");
            Program.simMain.setNode(cpCB_08R, scr, "SCB-8", "8", "CB", "8");
            Program.simMain.setNode(cpCB_09R, scr, "SCB-8", "9", "CB", "9");
            Program.simMain.setNode(cpCB_10R, scr, "SCB-11", "10", "CB", "10");
            Program.simMain.setNode(cpCB_11R, scr, "SCB-11", "11", "CB", "11");
            Program.simMain.setNode(cpCB_12R, scr, "SCB-11", "12", "CB", "12");
            #endregion
            #region TB21
            Program.simMain.setNode(cpTB21_01L, scr, "X2101", "1", "TB21", "1");
            Program.simMain.setNode(cpTB21_02L, scr, "X2102", "2", "TB21", "2");
            Program.simMain.setNode(cpTB21_03L, scr, "X2103", "3", "TB21", "3");
            Program.simMain.setNode(cpTB21_04L, scr, "X2104", "4", "TB21", "4");

            Program.simMain.setNode(cpTB21_01R, scr, "X2101", "1", "TB21", "1");
            Program.simMain.setNode(cpTB21_02R, scr, "X2102", "2", "TB21", "2");
            Program.simMain.setNode(cpTB21_03R, scr, "X2103", "3", "TB21", "3");
            Program.simMain.setNode(cpTB21_04R, scr, "X2104", "4", "TB21", "4");
            #endregion
            #region TB26
            Program.simMain.setNode(cpTB26_01L, scr, "X2601", "1", "TB26", "1");
            Program.simMain.setNode(cpTB26_02L, scr, "X2602", "2", "TB26", "2");
            Program.simMain.setNode(cpTB26_03L, scr, "X2603", "3", "TB26", "3");
            Program.simMain.setNode(cpTB26_04L, scr, "X2604", "4", "TB26", "4");

            Program.simMain.setNode(cpTB26_01R, scr, "X2601", "1", "TB26", "1");
            Program.simMain.setNode(cpTB26_02R, scr, "X2602", "2", "TB26", "2");
            Program.simMain.setNode(cpTB26_03R, scr, "X2603", "3", "TB26", "3");
            Program.simMain.setNode(cpTB26_04R, scr, "X2604", "4", "TB26", "4");
            #endregion
            #region FUSE_SWITCHES
            Program.simMain.setNode(cpFS1_1, scr, "SF1", "1", "FS1", "1");
            Program.simMain.setNode(cpFS1_2, scr, "SF1", "2", "FS1", "2");
            Program.simMain.setNode(cpFS2_1, scr, "SF2", "1", "FS2", "1");
            Program.simMain.setNode(cpFS2_2, scr, "SF2", "2", "FS2", "2");
            Program.simMain.setNode(cpFS3_1, scr, "SF3", "1", "FS3", "1");
            Program.simMain.setNode(cpFS3_2, scr, "SF3", "2", "FS3", "2");
            Program.simMain.setNode(cpFS4_1, scr, "SF4", "1", "FS4", "1");
            Program.simMain.setNode(cpFS4_2, scr, "SF4", "2", "FS4", "2");
            Program.simMain.setNode(cpFS5_1, scr, "SF5", "1", "FS5", "1");
            Program.simMain.setNode(cpFS5_2, scr, "SF5", "2", "FS5", "2");
            Program.simMain.setNode(cpFS6_1, scr, "SF6", "1", "FS6", "1");
            Program.simMain.setNode(cpFS6_2, scr, "SF6", "2", "FS6", "2");
            #endregion
            #region TB06

            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB06_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB06_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, scr, "ITB", "6-" + i.ToString(), "TB6", i.ToString());
                Program.simMain.setNode(cpR, scr, "ITB", "6-" + i.ToString(), "TB6", i.ToString());
            }
            #endregion
            #region AUCTIONEERING
            for (int i = 1; i <= 16; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpPC3_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, scr, "XPC3" + lZ, i.ToString(), "PC3", i.ToString());
            }
            #endregion
        }
    }
}
