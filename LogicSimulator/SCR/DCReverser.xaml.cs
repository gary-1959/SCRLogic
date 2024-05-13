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
    /// Interaction logic for DCReverser.xaml
    /// </summary>
    public partial class DCReverser : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public BitmapImage topClosedImage { get; set; }
        public BitmapImage btmClosedImage { get; set; }
        public BitmapImage openImage { get; set; }
        public List<Program.SwitchContact> auxContactsTop { get; set; }
        public List<Program.SwitchContact> auxContactsBtm { get; set; }
        public Resistor coilElementTop { get; set; }
        public Resistor coilElementBtm { get; set; }

        public string location { get; set; }
        public string tag { get; set; }

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
                isClosed = "OPEN";
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
                _isStuck= value;
            }
        }
        private string _isClosed;
        public string isClosed
        {
            get
            {
                return _isClosed;
            }
            set
            {
                string newState = value;
                if (_isFaulty) {
                    newState = "OPEN";
                }
               
                if (_isStuck && (_isClosed == "TOP" || isClosed=="BTM"))
                {
                    newState = _isClosed;
                }

                if (_isClosed != newState)
                {
                    _isClosed = newState;
                    if (_isClosed == "OPEN")
                    {
                        ContactorImage.Source = openImage;
                        Program.contactorClick();
                    }
                    else if (_isClosed == "TOP")
                    {
                        ContactorImage.Source = topClosedImage;
                        Program.contactorClick();
                    }
                    else if (_isClosed == "BTM")
                    {
                        ContactorImage.Source = btmClosedImage;
                        Program.contactorClick();
                    }
                    setAuxContacts();
                }
            }
        }

        public DCReverser()
        {
            InitializeComponent();

            auxContactsTop = new List<Program.SwitchContact>();
            auxContactsBtm = new List<Program.SwitchContact>();
            _isFaulty = false;
            _isStuck = false;
            Program.TickComplete += tickCompleteHandler;

        }

        public void tickCompleteHandler(object sender, EventArgs e)
        {
            if (isFaulty)
            {
                isClosed = "OPEN";
            }
            else
            {

                if ((coilElementTop != null) && (coilElementBtm != null))
                {
                    if ((Program.isCoilEnergised(coilElementTop, 60)) && (Program.isCoilEnergised(coilElementBtm, 60)))
                    {
                        isClosed = _isClosed;
                    }
                    else if (Program.isCoilEnergised(coilElementTop, 60))
                    {
                        isClosed = "TOP";
                    }
                    else if (Program.isCoilEnergised(coilElementBtm, 60))
                    {
                        isClosed = "BTM";
                    }
                    else
                    {
                        // if stuck contactor will close but not open
                        if (!isStuck) isClosed = "OPEN";
                    }
                }
                else if (coilElementTop != null)
                {
                    if (Program.isCoilEnergised(coilElementTop, 60))
                    {
                        isClosed = "TOP";
                    }
                    else
                    {
                        if (!isStuck) isClosed = "OPEN";
                    }
                }
                else if (coilElementBtm != null)
                {
                    if (Program.isCoilEnergised(coilElementBtm, 60))
                    {
                        isClosed = "BTM";
                    }
                    else
                    {
                        if (!isStuck) isClosed = "OPEN";
                    }
                }
            }

        }

        public void configureContactor(SimCircuit sc, string scr, int k)
        {
            simcircuit = sc;
            openImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-REVERSER-OPEN.png"));
            topClosedImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-REVERSER-CLOSED-TOP.png"));
            btmClosedImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-REVERSER-CLOSED-BOTTOM.png"));


            simcircuit.setNode(cpA, scr, "SK" + k.ToString() + "-A", "A", "K" + k.ToString(), "A");
            simcircuit.setNode(cpB, scr, "SK" + k.ToString() + "-A", "B", "K" + k.ToString(), "B");
            simcircuit.setNode(cpC, scr, "SK" + k.ToString() + "-C", "C", "K" + k.ToString(), "C");
            simcircuit.setNode(cpD, scr, "SK" + k.ToString() + "-C", "D", "K" + k.ToString(), "D");
            simcircuit.setNode(cpE, scr, "SK" + k.ToString() + "-E", "E", "K" + k.ToString(), "E");
            simcircuit.setNode(cpF, scr, "SK" + k.ToString() + "-E", "F", "K" + k.ToString(), "F");
            simcircuit.setNode(cpG, scr, "SK" + k.ToString() + "-G", "G", "K" + k.ToString(), "G");
            simcircuit.setNode(cpH, scr, "SK" + k.ToString() + "-G", "H", "K" + k.ToString(), "H");
            simcircuit.setNode(cpJ, scr, "SK" + k.ToString() + "-J", "J", "K" + k.ToString(), "J");
            simcircuit.setNode(cpK, scr, "SK" + k.ToString() + "-J", "K", "K" + k.ToString(), "K");
            simcircuit.setNode(cpL, scr, "SK" + k.ToString() + "-L", "L", "K" + k.ToString(), "L");
            simcircuit.setNode(cpM, scr, "SK" + k.ToString() + "-L", "M", "K" + k.ToString(), "M");
            simcircuit.setNode(cpN, scr, "SK" + k.ToString() + "-N", "N", "K" + k.ToString(), "N");
            simcircuit.setNode(cpP, scr, "SK" + k.ToString() + "-N", "P", "K" + k.ToString(), "P");
            simcircuit.setNode(cpQ, scr, "SK" + k.ToString() + "-Q", "Q", "K" + k.ToString(), "Q");
            simcircuit.setNode(cpR, scr, "SK" + k.ToString() + "-Q", "R", "K" + k.ToString(), "R");
            simcircuit.setNode(cpPT, scr, "RK" + k.ToString() + "T", "[+]", "K" + k.ToString(), "[+]");
            simcircuit.setNode(cpNT, scr, "RK" + k.ToString() + "T", "[-]", "K" + k.ToString(), "[-]");
            simcircuit.setNode(cpPB, scr, "RK" + k.ToString() + "B", "[+]", "K" + k.ToString(), "[+]");
            simcircuit.setNode(cpNB, scr, "RK" + k.ToString() + "B", "[-]", "K" + k.ToString(), "[-]");

            auxContactsBtm.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-A", false));
            auxContactsBtm.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-E", false));
            auxContactsBtm.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-J", false));
            auxContactsBtm.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-N", false));

            auxContactsTop.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-C", false));
            auxContactsTop.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-G", false));
            auxContactsTop.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-L", false));
            auxContactsTop.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-Q", false));

            string top = "RK" + k.ToString() + "T";
            string btm = "RK" + k.ToString() + "B";
            foreach (KeyValuePair<string, NetElement> el in simcircuit.elements)
            {
                if (el.Value.location == scr)
                {
                    if (el.Value.nettag == top)
                    {
                        coilElementTop = el.Value.simElement as Resistor;
                    }
                    if (el.Value.nettag == btm)
                    {
                        coilElementBtm = el.Value.simElement as Resistor;
                    }
                    if ((coilElementTop != null) && (coilElementBtm != null)) break;
                }
            }
            isClosed = "OPEN";
            location = scr;
            tag = "K" + k.ToString();
            sc.DCReversers.Add(this);
        }


        public void setAuxContacts()
        {
            if (_isClosed == "OPEN")
            {
                foreach (Program.SwitchContact c in auxContactsTop)
                {
                    simcircuit.contactPos(c, false);
                }
                foreach (Program.SwitchContact c in auxContactsBtm)
                {
                    simcircuit.contactPos(c, false);
                }
            }
            else if (_isClosed == "TOP")
            {
                foreach (Program.SwitchContact c in auxContactsTop)
                {
                    simcircuit.contactPos(c, true);
                }
                foreach (Program.SwitchContact c in auxContactsBtm)
                {
                    simcircuit.contactPos(c, false);
                }
            }
            else if (_isClosed == "BTM")
            {
                foreach (Program.SwitchContact c in auxContactsTop)
                {
                    simcircuit.contactPos(c, false);
                }
                foreach (Program.SwitchContact c in auxContactsBtm)
                {
                    simcircuit.contactPos(c, true);
                }
            }
        }
    }
}
