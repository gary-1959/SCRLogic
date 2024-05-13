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
    /// Interaction logic for DCContactor.xaml
    /// </summary>
    public partial class DCContactor : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public BitmapImage closedImage { get; set; }
        public BitmapImage openImage { get; set; }
        public List<Program.SwitchContact> auxContacts { get; set; }
        public Resistor coilElement { get; set; }

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
                _isStuck= value;
            }
        }
        private bool? _isClosed;
        public bool? isClosed
        {
            get
            {
                return _isClosed;
            }
            set
            {
                bool? newState = value;
                if (_isFaulty) {
                    newState = false;
                }
               
                if (_isStuck && (_isClosed == true))
                {
                    newState = true;
                }

                if (_isClosed != newState)
                {
                    _isClosed = newState;
                    if (_isClosed == true)
                    {
                        ContactorImage.Source = closedImage;
                        Program.contactorClick();
                    }
                    else
                    {
                        ContactorImage.Source = openImage;
                        Program.contactorClick();
                    }
                    setAuxContacts();
                }
            }
        }

        public DCContactor()
        {
            InitializeComponent();

            auxContacts = new List<Program.SwitchContact>();
            _isFaulty = false;
            _isStuck = false;
            Program.TickComplete += tickCompleteHandler;

        }

        public void tickCompleteHandler(object sender, EventArgs e)
        {
            if (isFaulty)
            {
                isClosed = false;
            }
            else
            {
                // if stuck contactor will close but not open
                if (!isStuck || (isStuck && (isClosed == false)))
                {
                    if (coilElement != null)
                    {
                        if (Program.isCoilEnergised(coilElement, 60))
                        {
                            isClosed = true;
                        }
                        else
                        {
                            isClosed = false;
                        }
                    }
                    else
                    {
                        isClosed = false;
                    }
                }
            }
        }


        public void configureContactor(SimCircuit sc, int size, string scr, int k)
        {
            simcircuit = sc;
            if (size == 1800)
            {
                openImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-1800-OPEN.png"));
                closedImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-1800-CLOSED.png"));
            }
            else if (size == 1250)
            {
                openImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-1250-OPEN.png"));
                closedImage = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/CONTACTOR-1250-CLOSED.png"));
            }
            simcircuit.setNode(cp01, scr, "SK" + k.ToString() + "-1", "1", "K" + k.ToString(), "1");
            simcircuit.setNode(cp02, scr, "SK" + k.ToString() + "-1", "2", "K" + k.ToString(), "2");
            simcircuit.setNode(cp03, scr, "SK" + k.ToString() + "-3", "3", "K" + k.ToString(), "1");
            simcircuit.setNode(cp04, scr, "SK" + k.ToString() + "-3", "4", "K" + k.ToString(), "1");
            simcircuit.setNode(cp05, scr, "SK" + k.ToString() + "-5", "5", "K" + k.ToString(), "1");
            simcircuit.setNode(cp06, scr, "SK" + k.ToString() + "-5", "6", "K" + k.ToString(), "1");
            simcircuit.setNode(cp07, scr, "SK" + k.ToString() + "-7", "7", "K" + k.ToString(), "1");
            simcircuit.setNode(cp08, scr, "SK" + k.ToString() + "-7", "8", "K" + k.ToString(), "1");
            simcircuit.setNode(cpP, scr, "RK" + k.ToString(), "[+]", "K" + k.ToString(), "[+]");
            simcircuit.setNode(cpN, scr, "RK" + k.ToString(), "[-]", "K" + k.ToString(), "[-]");

            auxContacts.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-1", false));
            auxContacts.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-3", false));
            auxContacts.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-5", true));
            auxContacts.Add(new Program.SwitchContact(simcircuit, scr, "SK" + k.ToString() + "-7", true));

            string nettag = "RK" + k.ToString();
            foreach (KeyValuePair<string, NetElement> el in simcircuit.elements)
            {
                if (el.Value.location == scr)
                {
                    if (el.Value.nettag == nettag)
                    {
                        coilElement = el.Value.simElement as Resistor;
                        break;
                    }
                }
            }
            isClosed = false;
            location = scr;
            tag = "K" + k.ToString();
            sc.DCContactors.Add(this);
        }


        public void setAuxContacts()
        {
            foreach (Program.SwitchContact c in auxContacts)
            {
                simcircuit.contactPos(c, (isClosed == true));
            }
        }
    }
}
