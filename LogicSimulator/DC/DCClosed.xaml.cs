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
    /// Interaction logic for DCClosed.xaml
    /// </summary>
    public partial class DCClosed : UserControl
    {
        SimCircuit simcircuit { get; set; }
        List<Program.LampHandler> lampList { get; set; }

        public DCClosed()
        {
            InitializeComponent();
        }

        public void configureDC(SimCircuit sc)
        {
            simcircuit = sc;

            #region LAMPS
            lampList = new List<Program.LampHandler>();
            lampList.Add(new Program.LampHandler(simcircuit, GEN1Lamp, "DC", "L1", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, GEN2Lamp, "DC", "L2", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, GEN3Lamp, "DC", "L3", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, GEN4Lamp, "DC", "L4", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));

            lampList.Add(new Program.LampHandler(simcircuit, SCR1Lamp, "DC", "L21", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, SCR2Lamp, "DC", "L22", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, SCR3Lamp, "DC", "L23", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, SCR4Lamp, "DC", "L24", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));

            lampList.Add(new Program.LampHandler(simcircuit, MP1Lamp, "DC", "L31", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, MP2Lamp, "DC", "L32", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, DWLamp, "DC", "L33", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, RTLamp, "DC", "L34", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));

            lampList.Add(new Program.LampHandler(simcircuit, SystemLamp, "DC", "L35", 28, "/SCRLogic;component/Resources/LAMP-RED-OFF.png", "/SCRLogic;component/Resources/LAMP-RED-ON.png"));

            lampList.Add(new Program.LampHandler(simcircuit, CP1Lamp, "DC", "L26", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));
            lampList.Add(new Program.LampHandler(simcircuit, CP2Lamp, "DC", "L36", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));

            lampList.Add(new Program.LampHandler(simcircuit, PTLamp, "DC", "L25", 28, "/SCRLogic;component/Resources/LAMP-GREEN-OFF.png", "/SCRLogic;component/Resources/LAMP-GREEN-ON.png"));
            #endregion
            #region SWITCHES
            int[] positions = { 8, 9, 10, 11, 12, 1, 2, 3, 4 };
            Program.AssignmentSwitchContacts assignmentContacts = new Program.AssignmentSwitchContacts();
            foreach (int i in positions)
            {
                assignmentContacts.contacts[i].Add(new Program.SwitchContact(simcircuit, "DC", "S1-A" + i.ToString(), false));
                assignmentContacts.contacts[i].Add(new Program.SwitchContact(simcircuit, "DC", "S1-C" + i.ToString(), false));
                assignmentContacts.contacts[i].Add(new Program.SwitchContact(simcircuit, "DC", "S1-E" + i.ToString(), false));
                assignmentContacts.contacts[i].Add(new Program.SwitchContact(simcircuit, "DC", "S1-G" + i.ToString(), false));
            }

            Program.SwitchContacts mp1Contacts = new Program.SwitchContacts();
            mp1Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S2-1", false));
            mp1Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S2-3", false));
            mp1Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S2-5", false));
            mp1Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S2-7", false));

            Program.SwitchContacts mp2Contacts = new Program.SwitchContacts();
            mp2Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S4-1", false));
            mp2Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S4-3", false));
            mp2Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S4-5", false));
            mp2Contacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S4-7", false));

            Program.SwitchContacts dwContacts = new Program.SwitchContacts();
            dwContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-3", false));
            dwContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-7", false));
            dwContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-11", false));
            dwContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-15", false));

            dwContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-1", false));
            dwContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-5", false));
            dwContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-9", false));
            dwContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S5-13", false));

            Program.SwitchContacts rtContacts = new Program.SwitchContacts();
            rtContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-3", false));
            rtContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-7", false));
            rtContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-11", false));
            rtContacts.leftContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-15", false));

            rtContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-1", false));
            rtContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-5", false));
            rtContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-9", false));
            rtContacts.rightContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S6-13", false));

            Program.SwitchAssignmentHandler ass = new Program.SwitchAssignmentHandler(simcircuit, AssignmentSwitch, "DC", "S1", assignmentContacts);

            Program.SwitchTwoPositionHandler mp1S = new Program.SwitchTwoPositionHandler(simcircuit, MP1Switch, "DC", "S2", mp1Contacts);
            Program.SwitchTwoPositionHandler mp2S = new Program.SwitchTwoPositionHandler(simcircuit, MP2Switch, "DC", "S4", mp2Contacts);
            Program.SwitchThreePositionHandler dwS = new Program.SwitchThreePositionHandler(simcircuit, DWSwitch, "DC", "S5", dwContacts);
            Program.SwitchThreePositionHandler rtS = new Program.SwitchThreePositionHandler(simcircuit, RTSwitch, "DC", "S6", rtContacts);
            #endregion
            #region PUSHBUTTONS
            Program.PushbuttonHandler ems = new Program.PushbuttonHandler(simcircuit, EMStop, "DC", "S3", "/SCRLogic;component/Resources/EM-STOP-UP.png", "/SCRLogic;component/Resources/EM-STOP-DOWN.png");
            ems.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S3-1", true));
            ems.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S3-3", true));
            ems.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S3-5", true));
            ems.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S3-7", true));
            ems.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S3-9", false));
            Program.PushbuttonHandler als = new Program.PushbuttonHandler(simcircuit, AlarmSilence, "DC", "S11", "/SCRLogic;component/Resources/PB-BLACK-UP.png", "/SCRLogic;component/Resources/PB-BLACK-DOWN.png");
            als.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S11-1", false));
            als.switchContacts.Add(new Program.SwitchContact(simcircuit, "DC", "S11-3", false));
            #endregion
            #region AMMETER
            Ammeter.configureMeter("PANEL-METER-SCALE-1000ADC.png", "DC", "RM1");
            #endregion

        }
    }
}
