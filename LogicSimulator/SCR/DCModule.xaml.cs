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
    /// Interaction logic for DCModule.xaml
    /// </summary>
    public partial class DCModule : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        private int[] cont = { 112, 116, 120, 121, 124, 129 };
        private int[] ref1 = { 113, 117, 119, 122, 125, 130 };
        private int[] ref2 = { 110, 114, 118, 123, 126, 132 };
        private double[] ref2factor = { 1, 1, 1, 0.5, 0.5, 1 };
        private int[] iref = { 0, 0, 0, 0, 0, 128 };
        private int[] ilimMax = { 850, 1050, 850, 1600, 1600, 950 };
        private int[] ilimMin = { 0, 0, 0, 0, 0, 50 };

        public VoltageInput vBRPlus { get; set; }
        public VoltageInput vBRMinus { get; set; }
        private VoltageInput vIfb { get; set; }

        public VoltageInput vDWBPlus { get; set; }
        public VoltageInput vDWBMinus { get; set; }

        public BitmapImage LED_On { get; set; }
        public BitmapImage LED_Off { get; set; }

        public BitmapImage testSwitchUp { get; set; }
        public BitmapImage testSwitchDn { get; set; }

        public int thisSCR { get; set; }

        public SwitchSPST cbAux;

        private Program.SwitchContact testSwitchContact { get; set; }
        private double contMin = -10.0;
        private double refMin = -1.0;
        private bool? _ZTI;
        public bool ZTI
        {
            get
            {
                return (_ZTI == true);
            }
            set
            {
                if (value != _ZTI)
                {
                    _ZTI = value;
                    if (_ZTI == true)
                    {
                        LEDZTI.Source = LED_On;
                    }
                    else
                    {
                        LEDZTI.Source = LED_Off;
                    }
                }
            }
        }
        private bool? _isOn;
        public bool isOn
        {
            get
            {
                return (_isOn == true);
            }
            set
            {
                if (value != _isOn)
                {
                    _isOn = value;
                    if (_isOn == true)
                    {
                        LEDPower.Source = LED_On;
                        ZTI = true;
                    }
                    else
                    {
                        LEDPower.Source = LED_Off;
                        ZTI = true;
                    }
                }
            }
        }
        private double _testSwitchPosition;
        public double testSwitchPosition
        {
            get
            {
                return _testSwitchPosition;
            }
            set
            {
                double newpos;
                newpos = (value < -1 ? -1 : value);
                newpos = (value > 1 ? 1 : newpos);
                if (_testSwitchPosition != newpos)
                {
                    _testSwitchPosition = newpos;
                    if (_testSwitchPosition == 1)
                    {
                        VoltageSwitch.Source = testSwitchUp;
                        simcircuit.contactPos(testSwitchContact, true);
                        ZTI = true;
                    }
                    else
                    {
                        VoltageSwitch.Source = testSwitchDn;
                        simcircuit.contactPos(testSwitchContact, false);
                    }
                    Program.switchClick();
                }
            }
        }
        public int[] meterPositions = { 0, 153, 119, 118, 120, 128, 130, 129, 125, 124, 0, 121, 122, 112, 113, 110, 116, 117, 114, 154 };
        public DCModule()
        {
            InitializeComponent();


            LED_On = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/DCMODULE-LED-ON.png"));
            LED_Off = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/DCMODULE-LED-OFF.png"));

            testSwitchUp = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/DCMODULE-SWITCH-UP.png"));
            testSwitchDn = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/DCMODULE-SWITCH-DOWN.png"));

            LEDPower.Source = LED_Off;
            LEDZTI.Source = LED_Off;
            LEDOvercurrent.Source = LED_Off;


            VoltageSwitch.PreviewMouseWheel += OnPreviewMouseWheelVS;

            meterSwitchPosition = 0;
            MeterSwitch.PreviewMouseWheel += OnPreviewMouseWheelMS;

            voltageKnobPosition = 0;
            VoltageKnob.PreviewMouseWheel += OnPreviewMouseWheelVK;



        }
        #region METER_SWITCH
        private double switchLastAngle { get; set; }
        private int _meterSwitchPosition;
        public int meterSwitchPosition
        {
            get
            {
                return _meterSwitchPosition;
            }
            set
            {
                _meterSwitchPosition = (value < -10 ? 9 : value);
                _meterSwitchPosition = (value >= 10 ? -10 : _meterSwitchPosition);

                Meter.monitorPin = meterPositions[_meterSwitchPosition + 10];

                //Debug.Log("Position: " + (int)(_meterSwitchPosition + 10));

            }
        }

        private PanelMeter voltMeter { get; set; }
        private PanelMeter ampMeter { get; set; }

        void OnPreviewMouseWheelMS(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta > 0)
                {
                    meterSwitchPosition += 1;
                }
                if (e.Delta < 0)
                {
                    meterSwitchPosition += -1;
                }
                double angle = (18 * meterSwitchPosition);
                if (angle != switchLastAngle)
                {

                    RotateTransform rotateTransform = new RotateTransform(angle);
                    MeterSwitch.RenderTransform = rotateTransform;
                    switchLastAngle = angle;
                    Program.switchClick();
                }

                e.Handled = true;
            }
        }
        #endregion
        #region VOLTAGE_KNOB
        private double knobLastAngle { get; set; }
        private double _voltageKnobPosition;
        public double voltageKnobPosition
        {
            get
            {
                return _voltageKnobPosition;
            }
            set
            {
                _voltageKnobPosition = (value < -150 ? -150 : value);
                _voltageKnobPosition = (value > 150 ? 150 : _voltageKnobPosition);
            }
        }
        void OnPreviewMouseWheelVK(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta > 0)
                {
                    voltageKnobPosition += 10;
                }
                if (e.Delta < 0)
                {
                    voltageKnobPosition += -10;
                }
                double angle = (voltageKnobPosition);
                if (angle != knobLastAngle)
                {

                    RotateTransform rotateTransform = new RotateTransform(angle);
                    VoltageKnob.RenderTransform = rotateTransform;
                    knobLastAngle = angle;
                }

                e.Handled = true;
            }
        }
        #endregion
        #region TEST_SWITCH
        void OnPreviewMouseWheelVS(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta > 0)
                {
                    testSwitchPosition = 1;
                }
                if (e.Delta < 0)
                {
                    testSwitchPosition = -1;
                }

                e.Handled = true;
            }
        }
        #endregion
        public void configureDCM(SimCircuit sc, int scrNum, PanelMeter vM, PanelMeter aM)
        {
            simcircuit = sc;
            thisSCR = scrNum;
            string scr = "SCR" + scrNum.ToString();
            string sZ = scrNum.ToString("D2");

            NetElement v1 = simcircuit.getElementByLocationAndNettag("SCR1", "VDWB+");
            vDWBPlus = v1.simElement as VoltageInput;
            NetElement v2 = simcircuit.getElementByLocationAndNettag("SCR1", "VDWB-");
            vDWBMinus = v2.simElement as VoltageInput;

            CircuitPoint cpCB = new CircuitPoint();
            simcircuit.setNode(cpCB, scr, "SCB-5", "4", "SCB-5", "4");
            if (cpCB.node != null)
            {
                if (cpCB.node.parent != null)
                {
                    cbAux = (SwitchSPST)cpCB.node.parent.simElement;
                }
            }

            CircuitPoint cpVPlus = new CircuitPoint();
            CircuitPoint cpVMinus = new CircuitPoint();
            CircuitPoint cpI1 = new CircuitPoint();

            simcircuit.setNode(cpVPlus, scr, "VSCR+", "1", "VSCR+", "1");
            simcircuit.setNode(cpVMinus, scr, "VSCR-", "1", "VSCR-", "1");
            simcircuit.setNode(cpI1, scr, "VSCRI", "1", "VSCRI", "1");

            if (cpVPlus.node != null)
            {
                if (cpVPlus.node.parent != null)
                {
                    vBRPlus = (VoltageInput)cpVPlus.node.parent.simElement;
                }
            }

            if (cpVMinus.node != null)
            {
                if (cpVMinus.node.parent != null)
                {
                    vBRMinus = (VoltageInput)cpVMinus.node.parent.simElement;
                }
            }

            if (cpI1.node != null)
            {
                if (cpI1.node.parent != null)
                {
                    vIfb = (VoltageInput)cpI1.node.parent.simElement;
                }
            }


            voltMeter = vM;
            ampMeter = aM;


            Meter.configureMeter(scrNum, this);

            testSwitchContact = new Program.SwitchContact(simcircuit, scr, "STEST", true);
            testSwitchPosition = -1;

            for (int i = 101; i <= 156; i++)
            {
                string lZ = i.ToString("D3");
                CircuitPoint cp = FindName("cpDCM_" + lZ) as CircuitPoint;
                {
                    simcircuit.setNode(cp, scr, "XDCM-" + lZ, i.ToString(), "DCM", i.ToString());
                }

                if (i >=103 && i <=108)
                {
                    cp.IsACVoltage = true;
                }

            }

            simcircuit.setNode(cpVPlus, scr, "XDCM-101", "101", "DCM", "V+");
            simcircuit.setNode(cpVMinus, scr, "XDCM-102", "102", "DCM", "V-");
            simcircuit.setNode(cpAPlus, scr, "XDCM-131", "131", "DCM", "I+");
            simcircuit.setNode(cpAMinus, scr, "XDCM-155", "155", "DCM", "I-");

            Program.TickComplete += tickCompleteHandler;

        }
        public void tickCompleteHandler(object sender, EventArgs e)
        {
            if ((voltageAt(153) > 10) && (voltageAt(154) < -10))
            {
                isOn = true;
            }
            else
            {
                isOn = false;
            }
            motorSim();
            ZeroThrottleInterlock();
        }
        private void ZeroThrottleInterlock()
        {

            if (isOn)
            {
                // voltages are negative
                if (ZTI)
                {
                    for (int i = cont.GetLowerBound(0); i <= cont.GetUpperBound(0); i++)
                    {
                        if ((voltageAt(cont[i]) < contMin) && (voltageAt(ref1[i]) > refMin) && (voltageAt(ref2[i]) > refMin) && testSwitchPosition != 1)
                        {
                            ZTI = false;
                            break;
                        }
                    }
                }
                else
                {
                    bool assigned = false;
                    for (int i = cont.GetLowerBound(0); i <= cont.GetUpperBound(0); i++)
                    {
                        if (voltageAt(cont[i]) < contMin)
                        {
                            assigned = true;
                        }
                    }
                    if (!assigned || testSwitchPosition == 1) ZTI = true;
                }
            }
            else
            {
                ZTI = true;
            }
        }
        private double voltageAt(int pin)
        {
            CircuitPoint cp = FindName("cpDCM_" + pin) as CircuitPoint;
            if (cp == null) return 0;
            if (cp.node == null) return 0;
            if (cp.node.parent == null) return 0;
            if (cp.node.parent.simElement == null) return 0;
            return (cp.node.parent.simElement.getLeadVoltage(0));
        }

        #region MOTOR_SIM
        public double scrVolts { get; set; }
        public double scrAmps { get; set; }
        private double ftRamp;

        private void motorSim()
        {
            double iLim = 0;
            if ((isOn) && (cbAux.IsOpen == false))
            {
                if (testSwitchPosition == 1)        // in test
                {
                    scrVolts = ((voltageKnobPosition + 150) / (300)) * 1000;
                    scrAmps = 20;
                }
                else
                {
                    if (ZTI)
                    {
                        scrAmps = 0;
                        scrVolts = 0;
                    }
                    else
                    {
                        double speedRef = 0;
                        double iLimRef = -10;
                        for (int i = cont.GetLowerBound(0); i <= cont.GetUpperBound(0); i++)
                        {
                            if (voltageAt(cont[i]) < contMin)
                            {
                                double r1 = 0;
                                double r2 = 0;

                                if (iref[i] != 0)
                                {
                                    iLimRef = voltageAt(iref[i]);
                                }
                                iLim += ilimMin[i] + (((ilimMax[i] - ilimMin[i]) * -iLimRef) / 10);

                                if (cont[i] == 116)
                                {
                                    r1 = -voltageAt(ref1[i]);
                                    r2 = -ref2factor[i] * voltageAt(ref2[i]);

                                    double iError = ((r2 / 10) * iLim) - scrAmps;
                                    if (iError > 0)
                                    {
                                        ftRamp += 0.2;
                                    }
                                    else
                                    {
                                        ftRamp -= 0.2;
                                    }

                                    //Debug.Log("FT Ramp: " + ftRamp);

                                    ftRamp = (ftRamp > 10 ? 10 : ftRamp);
                                    ftRamp = (ftRamp < 0 ? 0 : ftRamp);

                                    r1 += ftRamp;
                                }
                                else
                                {
                                    r1 = -voltageAt(ref1[i]);
                                    r2 = -ref2factor[i] * voltageAt(ref2[i]);
                                    if (r2 > r1) r1 = r2;
                                }

                                speedRef += r1;

                            }
                        }

                        speedRef = speedRef / 10;
                        speedRef = (speedRef > 1 ? 1 : speedRef);

                        scrVolts = 1000 * speedRef;
                        scrAmps = iLim * speedRef;

                    }
                }
            }
            else
            {
                scrAmps = 0;
                scrVolts = 0;
            }

            if ((vBRPlus != null) && (vBRMinus != null))
            {
                vBRPlus.maxVoltage = (scrVolts) / 2;
                vBRMinus.maxVoltage = -(scrVolts) / 2;
            }

            // look for DWB assigned to SCR1 or SCR 3
            if (thisSCR == 1 || thisSCR == 3)
            {
                if (voltageAt(116) < contMin)
                {
                    Program.DWBAssigned = thisSCR;
                }
                else if (thisSCR == Program.DWBAssigned)
                {
                    Program.DWBAssigned = 0;
                }
            }
            if (Program.DWBAssigned == thisSCR)
            {
                vDWBPlus.maxVoltage = (scrVolts) / 2;
                vDWBMinus.maxVoltage = -(scrVolts) / 2;
            }
            if (Program.DWBAssigned == 0)
            {
                vDWBPlus.maxVoltage = 0;
                vDWBMinus.maxVoltage = 0;
            }

            if (vIfb != null)
            {
                vIfb.maxVoltage = scrAmps;
            }
        }

        #endregion
    }
}
