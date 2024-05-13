using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCircuit
{
    public class AlarmPCB
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer { get; set; }

        public class AlarmChannel
        {
            public int channelNumber { get; set; }
            public NetElement inputPin { get; set; }
            public NetElement lampPin { get; set; }
            public bool silenced { get; set; } = false;
            public bool alarmed { get; set; } = false;
            private double alarmVoltage { get; set; } = -12.0;

            private bool _isFaulty;
            public bool isFaulty
            {
                get
                {
                    return (_isFaulty);
                }
                set
                {
                    if (_isStuck) isStuck = false;
                    _isFaulty = value;
                }
            }

            private bool _isStuck;
            public bool isStuck
            {
                get
                {
                    return (_isStuck);
                }
                set
                {
                    if (_isFaulty) isFaulty = false;
                    _isStuck = value;
                }
            }

            public AlarmChannel(int c, SimCircuit sc, string ip, string lp)
            {
                channelNumber = c;
                inputPin = sc.getElementByLocationAndNettag("DC", ip);
                lampPin = sc.getElementByLocationAndNettag("DC", lp);
            }

            public void processInput(bool silencepressed)
            {
                Probe p = inputPin.simElement as Probe;
                if (_isFaulty)
                {
                    alarmed = false;
                    silenced = silencepressed || silenced;
                }
                else if (_isStuck)
                {
                    alarmed = true;
                    silenced = false;
                }
                else
                {
                    if (p.getLeadVoltage(0) < (alarmVoltage * 0.8))
                    {
                        alarmed = true;
                        silenced = silencepressed || silenced;
                    }
                    else
                    {
                        alarmed = false;
                        silenced = false;
                    }
                }
            }
        }

        public List<AlarmChannel> alarmChannels { get; set; }
        public NetElement alarmSilence { get; set; }
        public bool flashState { get; set; } = false;
        public int flashCount { get; set; } = 4;
        public int flashCounter { get; set; } = 0;
        public NetElement flashOutput { get; set; }
        public NetElement alarmOutput { get; set; }
        public NetElement supplyPlus { get; set; }
        public NetElement supplyMinus { get; set; }
        private double supplyVoltage { get; set; } = 12.0;

        public AlarmPCB()
        {
            supplyPlus = Program.simMain.getElementByLocationAndNettag("DC", "XPC2-08");
            supplyMinus= Program.simMain.getElementByLocationAndNettag("DC", "XPC2-19");

            alarmChannels = new List<AlarmChannel>();
            alarmChannels.Add(new AlarmChannel(1, Program.simMain, "XPC2-02", "VPC2-03"));
            alarmChannels.Add(new AlarmChannel(2, Program.simMain, "XPC2-04", "VPC2-04"));
            alarmChannels.Add(new AlarmChannel(3, Program.simMain, "XPC2-06", "VPC2-07"));
            alarmChannels.Add(new AlarmChannel(4, Program.simMain, "XPC2-11", "VPC2-12"));
            alarmChannels.Add(new AlarmChannel(5, Program.simMain, "XPC2-13", "VPC2-14"));
            alarmChannels.Add(new AlarmChannel(6, Program.simMain, "XPC2-15", "VPC2-16"));

            flashOutput = Program.simMain.getElementByLocationAndNettag("DC", "VPC2-18");
            alarmOutput = Program.simMain.getElementByLocationAndNettag("DC", "VPC2-17");
            alarmSilence = Program.simMain.getElementByLocationAndNettag("DC", "XPC2-01");

            Program.simMain.TimerComplete += dispatcherTimer_Tick;

            /*dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dispatcherTimer.Start();    */
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if ((supplyMinus.simElement.getLeadVoltage(0) < (-supplyVoltage * 0.8)) && (supplyPlus.simElement.getLeadVoltage(0) > (supplyVoltage * 0.8)))
            {
                bool alarm = false;
                bool silencepressed = false;

                if ((alarmSilence.simElement as Probe).getLeadVoltage(0) < (-supplyVoltage * 0.8))
                {
                    silencepressed = true;
                }
                else
                {
                    silencepressed = false;
                }

                foreach (AlarmChannel a in alarmChannels)
                {
                    a.processInput(silencepressed);
                    if (a.alarmed && !a.silenced) alarm = true;
                }

                flashCounter--;
                if ((flashCounter == 0) && alarm)
                {
                    flashState = !flashState;
                    flashCounter = flashCount;
                }
                else
                {
                    flashState = false;
                    if (!alarm) flashCounter = flashCount;
                }

                if (silencepressed)
                {
                    (flashOutput.simElement as VoltageInput).maxVoltage = +supplyVoltage;
                    foreach (AlarmChannel a in alarmChannels)
                    {
                        (a.lampPin.simElement as VoltageInput).maxVoltage = -supplyVoltage;
                    }
                }
                else
                {
                    double flashVoltage = 0;
                    if (flashState)
                    {
                        
                        flashVoltage = -supplyVoltage;
                    }
                    else
                    {
                        flashVoltage = +supplyVoltage;
                    }
                    (flashOutput.simElement as VoltageInput).maxVoltage = flashVoltage;
                    foreach (AlarmChannel a in alarmChannels)
                    {

                        if (a.alarmed)
                        {
                            (a.lampPin.simElement as VoltageInput).maxVoltage = -supplyVoltage;
                        }
                        else
                        {
                            (a.lampPin.simElement as VoltageInput).maxVoltage = flashVoltage;
                        }
                    }
                }
                if (alarm)
                {
                    (alarmOutput.simElement as VoltageInput).maxVoltage = -supplyVoltage;
                }
                else
                {
                    (alarmOutput.simElement as VoltageInput).maxVoltage = +supplyVoltage;
                }
            }
            else
            {
                (flashOutput.simElement as VoltageInput).maxVoltage = supplyVoltage;
                (alarmOutput.simElement as VoltageInput).maxVoltage = supplyVoltage;
                foreach (AlarmChannel a in alarmChannels)
                {
                    (a.lampPin.simElement as VoltageInput).maxVoltage = supplyVoltage;
                }
            }
        }
    }
}
