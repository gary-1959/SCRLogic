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
    /// Interaction logic for DCOpen.xaml
    /// </summary>
    public partial class DCOpen : UserControl
    {
        public AlarmPCB PC2 { get; set; }

        public SimCircuit simcircuit { get; set; }
        public DCOpen()
        {
            InitializeComponent();
        }

        public void configureDC(SimCircuit sc)
        {
            simcircuit = sc;

            Program.refPos("DC", "POT1", 0);
            Program.refPos("DC", "POT2", 0);
            Program.refPos("DC", "POT3", 0);
            Program.refPos("DC", "POT4", 0);
            Program.refPos("DC", "POT5", 0);

            #region TB01
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB01_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB01_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "1-" + i.ToString(), "TB1", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "1-" + i.ToString(), "TB1", i.ToString());
            }
            #endregion
            #region TB02
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB02_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB02_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "2-" + i.ToString(), "TB2", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "2-" + i.ToString(), "TB2", i.ToString());
            }
            #endregion
            #region TB03
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB03_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB03_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "3-" + i.ToString(), "TB3", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "3-" + i.ToString(), "TB3", i.ToString());
            }
            #endregion
            #region TB04
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB04_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB04_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "4-" + i.ToString(), "TB4", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "4-" + i.ToString(), "TB4", i.ToString());
            }
            #endregion
            #region TB05
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB05_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB05_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "5-" + i.ToString(), "TB5", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "5-" + i.ToString(), "TB5", i.ToString());
            }
            #endregion
            #region TB06
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB06_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB06_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "6-" + i.ToString(), "TB6", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "6-" + i.ToString(), "TB6", i.ToString());
            }
            #endregion
            #region TB07
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB07_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB07_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "X07" + lZ, i.ToString(), "TB7", i.ToString());
                Program.simMain.setNode(cpR, "DC", "X07" + lZ, i.ToString(), "TB7", i.ToString());
            }
            #endregion
            #region TB08
            for (int i = 1; i <= 19; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpTB08_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, "DC", "X08" + lZ, i.ToString(), "TB8", i.ToString());
            }
            #endregion
            #region TB09
            for (int i = 1; i <= 19; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpTB09_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, "DC", "X09" + lZ, i.ToString(), "TB9", i.ToString());
            }
            #endregion
            #region TB10
            for (int i = 1; i <= 11; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpL = FindName("cpTB10_" + lZ + "L") as CircuitPoint;
                CircuitPoint cpR = FindName("cpTB10_" + lZ + "R") as CircuitPoint;
                Program.simMain.setNode(cpL, "DC", "ITB", "10-" + i.ToString(), "TB10", i.ToString());
                Program.simMain.setNode(cpR, "DC", "ITB", "10-" + i.ToString(), "TB10", i.ToString());
            }
            #endregion
            #region TB11
            for (int i = 1; i <= 11; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpTB11_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, "DC", "X11" + lZ, i.ToString(), "TB11", i.ToString());
            }
            #endregion
            #region PC1
            for (int i = 1; i <= 40; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpPC1_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, "DC", "XPC1-" + lZ, i.ToString(), "PC1", i.ToString());
            }
            #endregion
            #region PC2
            for (int i = 1; i <= 20; i++)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cp = FindName("cpPC2_" + lZ) as CircuitPoint;
                Program.simMain.setNode(cp, "DC", "XPC2-" + lZ, i.ToString(), "PC2", i.ToString());
            }

            PC2 = new AlarmPCB();
            /*
            Program.RelayHandler rla1 = new Program.RelayHandler(Program.simMain, "DC", "RLA1", 24);
            rla1.auxContacts.Clear(); // not KUP type
            rla1.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA1-1", true));
            rla1.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA1-3", false));

            Program.RelayHandler rla2 = new Program.RelayHandler(Program.simMain, "DC", "RLA2", 24);
            rla2.auxContacts.Clear(); // not KUP type
            rla2.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA2-1", true));
            rla2.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA2-3", false));

            Program.RelayHandler rla3 = new Program.RelayHandler(Program.simMain, "DC", "RLA3", 24);
            rla3.auxContacts.Clear(); // not KUP type
            rla3.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA3-1", true));
            rla3.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA3-3", false));

            Program.RelayHandler rla4 = new Program.RelayHandler(Program.simMain, "DC", "RLA4", 24);
            rla4.auxContacts.Clear(); // not KUP type
            rla4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA4-1", true));
            rla4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA4-3", false));

            Program.RelayHandler rla5 = new Program.RelayHandler(Program.simMain, "DC", "RLA5", 24);
            rla5.auxContacts.Clear(); // not KUP type
            rla5.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA5-1", true));
            rla5.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA5-3", false));

            Program.RelayHandler rla6 = new Program.RelayHandler(Program.simMain, "DC", "RLA6", 24);
            rla6.auxContacts.Clear(); // not KUP type
            rla6.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA6-1", true));
            rla6.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA6-3", false));

            Program.RelayHandler rla7 = new Program.RelayHandler(Program.simMain, "DC", "RLA7", 24);
            rla7.auxContacts.Clear(); // not KUP type
            rla7.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA7-1", true));
            rla7.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLA7-3", false));

            Program.RelayHandler rlaf = new Program.RelayHandler(Program.simMain, "DC", "RLAF", 24, true);
            rlaf.auxContacts.Clear(); // not KUP type
            rlaf.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLAF-1", true));
            rlaf.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SRLAF-3", false)); */

            #endregion
            #region ALARM
            Program.simMain.setNode(cpALM_1, "DC", "RALM", "1", "ALARM", "1");
            Program.simMain.setNode(cpALM_2, "DC", "RALM", "2", "ALARM", "2");
            Program.KlaxonHandler hh = new Program.KlaxonHandler("DC", "RALM", 24);
            #endregion
            #region PS1
            Program.simMain.setNode(cpPS1_1, "DC", "SP1", "1", "PS1", "1");
            Program.simMain.setNode(cpPS1_2, "DC", "SP1", "2", "PS1", "2");
            #endregion
            #region K_PC1

            Program.RelayHandler K1 = new Program.RelayHandler(Program.simMain, "DC", "RK1", 24);
            K1.auxContacts.Clear(); // not KUP type
            K1.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK1-1", false));

            Program.RelayHandler K2 = new Program.RelayHandler(Program.simMain, "DC", "RK2", 24);
            K2.auxContacts.Clear(); // not KUP type
            K2.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK2-1", false));

            Program.RelayHandler K3 = new Program.RelayHandler(Program.simMain, "DC", "RK3", 24);
            K3.auxContacts.Clear(); // not KUP type
            K3.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK3-1", false));

            Program.RelayHandler K4 = new Program.RelayHandler(Program.simMain, "DC", "RK4", 24);
            K4.auxContacts.Clear(); // not KUP type
            K4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK4-13", false));
            K4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK4-23", false));
            K4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK4-33", false));
            K4.auxContacts.Add(new Program.SwitchContact(Program.simMain, "DC", "SK4-43", false));

            #endregion, 
        }


    }
}
