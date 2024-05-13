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
    /// Interaction logic for SCRRelay.xaml
    /// </summary>
    public partial class SCRRelay: UserControl
    {
        public SCRRelay()
        {
            InitializeComponent();
        }

        public void configureSCR(int scrNum)
        {
            string scr = "SCR" + scrNum.ToString();
            string sZ = scrNum.ToString("D2");

            SCRWires.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/" + scr + "-RELAY.png"));

            switch (scrNum)
            {
                case 1:
                    #region RX1
                    Program.simMain.setNode(cpRLA_1L, scr, "SRX1-7C", "1", "RX1", "1");
                    Program.simMain.setNode(cpRLA_7L, scr, "SRX1-7C", "7C", "RX1", "7");
                    Program.simMain.setNode(cpRLA_4L, scr, "SRX1-7", "4", "RX1", "4");
                    Program.simMain.setNode(cpRLA_AL, scr, "RX1", "A", "RX1", "A");
                    Program.simMain.setNode(cpRLA_BL, scr, "RX1", "B", "RX1", "B");

                    Program.simMain.setNode(cpRLA_1R, scr, "SRX1-7C", "1", "RX1", "1");
                    Program.simMain.setNode(cpRLA_7R, scr, "SRX1-7C", "7C", "RX1", "7");
                    Program.simMain.setNode(cpRLA_4R, scr, "SRX1-7", "4", "RX1", "4");
                    Program.simMain.setNode(cpRLA_AR, scr, "RX1", "A", "RX1", "A");
                    Program.simMain.setNode(cpRLA_BR, scr, "RX1", "B", "RX1", "B");

                    Program.RelayHandler SCR1_RX1Handler = new Program.RelayHandler(Program.simMain, scr, "RX1", 24);
                    #endregion
                    break;
                case 2:
                    #region RL1
                    Program.simMain.setNode(cpRLA_1L, scr, "SRL1-7C", "1", "RL1", "1");
                    Program.simMain.setNode(cpRLA_7L, scr, "SRL1-7", "7", "RL1", "7");
                    Program.simMain.setNode(cpRLA_4L, scr, "SRL1-7", "4", "RL1", "4");
                    Program.simMain.setNode(cpRLA_2L, scr, "SRL1-8C", "2", "RL1", "2");
                    Program.simMain.setNode(cpRLA_8L, scr, "SRL1-8", "8", "RL1", "8");
                    Program.simMain.setNode(cpRLA_5L, scr, "SRL1-8", "5", "RL1", "5");
                    Program.simMain.setNode(cpRLA_3L, scr, "SRL1-9C", "3", "RL1", "3");
                    Program.simMain.setNode(cpRLA_9L, scr, "SRL1-9C", "9C", "RL1", "9");
                    Program.simMain.setNode(cpRLA_6L, scr, "SRL1-9", "6", "RL1", "6");
                    Program.simMain.setNode(cpRLA_AL, scr, "RL1", "A", "RL1", "A");
                    Program.simMain.setNode(cpRLA_BL, scr, "RL1", "B", "RL1", "B");

                    Program.simMain.setNode(cpRLA_1R, scr, "SRL1-7C", "1", "RL1", "1");
                    Program.simMain.setNode(cpRLA_7R, scr, "SRL1-7", "7", "RL1", "7");
                    Program.simMain.setNode(cpRLA_4R, scr, "SRL1-7", "4", "RL1", "4");
                    Program.simMain.setNode(cpRLA_2R, scr, "SRL1-8C", "2", "RL1", "2");
                    Program.simMain.setNode(cpRLA_8R, scr, "SRL1-8", "8", "RL1", "8");
                    Program.simMain.setNode(cpRLA_5R, scr, "SRL1-8", "5", "RL1", "5");
                    Program.simMain.setNode(cpRLA_3R, scr, "SRL1-9C", "3", "RL1", "3");
                    Program.simMain.setNode(cpRLA_9R, scr, "SRL1-9C", "9C", "RL1", "9");
                    Program.simMain.setNode(cpRLA_6R, scr, "SRL1-9", "6", "RL1", "6");
                    Program.simMain.setNode(cpRLA_AR, scr, "RL1", "A", "RL1", "A");
                    Program.simMain.setNode(cpRLA_BR, scr, "RL1", "B", "RL1", "B");

                    Program.RelayHandler SCR2_RL1Handler = new Program.RelayHandler(Program.simMain, scr, "RL1", 6);
                    #endregion
                    #region RL4
                    Program.simMain.setNode(cpRLB_1L, scr, "SRL4-7", "1", "RL4", "1");
                    Program.simMain.setNode(cpRLB_7L, scr, "SRL4-7", "7", "RL4", "7");
                    Program.simMain.setNode(cpRLB_4L, scr, "SRL4-7", "4", "RL4", "4");
                    Program.simMain.setNode(cpRLB_2L, scr, "SRL4-8", "2", "RL4", "2");
                    Program.simMain.setNode(cpRLB_8L, scr, "SRL4-8", "8", "RL4", "8");
                    Program.simMain.setNode(cpRLB_5L, scr, "SRL4-8", "5", "RL4", "5");
                    Program.simMain.setNode(cpRLB_3L, scr, "SRL4-9C", "3", "RL4", "3");
                    Program.simMain.setNode(cpRLB_9L, scr, "SRL4-9C", "9C", "RL4", "9");
                    Program.simMain.setNode(cpRLB_6L, scr, "SRL4-9", "6", "RL4", "6");
                    Program.simMain.setNode(cpRLB_AL, scr, "RL4", "A", "RL4", "A");
                    Program.simMain.setNode(cpRLB_BL, scr, "RL4", "B", "RL4", "B");

                    Program.simMain.setNode(cpRLB_1R, scr, "SRL4-7", "1", "RL4", "1");
                    Program.simMain.setNode(cpRLB_7R, scr, "SRL4-7", "7", "RL4", "7");
                    Program.simMain.setNode(cpRLB_4R, scr, "SRL4-7", "4", "RL4", "4");
                    Program.simMain.setNode(cpRLB_2R, scr, "SRL4-8", "2", "RL4", "2");
                    Program.simMain.setNode(cpRLB_8R, scr, "SRL4-8", "8", "RL4", "8");
                    Program.simMain.setNode(cpRLB_5R, scr, "SRL4-8", "5", "RL4", "5");
                    Program.simMain.setNode(cpRLB_3R, scr, "SRL4-9C", "3", "RL4", "3");
                    Program.simMain.setNode(cpRLB_9R, scr, "SRL4-9C", "9C", "RL4", "9");
                    Program.simMain.setNode(cpRLB_6R, scr, "SRL4-9", "6", "RL4", "6");
                    Program.simMain.setNode(cpRLB_AR, scr, "RL4", "A", "RL4", "A");
                    Program.simMain.setNode(cpRLB_BR, scr, "RL4", "B", "RL4", "B");

                    Program.RelayHandler SCR2_RL4Handler = new Program.RelayHandler(Program.simMain, scr, "RL4", 24);
                    #endregion
                    #region RL5
                    Program.simMain.setNode(cpRLC_1L, scr, "SRL5-7C", "1", "RL5", "1");
                    Program.simMain.setNode(cpRLC_7L, scr, "SRL5-7", "7", "RL5", "7");
                    Program.simMain.setNode(cpRLC_4L, scr, "SRL5-7", "4", "RL5", "4");
                    Program.simMain.setNode(cpRLC_2L, scr, "SRL5-8C", "2", "RL5", "2");
                    Program.simMain.setNode(cpRLC_8L, scr, "SRL5-8", "8", "RL5", "8");
                    Program.simMain.setNode(cpRLC_5L, scr, "SRL5-8", "5", "RL5", "5");
                    Program.simMain.setNode(cpRLC_6L, scr, "RL5", "A", "RL5", "A");
                    Program.simMain.setNode(cpRLC_AL, scr, "RL5", "B", "RL5", "B");
                    Program.simMain.setNode(cpRLC_BL, scr, "XRL5", "C", "RL5", "C");

                    Program.simMain.setNode(cpRLC_1R, scr, "SRL5-7C", "1", "RL5", "1");
                    Program.simMain.setNode(cpRLC_7R, scr, "SRL5-7", "7", "RL5", "7");
                    Program.simMain.setNode(cpRLC_4R, scr, "SRL5-7", "4", "RL5", "4");
                    Program.simMain.setNode(cpRLC_2R, scr, "SRL5-8C", "2", "RL5", "2");
                    Program.simMain.setNode(cpRLC_8R, scr, "SRL5-8", "8", "RL5", "8");
                    Program.simMain.setNode(cpRLC_5R, scr, "SRL5-8", "5", "RL5", "5");
                    Program.simMain.setNode(cpRLC_6R, scr, "RL5", "A", "RL5", "A");
                    Program.simMain.setNode(cpRLC_AR, scr, "RL5", "B", "RL5", "B");
                    Program.simMain.setNode(cpRLC_BR, scr, "XRL5", "C", "RL5", "C");

                    Program.RelayHandler SCR2_RL5Handler = new Program.RelayHandler(Program.simMain, scr, "RL5", 24);
                    #endregion
                    #region RL6A
                    Program.simMain.setNode(cpRLD_1L, scr, "SRL6A-7C", "1", "RL6A", "1");
                    Program.simMain.setNode(cpRLD_7L, scr, "SRL6A-7", "7", "RL6A", "7");
                    Program.simMain.setNode(cpRLD_4L, scr, "SRL6A-7", "4", "RL6A", "4");
                    Program.simMain.setNode(cpRLD_2L, scr, "SRL6A-8C", "2", "RL6A", "2");
                    Program.simMain.setNode(cpRLD_8L, scr, "SRL6A-8", "8", "RL6A", "8");
                    Program.simMain.setNode(cpRLD_5L, scr, "SRL6A-8", "5", "RL6A", "5");
                    Program.simMain.setNode(cpRLD_9L, scr, "RL6A", "A", "RL6A", "A");
                    Program.simMain.setNode(cpRLD_6L, scr, "DRL6A", "K", "RL6A", "K");
                    Program.simMain.setNode(cpRLD_AL, scr, "RL6A", "B", "RL6A", "B");
                    Program.simMain.setNode(cpRLD_BL, scr, "XRL6A", "C", "RL6A", "C");

                    Program.simMain.setNode(cpRLD_1R, scr, "SRL6A-7C", "1", "RL6A", "1");
                    Program.simMain.setNode(cpRLD_7R, scr, "SRL6A-7", "7", "RL6A", "7");
                    Program.simMain.setNode(cpRLD_4R, scr, "SRL6A-7", "4", "RL6A", "4");
                    Program.simMain.setNode(cpRLD_2R, scr, "SRL6A-8C", "2", "RL6A", "2");
                    Program.simMain.setNode(cpRLD_8R, scr, "SRL6A-8", "8", "RL6A", "8");
                    Program.simMain.setNode(cpRLD_5R, scr, "SRL6A-8", "5", "RL6A", "5");
                    Program.simMain.setNode(cpRLD_9R, scr, "RL6A", "A", "RL6A", "A");
                    Program.simMain.setNode(cpRLD_6R, scr, "DRL6A", "K", "RL6A", "K");
                    Program.simMain.setNode(cpRLD_AR, scr, "RL6A", "B", "RL6A", "B");
                    Program.simMain.setNode(cpRLD_BR, scr, "XRL6A", "C", "RL6A", "C");

                    Program.RelayHandler SCR2_RL6AHandler = new Program.RelayHandler(Program.simMain, scr, "RL6A", 24);
                    #endregion
                    #region RL6B
                    Program.simMain.setNode(cpRLE_1L, scr, "SRL6B-7C", "1", "RL6B", "1");
                    Program.simMain.setNode(cpRLE_7L, scr, "SRL6B-7C", "7C", "RL6B", "7");
                    Program.simMain.setNode(cpRLE_4L, scr, "SRL6B-7", "4", "RL6B", "4");
                    Program.simMain.setNode(cpRLE_2L, scr, "SRL6B-8C", "2", "RL6B", "2");
                    Program.simMain.setNode(cpRLE_8L, scr, "SRL6B-8C", "8C", "RL6B", "8");
                    Program.simMain.setNode(cpRLE_5L, scr, "SRL6B-8", "5", "RL6B", "5");
                    Program.simMain.setNode(cpRLE_6L, scr, "RL6B", "A", "RL6B", "A");
                    Program.simMain.setNode(cpRLE_AL, scr, "DRL6B", "K", "RL6B", "K");
                    Program.simMain.setNode(cpRLE_BL, scr, "RL6B", "B", "RL6B", "B");

                    Program.simMain.setNode(cpRLE_1R, scr, "SRL6B-7C", "1", "RL6B", "1");
                    Program.simMain.setNode(cpRLE_7R, scr, "SRL6B-7C", "7C", "RL6B", "7");
                    Program.simMain.setNode(cpRLE_4R, scr, "SRL6B-7", "4", "RL6B", "4");
                    Program.simMain.setNode(cpRLE_2R, scr, "SRL6B-8C", "2", "RL6B", "2");
                    Program.simMain.setNode(cpRLE_8R, scr, "SRL6B-8C", "8C", "RL6B", "8");
                    Program.simMain.setNode(cpRLE_5R, scr, "SRL6B-8", "5", "RL6B", "5");
                    Program.simMain.setNode(cpRLE_6R, scr, "RL6B", "A", "RL6B", "A");
                    Program.simMain.setNode(cpRLE_AR, scr, "DRL6B", "K", "RL6B", "K");
                    Program.simMain.setNode(cpRLE_BR, scr, "RL6B", "B", "RL6B", "B");

                    Program.RelayHandler SCR2_RL6BHandler = new Program.RelayHandler(Program.simMain, scr, "RL6B", 24);
                    #endregion
                    #region RL11
                    Program.simMain.setNode(cpRLF_1L, scr, "SRL11-7C", "1", "RL11", "1");
                    Program.simMain.setNode(cpRLF_7L, scr, "SRL11-7", "7", "RL11", "7");
                    Program.simMain.setNode(cpRLF_4L, scr, "SRL11-7", "4", "RL11", "4");
                    Program.simMain.setNode(cpRLF_2L, scr, "SRL11-8C", "2", "RL11", "2");
                    Program.simMain.setNode(cpRLF_8L, scr, "SRL11-8", "8", "RL11", "8");
                    Program.simMain.setNode(cpRLF_5L, scr, "SRL11-8", "5", "RL11", "5");
                    Program.simMain.setNode(cpRLF_3L, scr, "SRL11-9C", "3", "RL11", "3");
                    Program.simMain.setNode(cpRLF_9L, scr, "SRL11-9", "9", "RL11", "9");
                    Program.simMain.setNode(cpRLF_6L, scr, "SRL11-9", "6", "RL11", "6");
                    Program.simMain.setNode(cpRLF_AL, scr, "RL11", "A", "RL11", "A");
                    cpRLF_AL.IsACVoltage = true;
                    Program.simMain.setNode(cpRLF_BL, scr, "RL11", "B", "RL11", "B");
                    cpRLF_BL.IsACVoltage = true;

                    Program.simMain.setNode(cpRLF_1R, scr, "SRL11-7C", "1", "RL11", "1");
                    Program.simMain.setNode(cpRLF_7R, scr, "SRL11-7", "7", "RL11", "7");
                    Program.simMain.setNode(cpRLF_4R, scr, "SRL11-7", "4", "RL11", "4");
                    Program.simMain.setNode(cpRLF_2R, scr, "SRL11-8C", "2", "RL11", "2");
                    Program.simMain.setNode(cpRLF_8R, scr, "SRL11-8", "8", "RL11", "8");
                    Program.simMain.setNode(cpRLF_5R, scr, "SRL11-8", "5", "RL11", "5");
                    Program.simMain.setNode(cpRLF_3R, scr, "SRL11-9C", "3", "RL11", "3");
                    Program.simMain.setNode(cpRLF_9R, scr, "SRL11-9", "9", "RL11", "9");
                    Program.simMain.setNode(cpRLF_6R, scr, "SRL11-9", "6", "RL11", "6");
                    Program.simMain.setNode(cpRLF_AR, scr, "RL11", "A", "RL11", "A");
                    cpRLF_AR.IsACVoltage = true;
                    Program.simMain.setNode(cpRLF_BR, scr, "RL11", "B", "RL11", "B");
                    cpRLF_BR.IsACVoltage = true;

                    Program.RelayHandler SCR2_RL11Handler = new Program.RelayHandler(Program.simMain, scr, "RL11", 115);
                    #endregion
                    break;
                case 3:
                    #region RL3A
                    Program.simMain.setNode(cpRLA_1L, scr, "SRL3A-7C", "1", "RL3A", "1");
                    Program.simMain.setNode(cpRLA_7L, scr, "SRL3A-7", "7", "RL3A", "7");
                    Program.simMain.setNode(cpRLA_4L, scr, "SRL3A-7", "4", "RL3A", "4");
                    Program.simMain.setNode(cpRLA_2L, scr, "SRL3A-8C", "2", "RL3A", "2");
                    Program.simMain.setNode(cpRLA_8L, scr, "SRL3A-8", "8", "RL3A", "8");
                    Program.simMain.setNode(cpRLA_5L, scr, "SRL3A-8", "5", "RL3A", "5");
                    Program.simMain.setNode(cpRLA_3L, scr, "SRL3A-9C", "3", "RL3A", "3");
                    Program.simMain.setNode(cpRLA_9L, scr, "SRL3A-9", "9", "RL3A", "9");
                    Program.simMain.setNode(cpRLA_6L, scr, "SRL3A-9", "6", "RL3A", "6");
                    Program.simMain.setNode(cpRLA_AL, scr, "RL3A", "A", "RL3A", "A");
                    Program.simMain.setNode(cpRLA_BL, scr, "RL3A", "B", "RL3A", "B");

                    Program.simMain.setNode(cpRLA_1R, scr, "SRL3A-7C", "1", "RL3A", "1");
                    Program.simMain.setNode(cpRLA_7R, scr, "SRL3A-7", "7", "RL3A", "7");
                    Program.simMain.setNode(cpRLA_4R, scr, "SRL3A-7", "4", "RL3A", "4");
                    Program.simMain.setNode(cpRLA_2R, scr, "SRL3A-8C", "2", "RL3A", "2");
                    Program.simMain.setNode(cpRLA_8R, scr, "SRL3A-8", "8", "RL3A", "8");
                    Program.simMain.setNode(cpRLA_5R, scr, "SRL3A-8", "5", "RL3A", "5");
                    Program.simMain.setNode(cpRLA_3R, scr, "SRL3A-9C", "3", "RL3A", "3");
                    Program.simMain.setNode(cpRLA_9R, scr, "SRL3A-9", "9", "RL3A", "9");
                    Program.simMain.setNode(cpRLA_6R, scr, "SRL3A-9", "6", "RL3A", "6");
                    Program.simMain.setNode(cpRLA_AR, scr, "RL3A", "A", "RL3A", "A");
                    Program.simMain.setNode(cpRLA_BR, scr, "RL3A", "B", "RL3A", "B");

                    Program.RelayHandler SCR3_RL3AHandler = new Program.RelayHandler(Program.simMain, scr, "RL3A", 6);
                    #endregion
                    #region RL3B
                    Program.simMain.setNode(cpRLB_1L, scr, "SRL3B-7C", "1", "RL3B", "1");
                    Program.simMain.setNode(cpRLB_7L, scr, "SRL3B-7C", "7C", "RL3B", "7");
                    Program.simMain.setNode(cpRLB_4L, scr, "SRL3B-7", "4", "RL3B", "4");
                    Program.simMain.setNode(cpRLB_AL, scr, "RL3B", "A", "RL3B", "A");
                    Program.simMain.setNode(cpRLB_BL, scr, "RL3B", "B", "RLBA", "B");

                    Program.simMain.setNode(cpRLB_1R, scr, "SRL3B-7C", "1", "RL3B", "1");
                    Program.simMain.setNode(cpRLB_7R, scr, "SRL3B-7C", "7C", "RL3B", "7");
                    Program.simMain.setNode(cpRLB_4R, scr, "SRL3B-7", "4", "RL3B", "4");
                    Program.simMain.setNode(cpRLB_AR, scr, "RL3B", "A", "RL3B", "A");
                    Program.simMain.setNode(cpRLB_BR, scr, "RL3B", "B", "RLBA", "B");

                    Program.RelayHandler SCR3_RL3BHandler = new Program.RelayHandler(Program.simMain, scr, "RL3B", 6);
                    #endregion
                    #region RL4
                    Program.simMain.setNode(cpRLC_1L, scr, "SRL4-7C", "1", "RL4", "1");
                    Program.simMain.setNode(cpRLC_7L, scr, "SRL4-7", "7", "RL4", "7");
                    Program.simMain.setNode(cpRLC_4L, scr, "SRL4-7", "4", "RL4", "4");
                    Program.simMain.setNode(cpRLC_2L, scr, "SRL4-8C", "2", "RL4", "2");
                    Program.simMain.setNode(cpRLC_8L, scr, "SRL4-8", "8", "RL4", "8");
                    Program.simMain.setNode(cpRLC_5L, scr, "SRL4-8", "5", "RL4", "5");
                    Program.simMain.setNode(cpRLC_3L, scr, "SRL4-9C", "3", "RL4", "3");
                    Program.simMain.setNode(cpRLC_9L, scr, "SRL4-9C", "9C", "RL4", "9");
                    Program.simMain.setNode(cpRLC_6L, scr, "SRL4-9", "6", "RL4", "6");
                    Program.simMain.setNode(cpRLC_AL, scr, "RL4", "A", "RL4", "A");
                    Program.simMain.setNode(cpRLC_BL, scr, "RL4", "B", "RL4", "B");

                    Program.simMain.setNode(cpRLC_1R, scr, "SRL4-7C", "1", "RL4", "1");
                    Program.simMain.setNode(cpRLC_7R, scr, "SRL4-7", "7", "RL4", "7");
                    Program.simMain.setNode(cpRLC_4R, scr, "SRL4-7", "4", "RL4", "4");
                    Program.simMain.setNode(cpRLC_2R, scr, "SRL4-8C", "2", "RL4", "2");
                    Program.simMain.setNode(cpRLC_8R, scr, "SRL4-8", "8", "RL4", "8");
                    Program.simMain.setNode(cpRLC_5R, scr, "SRL4-8", "5", "RL4", "5");
                    Program.simMain.setNode(cpRLC_3R, scr, "SRL4-9C", "3", "RL4", "3");
                    Program.simMain.setNode(cpRLC_9R, scr, "SRL4-9C", "9C", "RL4", "9");
                    Program.simMain.setNode(cpRLC_6R, scr, "SRL4-9", "6", "RL4", "6");
                    Program.simMain.setNode(cpRLC_AR, scr, "RL4", "A", "RL4", "A");
                    Program.simMain.setNode(cpRLC_BR, scr, "RL4", "B", "RL4", "B");

                    Program.RelayHandler SCR3_RL4Handler = new Program.RelayHandler(Program.simMain, scr, "RL4", 24);
                    #endregion
                    break;
                case 4:
                    #region RL12
                    Program.simMain.setNode(cpRLA_1L, scr, "SRL12-7C", "1", "RL12", "1");
                    Program.simMain.setNode(cpRLA_7L, scr, "SRL12-7", "7", "RL12", "7");
                    Program.simMain.setNode(cpRLA_4L, scr, "SRL12-7", "4", "RL12", "4");
                    Program.simMain.setNode(cpRLA_2L, scr, "SRL12-8C", "2", "RL12", "2");
                    Program.simMain.setNode(cpRLA_8L, scr, "SRL12-8", "8", "RL12", "8");
                    Program.simMain.setNode(cpRLA_5L, scr, "SRL12-8", "5", "RL12", "5");
                    Program.simMain.setNode(cpRLA_AL, scr, "RL12", "A", "RL12", "A");
                    cpRLA_AL.IsACVoltage = true;
                    Program.simMain.setNode(cpRLA_BL, scr, "RL12", "B", "RL12", "B");
                    cpRLA_BL.IsACVoltage = true;

                    Program.simMain.setNode(cpRLA_1R, scr, "SRL12-7C", "1", "RL12", "1");
                    Program.simMain.setNode(cpRLA_7R, scr, "SRL12-7", "7", "RL12", "7");
                    Program.simMain.setNode(cpRLA_4R, scr, "SRL12-7", "4", "RL12", "4");
                    Program.simMain.setNode(cpRLA_2R, scr, "SRL12-8C", "2", "RL12", "2");
                    Program.simMain.setNode(cpRLA_8R, scr, "SRL12-8", "8", "RL12", "8");
                    Program.simMain.setNode(cpRLA_5R, scr, "SRL12-8", "5", "RL12", "5");
                    Program.simMain.setNode(cpRLA_AR, scr, "RL12", "A", "RL12", "A");
                    cpRLA_AR.IsACVoltage = true;
                    Program.simMain.setNode(cpRLA_BR, scr, "RL12", "B", "RL12", "B");
                    cpRLA_BR.IsACVoltage = true;


                    Program.RelayHandler SCR4_RL12Handler = new Program.RelayHandler(Program.simMain, scr, "RL12", 115);
                    #endregion
                    #region RL2
                    Program.simMain.setNode(cpRLB_1L, scr, "SRL2-7C", "1", "RL2", "1");
                    Program.simMain.setNode(cpRLB_7L, scr, "SRL2-7", "7", "RL2", "7");
                    Program.simMain.setNode(cpRLB_4L, scr, "SRL2-7", "4", "RL2", "4");
                    Program.simMain.setNode(cpRLB_2L, scr, "SRL2-8C", "2", "RL2", "2");
                    Program.simMain.setNode(cpRLB_8L, scr, "SRL2-8", "8", "RL2", "8");
                    Program.simMain.setNode(cpRLB_5L, scr, "SRL2-8", "5", "RL2", "5");
                    Program.simMain.setNode(cpRLB_AL, scr, "RL2", "A", "RL2", "A");
                    Program.simMain.setNode(cpRLB_BL, scr, "RL2", "B", "RL2", "B");

                    Program.simMain.setNode(cpRLB_1R, scr, "SRL2-7C", "1", "RL2", "1");
                    Program.simMain.setNode(cpRLB_7R, scr, "SRL2-7", "7", "RL2", "7");
                    Program.simMain.setNode(cpRLB_4R, scr, "SRL2-7", "4", "RL2", "4");
                    Program.simMain.setNode(cpRLB_2R, scr, "SRL2-8C", "2", "RL2", "2");
                    Program.simMain.setNode(cpRLB_8R, scr, "SRL2-8", "8", "RL2", "8");
                    Program.simMain.setNode(cpRLB_5R, scr, "SRL2-8", "5", "RL2", "5");
                    Program.simMain.setNode(cpRLB_AR, scr, "RL2", "A", "RL2", "A");
                    Program.simMain.setNode(cpRLB_BR, scr, "RL2", "B", "RL2", "B");


                    Program.RelayHandler SCR4_RL2Handler = new Program.RelayHandler(Program.simMain, scr, "RL2", 6);
                    #endregion
                    break;

            }
        }
    }
}
