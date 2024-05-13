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
using WpfAnimatedGif;

namespace SharpCircuit
{
    /// <summary>
    /// Interaction logic for BlowerContactor.xaml
    /// </summary>
    public partial class BlowerContactor : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        private double contactorVolume { get; set; } = 0.8;
        private double blowerVolume { get; set; } = 0.5;
        private MediaPlayer blowerRunningPlayer1 = new MediaPlayer();
        private MediaPlayer blowerRunningPlayer2 = new MediaPlayer();
        private MediaPlayer contactorClickPlayer = new MediaPlayer();
        private BitmapImage imageOpen { get; set; }
        private BitmapImage imageClosed { get; set; }
        private BitmapImage imageTripUp { get; set; }
        private BitmapImage imageTripDn { get; set; }
        private BitmapImage imageResetUp { get; set; }
        private BitmapImage imageResetDn { get; set; }
        private Image blowerImage { get; set; }
        private BitmapImage blowerStopped { get; set; }
        private BitmapImage blowerRunning { get; set; }
        public List<Program.SwitchContact> mainContacts;
        public List<Program.SwitchContact> overloadContacts;
        public Resistor coil { get; set; }
        private double coilVoltage { get; set; }
        private bool _isClosed;
        public bool isClosed
        {
            get
            {
                return (_isClosed);
            }
            set
            {
                if (value != _isClosed)
                {
                    if (value)
                    {
                        Indicator.Source = imageClosed;
                        contactorClick();
                        //blowerImage.Source = blowerRunning;
                        ImageBehavior.SetAnimatedSource(blowerImage, blowerRunning);
                        blowerRun();
                        _isClosed = true;
                        setAuxContacts();
                    }
                    else
                    {
                        if (!isStuck)
                        {
                            Indicator.Source = imageOpen;
                            contactorClick();
                            //blowerImage.Source = blowerStopped;
                            ImageBehavior.SetAnimatedSource(blowerImage, blowerStopped);
                            blowerStop();
                            _isClosed = false;
                            setAuxContacts();
                        }
                    }

                }
            }
        }
        private bool _isFaulty;
        public bool isFaulty
        {
            get
            {
                return _isFaulty;
            }
            set
            {
                _isFaulty = value;
                isClosed = false;
            }
        }
        private bool _isStuck;
        public bool isStuck
        {
            get
            {
                return _isStuck;

            }
            set
            {
                _isStuck = value;
            }
        }
        private bool _isTripped;
        public bool isTripped
        {
            get
            {
                return (_isTripped);
            }
            set
            {
                if (value != _isTripped)
                {
                    if (value)
                    {
                        Trip.Source = imageTripUp;
                        _isTripped = value;
                        isClosed = false;   // sets AUX contacts
                    }
                    else
                    {
                        Trip.Source = imageTripDn;
                        _isTripped = value;
                        setAuxContacts();
                    }
                }
            }
        }
        public string location { get; set; }
        public BlowerContactor()
        {
            InitializeComponent();

            mainContacts = new List<Program.SwitchContact>();
            overloadContacts = new List<Program.SwitchContact>();

            imageOpen = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-OPEN.png"));
            imageClosed = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-CLOSED.png"));

            imageTripUp = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-TRIP-UP.png"));
            imageTripDn = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-TRIP-DOWN.png"));

            imageResetUp = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-RESET-UP.png"));
            imageResetDn = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-CONTACTOR-RESET-DOWN.png"));

            blowerStopped = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-ANIM-STOPPED.gif"));
            blowerRunning = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/BLOWER-ANIM.gif"));

            contactorClickPlayer.Open(new Uri(@"Resources\thunk_switch.mp3", UriKind.Relative));
            blowerRunningPlayer1.Open(new Uri(@"Resources\power_plant_ambience_with_constant_light_roar_cut.mp3", UriKind.Relative));
            blowerRunningPlayer2.Open(new Uri(@"Resources\power_plant_ambience_with_constant_light_roar_cut.mp3", UriKind.Relative));

            Indicator.Source = imageOpen;
            Trip.Source = imageTripDn;
            Reset.Source = imageResetUp;

            coilVoltage = 115;

            Reset.MouseLeftButtonDown += MouseDownReset;
            Reset.MouseLeftButtonUp += MouseUpReset;

            blowerRunningPlayer1.MediaEnded += Media_Ended;
            blowerRunningPlayer2.MediaEnded += Media_Ended;

            Program.TickComplete += tickCompleteHandler;
            Program.OnSoundMuteChange += SoundMuteHandler;
        }

        public void contactorClick()
        {
            double v = contactorVolume;
            if (Program.soundMute) v = 0;
            contactorClickPlayer.Volume = v;
            contactorClickPlayer.Position = new TimeSpan(0, 0, 0);
            contactorClickPlayer.Play();
        }

        public void tickCompleteHandler(object sender, EventArgs e)
        {
            if (coil != null)
            {
                if ((Program.isCoilEnergised(coil, coilVoltage)) && (_isClosed == false) && (_isTripped == false) && (isFaulty==false) &&  (!isStuck || (isStuck && _isClosed == false)))
                {
                    isClosed = true;
                }
                else if (!Program.isCoilEnergised(coil, coilVoltage))
                {
                    if (!isStuck)
                    {
                        isClosed = false;
                    }
                }
                else if (_isTripped && !isStuck)
                {
                    isClosed = false;
                }
            }

            if (!isClosed) blowerStop();

        }
        private void MouseUpReset(object sender, MouseButtonEventArgs e)
        {
            Reset.Source = imageResetUp;
            e.Handled = true;
        }

