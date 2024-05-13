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
    /// Interaction logic for MCCRelay.xaml
    /// </summary>
    public partial class MCCRelay : UserControl
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer;
        public List<Program.MCCInterface> mccInterfaces;

        private Program.RelayHandler RLMP1B { get; set; }
        private Program.RelayHandler RL3A { get; set; }
        private Program.RelayHandler RL3B { get; set; }
        private Program.RelayHandler RK3 { get; set; }
        private Program.RelayHandler RLMP1AFL { get; set; }
        private Program.RelayHandler RLMP1BFL { get; set; }
        private Program.RelayHandler RLMP1AFLD { get; set; }
        private Program.RelayHandler RLMP1BFLD { get; set; }
        private Program.RelayHandler RLCP1 { get; set; }
        private Program.RelayHandler RLMP1HTMS { get; set; }

        private Program.RelayHandler RLMP2B { get; set; }
        private Program.RelayHandler RL4A { get; set; }
        private Program.RelayHandler RL4B { get; set; }
        private Program.RelayHandler RK4 { get; set; }
        private Program.RelayHandler RLMP2AFL { get; set; }
        private Program.RelayHandler RLMP2BFL { get; set; }
        private Program.RelayHandler RLMP2AFLD { get; set; }
        private Program.RelayHandler RLMP2BFLD { get; set; }
        private Program.RelayHandler RLCP2 { get; set; }
        private Program.RelayHandler RLMP2HTMS { get; set; }

        private Program.RelayHandler RLDWAB { get; set; }
        private Program.RelayHandler RLDWBB { get; set; }
        private Program.RelayHandler RL2A { get; set; }
        private Program.RelayHandler RL2B { get; set; }
        private Program.RelayHandler RK2 { get; set; }
        private Program.RelayHandler RLDWAFL { get; set; }
        private Program.RelayHandler RLDWBFL { get; set; }
        private Program.RelayHandler RLDWAFLD { get; set; }
        private Program.RelayHandler RLDWBFLD { get; set; }
        private Program.RelayHandler RLDWON { get; set; }

        private Program.RelayHandler RLRTB { get; set; }
        private Program.RelayHandler RL1 { get; set; }
        private Program.RelayHandler RK1 { get; set; }
        private Program.RelayHandler RLRTFL { get; set; }
        private Program.RelayHandler RLRTFLD { get; set; }
        private Program.RelayHandler RLRTON { get; set; }

        public MCCRelay()
        {
            InitializeComponent();

            mccInterfaces = new List<Program.MCCInterface>();
            // TODO: for quick debugging hide MCC
           
            MCC mcc = Program.mainWindow.mccTabControl.MCCControl;


            #region MP1
            RLMP1B = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1B", 24);
            RL3A = new Program.RelayHandler(Program.simMain, "MCC", "RL3A", 110);
            RL3B = new Program.RelayHandler(Program.simMain, "MCC", "RL3B", 110);
            RK3 = new Program.RelayHandler(Program.simMain, "MCC", "RK3", 110);
            RLMP1AFL = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1AFL", 110);
            RLMP1BFL = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1BFL", 110);
            RLMP1AFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1AFLD", 24);
            RLMP1BFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1BFLD", 24);
            RLMP1HTMS = new Program.RelayHandler(Program.simMain, "MCC", "RLMP1HTMS", 24);

            // BLOWER A
            MCCCan can = mcc.B1;
            mccInterfaces.Add(new Program.MCCInterface("MP1A BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP1B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1AB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1AB-ALARM")));
            //BLOWER B
            can = mcc.B2;
            mccInterfaces.Add(new Program.MCCInterface("MP1B BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP1B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1BB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1BB-ALARM")));
            // CHAIN OILER
            can = mcc.B3;
            mccInterfaces.Add(new Program.MCCInterface("MP1 ROD OILER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP1B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1RO-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1RO-ALARM")));
            // ROD OILER
            can = mcc.B4;
            mccInterfaces.Add(new Program.MCCInterface("MP1 CHAIN OILER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP1B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1CO-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP1CO-ALARM")));
            // CHARGE PUMP 1
            RLCP1 = new Program.RelayHandler(Program.simMain, "MCC", "RLCP1", 24);
            can = mcc.B5;
            mccInterfaces.Add(new Program.MCCInterface("CHARGE PUMP 1", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLCP1,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-CP1-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-CP1-ALARM")));

            #endregion
            #region MP2
            RLMP2B = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2B", 24);
            RL4A = new Program.RelayHandler(Program.simMain, "MCC", "RL4A", 110);
            RL4B = new Program.RelayHandler(Program.simMain, "MCC", "RL4B", 110);
            RK4 = new Program.RelayHandler(Program.simMain, "MCC", "RK4", 110);
            RLMP2AFL = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2AFL", 110);
            RLMP2BFL = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2BFL", 110);
            RLMP2AFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2AFLD", 24);
            RLMP2BFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2BFLD", 24);
            RLMP2HTMS = new Program.RelayHandler(Program.simMain, "MCC", "RLMP2HTMS", 24);

            // BLOWER A
            can = mcc.C1;
            mccInterfaces.Add(new Program.MCCInterface("MP2A BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP2B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2AB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2AB-ALARM")));
            // BLOWER B
            can = mcc.C2;
            mccInterfaces.Add(new Program.MCCInterface("MP2b BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP2B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2BB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2BB-ALARM")));
            // CHAIN OILER
            can = mcc.C3;
            mccInterfaces.Add(new Program.MCCInterface("MP2 ROD OILER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP2B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2RO-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2RO-ALARM")));
            // ROD OILER
            can = mcc.C4;
            mccInterfaces.Add(new Program.MCCInterface("MP2 CHAIN OILER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLMP2B,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2CO-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-MP2CO-ALARM")));
            // CHARGE PUMP 2
            RLCP2 = new Program.RelayHandler(Program.simMain, "MCC", "RLCP2", 24);
            can = mcc.C5;
            mccInterfaces.Add(new Program.MCCInterface("CHARGE PUMP 2", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLCP2,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-CP2-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-CP2-ALARM")));

            #endregion
            #region RT

            RLRTB = new Program.RelayHandler(Program.simMain, "MCC", "RLRTB", 24);
            RL1 = new Program.RelayHandler(Program.simMain, "MCC", "RL1", 110);
            RK1 = new Program.RelayHandler(Program.simMain, "MCC", "RK1", 110);
            RLRTFL = new Program.RelayHandler(Program.simMain, "MCC", "RLRTFL", 110);
            RLRTFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLRTFLD", 24);
            RLRTON = new Program.RelayHandler(Program.simMain, "MCC", "RLRTON", 24);

            can = mcc.A1;
            mccInterfaces.Add(new Program.MCCInterface("RT BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLRTB,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-RTB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-RTB-ALARM")));

            #endregion
            #region DW
            RLDWAB = new Program.RelayHandler(Program.simMain, "MCC", "RLDWAB", 24);
            RLDWBB = new Program.RelayHandler(Program.simMain, "MCC", "RLDWBB", 24);
            RL2A = new Program.RelayHandler(Program.simMain, "MCC", "RL2A", 110);
            RL2B = new Program.RelayHandler(Program.simMain, "MCC", "RL2B", 110);
            RK2 = new Program.RelayHandler(Program.simMain, "MCC", "RK2", 110);
            RLDWAFL = new Program.RelayHandler(Program.simMain, "MCC", "RLDWAFL", 110);
            RLDWBFL = new Program.RelayHandler(Program.simMain, "MCC", "RLDWBFL", 110);
            RLDWAFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLDWAFLD", 24);
            RLDWBFLD = new Program.RelayHandler(Program.simMain, "MCC", "RLDWBFLD", 24);
            RLDWON = new Program.RelayHandler(Program.simMain, "MCC", "RLDWON", 24);

            can = mcc.A2;
            mccInterfaces.Add(new Program.MCCInterface("DWA BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLDWAB,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-DWAB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-DWAB-ALARM")));
            
            can = mcc.A3;
            mccInterfaces.Add(new Program.MCCInterface("DWB BLOWER", can,
                can.simCan.getElementByLocationAndNettag("CAN", "SPB21"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NO1"),
                can.simCan.getElementByLocationAndNettag("CAN", "SC1-NC1"),
                RLDWBB,
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-DWBB-RUN"),
                Program.simMain.getElementByLocationAndNettag("MCC", "SMCC-DWBB-ALARM")));
            #endregion

            //Program.simMain.TickComplete += dispatcherTimer_Tick;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(System.Windows.Threading.DispatcherPriority.Normal);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dispatcherTimer.Start(); 


        }

        bool timerLock = false;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (timerLock)
            {
                Debug.Log("Exiting re-entry");
                return;
            }
            timerLock = true;

            foreach (Program.MCCInterface m in mccInterfaces)
            {
                foreach (Program.VoltageSourceHook h in m.voltageSourceHooks)
                {
                    h.doHookUp();
                }
            }

            timerLock = false;
        }


    }


}