        private void MouseDownReset(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Reset.Source = imageResetDn;
                isTripped = false;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

        }

        public void setAuxContacts()
        {
            foreach (Program.SwitchContact c in overloadContacts)
            {
                simcircuit.contactPos(c, _isTripped);
            }

            foreach (Program.SwitchContact c in mainContacts)
            {
                simcircuit.contactPos(c, _isClosed);
            }
        }

        public void configureBlowerContactor(SimCircuit sc, string scr, Image blower)
        {
            simcircuit = sc;
            location = scr;
            blowerImage = blower;
            blowerImage.Source = blowerStopped;

            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-1", false));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-3", false));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-5", false));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-NO1", false));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-NC1", true));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-NO2", false));
            mainContacts.Add(new Program.SwitchContact(simcircuit, scr, "SC1-NC2", true));

            overloadContacts.Add(new Program.SwitchContact(simcircuit, scr, "SOL1-13", true));
            overloadContacts.Add(new Program.SwitchContact(simcircuit, scr, "SOL1-15", false));

            foreach (KeyValuePair<string, NetElement> el in simcircuit.elements)
            {
                if (el.Value.location == scr)
                {
                    if (el.Value.nettag == "RC1")
                    {
                        coil = (Resistor)el.Value.simElement;
                        break;
                    }
                }

            }
            #region BLOWER_CONTACTOR
            simcircuit.setNode(cpC1_A, scr, "RC1", "A", "C1", "A");
            cpC1_A.IsACVoltage = true;
            simcircuit.setNode(cpC1_B, scr, "RC1", "B", "C1", "B");
            cpC1_B.IsACVoltage = true;

            simcircuit.setNode(cpC1_1, scr, "SC1-1", "1", "C1", "1");
            cpC1_1.IsACVoltage = true;
            simcircuit.setNode(cpC1_2, scr, "SC1-1", "2", "C1", "2");
            cpC1_2.IsACVoltage = true;
            simcircuit.setNode(cpC1_3, scr, "SC1-3", "3", "C1", "3");
            cpC1_3.IsACVoltage = true;
            simcircuit.setNode(cpC1_4, scr, "SC1-3", "4", "C1", "4");
            cpC1_4.IsACVoltage = true;
            simcircuit.setNode(cpC1_5, scr, "SC1-5", "5", "C1", "5");
            cpC1_5.IsACVoltage = true;
            simcircuit.setNode(cpC1_6, scr, "SC1-5", "6", "C1", "6");
            cpC1_6.IsACVoltage = true;

            simcircuit.setNode(cpC1_NO1, scr, "SC1-NO1", "NO1", "C1", "NO1");
            simcircuit.setNode(cpC1_NC1, scr, "SC1-NC1", "NC1", "C1", "NC1");
            simcircuit.setNode(cpC1_NO2, scr, "SC1-NO2", "NO2", "C1", "NO2");
            simcircuit.setNode(cpC1_NC2, scr, "SC1-NC2", "NC2", "C1", "NC2");

            simcircuit.setNode(cpOL1_2, scr, "ROL1-1", "2", "OL1", "2");
            cpOL1_2.IsACVoltage = true;
            simcircuit.setNode(cpOL1_4, scr, "ROL1-3", "4", "OL1", "4");
            cpOL1_4.IsACVoltage = true;
            simcircuit.setNode(cpOL1_6, scr, "ROL1-5", "6", "OL1", "6");
            cpOL1_6.IsACVoltage = true;

            simcircuit.setNode(cpOL1_13, scr, "SOL1-13", "13", "OL1", "13");
            simcircuit.setNode(cpOL1_14, scr, "SOL1-13", "14", "OL1", "14");
            simcircuit.setNode(cpOL1_15, scr, "SOL1-15", "15", "OL1", "15");
            simcircuit.setNode(cpOL1_16, scr, "SOL1-15", "16", "OL1", "16");
            #endregion

            sc.BlowerContactors.Add(this);
        }

       

        private void SoundMuteHandler(object sender, EventArgs e)
        {
            double v = blowerVolume;
            if (Program.soundMute) v = 0;
            blowerRunningPlayer1.Volume = v;
            blowerRunningPlayer2.Volume = v;

            v = contactorVolume;
            if (Program.soundMute) v = 0;
            contactorClickPlayer.Volume = v;
        }

        private void blowerRun()
        {
            double v = blowerVolume;
            if (Program.soundMute) v = 0;
            blowerRunningPlayer1.Volume = v;
            blowerRunningPlayer1.Position = new TimeSpan(0, 0, 0);
            blowerRunningPlayer1.Play();

            blowerRunningPlayer2.Volume = v;
            blowerRunningPlayer2.Position = new TimeSpan(0, 0, 10);
            blowerRunningPlayer2.Play();
        }

        public void blowerStop()
        {
            blowerRunningPlayer1.Position = new TimeSpan(0, 0, 0);
            blowerRunningPlayer1.Stop();
            blowerRunningPlayer2.Position = new TimeSpan(0, 0, 0);
            blowerRunningPlayer2.Stop();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            MediaPlayer m = sender as MediaPlayer;
            m.Position = new TimeSpan(0, 0, 0);
            m.Play();
        }
    }
}
